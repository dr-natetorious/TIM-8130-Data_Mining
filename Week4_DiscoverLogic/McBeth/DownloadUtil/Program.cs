using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace DownloadUtil
{
    class Program
    {
        const string address = "https://www.opensourceshakespeare.org/views/plays/play_view.php?WorkID=macbeth&Act=&Scene=&Scope=entire&displaytype=print";

        public static void Main()
        {
            var webclient = new WebClient();
            var html = new HtmlDocument();
            html.LoadHtml(webclient.DownloadString(address));

            var ulTags = html.DocumentNode.Descendants("ul");
            using var sw = new StreamWriter("mcbeth.txt");
            foreach (var ulTag in ulTags)
            {
                var text = RemoveDiacritics(ulTag.InnerText.ToLower());
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

                sw.WriteLine(sb.ToString().Trim());
            }
        }

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
