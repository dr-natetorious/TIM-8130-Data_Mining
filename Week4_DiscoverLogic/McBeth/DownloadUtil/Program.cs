using HtmlAgilityPack;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace DownloadUtil
{
    /// <summary>
    /// Simple script to download all Shakespeare plays from open data set.
    /// </summary>
    class Program
    {
        private static readonly WebClient webclient = new WebClient();

        public static void Main()
        {
            // Download the list of plays
            var html = new HtmlDocument();
            html.LoadHtml(webclient.DownloadString("https://www.opensourceshakespeare.org/views/plays/plays.php"));
            using var writer = new StreamWriter("shakespeare.txt");

            // Foreach play...
            foreach (var anchor in html.DocumentNode.Descendants("a"))
            {
                // Get the address of the next play
                var href = anchor.GetAttributeValue("href", string.Empty);
                if (href.StartsWith("playmenu.php") == false)
                {
                    continue;
                }

                // Swap out the title page for the full text view...
                href = href.Replace("playmenu.php", "play_view.php");
                var address = $"https://www.opensourceshakespeare.org/views/plays/{href}&Scope=entire&pleasewait=1&msg=pl";
                Console.WriteLine(address);

                // Finally append the play text to the output file.
                DownloadPlay(writer, address);
            }
        }

        /// <summary>
        /// Download the Play and append it to the output file.
        /// </summary>
        /// <remarks>
        /// The web page is formatted as repeating &lt;ul&gt;Speaker. Quote&lt;/ul&gt;
        /// 
        /// A smarter version of this should create distinct files per speaker, then train for unique character voices.
        /// </remarks>
        /// <param name="writer">The output file</param>
        /// <param name="address">Parameterized request to play_view.php</param>
        private static void DownloadPlay(StreamWriter writer, string address)
        {
            var html = new HtmlDocument();
            html.LoadHtml(webclient.DownloadString(address));

            var ulTags = html.DocumentNode.Descendants("ul");

            var found = 0;
            foreach (var ulTag in ulTags)
            {
                string final = NormalizeNextSpeaker(ulTag);
                if (string.IsNullOrWhiteSpace(final)) continue;

                found++;
                //Console.WriteLine(final);
                writer.WriteLine(final);
            }

            Console.WriteLine($"Found {found}");
        }

        /// <summary>
        /// Normalize the quote from the play.
        /// </summary>
        /// <remarks>
        /// Additional logic to segment the speakers and do smarter things goes here.
        /// </remarks>
        /// <param name="ulTag">The next speaker section.</param>
        /// <returns>The normalized text.</returns>
        private static string NormalizeNextSpeaker(HtmlNode ulTag)
        {
            var text = RemoveDiacritics(ulTag.InnerText.ToLowerInvariant());
            var sb = new StringBuilder(text.Length);
            var lastSpace = false;
            foreach (var ch in text)
            {
                if (char.IsLetter(ch) || ch == '\'')
                {
                    sb.Append(ch);
                    lastSpace = false;
                }
                else
                {
                    if (lastSpace == false)
                    {
                        sb.Append(" ");
                    }

                    lastSpace = true;
                }
            }

            var final = sb.ToString().Trim();
            return final;
        }

        /// <summary>
        /// Removes accents and other unicode annotations that make words unique.
        /// </summary>
        /// <param name="text">The text to filter.</param>
        /// <returns>Filtereed text.</returns>
        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
