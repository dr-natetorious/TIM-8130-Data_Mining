# Text Mining

## Working with Text (2018)

In _JOURNAL OF THE ASSOCIATION FOR INFORMATION SCIENCE AND TECHNOLOGY_; [Tonkin & Tourte](Working_with_Text.pdf) provide a book review that deals with the end-to-end process of text mining.  They state that natural language processing (NLP) is full of complexities, especially as it transitions from formal writing to the internet.  These problems come from short and often mispelled micro-blogs that can infer multiple things.  In formal writing there can be pre-processing challenges, such as mining Old-English or even non-english languages.

There are several common patterns that successful projects can apply, such as `Subject-Verb-Object` extraction, n-gram character frequency indexing, etc.

## Data Processing and Text Mining Technologies on Electronic Medical Records: A Review (2018)

In _Journal Of Healthcare Engineering [J Healthc Eng] 2018 Apr 08; Vol. 2018, pp. 4302425._; [Sun et al.](TextMining_on_Electronic_Medical_Records.pdf) state that EMR is becoming a treasure trove for large-scale analysis of health data, as it is full of: text, symbols, graphics, data, and other electronic metadata.  This comes with all levels of structure including free form clinical and surgical notes.

They describe an EMR system starting with the procurement from medical professionals into preprocessing systems.  The preprocessing needs to connect multiple disjoined systems, transform and then anonymize before data scientist analyze the results.  They also have to do noise filtering, such as a patient temperature of 200 degrees and other erroneous values.

### What process is used for text mining

> The text mining process is usually composed of four stages: information retrieval, information extraction, knowledge discovery, and knowledge application.  The process of text mining is similar to that of classical data processing.

### What is Named-entity recognition (NER)

The NER task, which refers to the process of identifying particular types of names or symbols in document collections, was introduced for the first time at the MUC-6 (Message Understanding Conference) [9].  NER has two steps, entity boundary identification and entity class determination.

It can be challenging to cover the entire corpus because of spelling mistakes, different locale preferential terms, and ambiguity between similar names.

The authors propose measuring the accuracy of a NER system using `precision rate (P), recall rate (R), to calculate an F-score`-- with P= correct/total entities.  R=correct/tested entities.  F = (P*R*2)/(P+R).  They continue to outline more advanced strategies using as hidden Markov models (HMM), support vector machines (SVM), conditional random field (CRF)
[15], and maximum entropy (ME), are available according to data characteristics. Among a variety of machine learning algorithms, CRF methods are more popular because they
allow for the incorporation of various features that can be advantageous for the process of sequence labeling.
