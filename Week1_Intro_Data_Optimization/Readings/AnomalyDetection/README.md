# Anomaly Detection Strategies

## Anomaly Detection Using Data Mining Methods in IT Systems: A Decision Support Application (2018)

In _Sakarya University Journal of Science, 22(4): 1109-1123, 2018._; [Sonmez, et al.](AnomalyDetection_Using_DataMining.pdf) review different mechanisms for anomaly detection in data mining scenarios.

> Anomaly detection is one of the crucial purposes of data mining studies [...] especially in the detection of financial frauds, insurance fraud, cyber security attacks, and failures in critical systems. [...] Log analysis is another critical area as it represents the memory and runtime transactional state of the system.

Many datasets contain millions of transactions, though anomaly detection can be used as a filter to prioritize the most interesting parts upfront.  It can also be used for checking the consistency of a feed and assessing its likelihood of being `well administratored data or observational data.`  Another advantage is that unlabeled data can become partially labeled by focusing on the outliers and determining what characteristisc are unusual.

### What is a Self-Organizing Map Algorithm (2013)

In _How SOM Algorithm Works_; [Korting, T](https://www.youtube.com/watch?v=H9H6s-x-0YE) demonstrates how the items tries to minimize the distance between each other, such that similar items are closest.  Afterward, a fixed amount of k-clusters is chosen to denote which what unsupervised family items belong too.  This allows future data to become classified and handled accordingly.

SOM Networks consists of four main components: initiation, competition, cooperation, adaptation.

- Initialization: all inputs are randomly weighted with small values
- Competition: foreach point calculate its own values by providing a basic decomposition function to the neurons
- Cooperation: reduce the space between neighboring neurons
- Adaptation: reduce the decomposition function so the weights are minimized relative to the nearby neurons

### What is genetic algorithm (2017)

In _How algorithms evolve (Gentic Algorithms)_; [LeiosOS](https://www.youtube.com/watch?v=qiKW1qX97qA) provides an example of calculating the traveling salesman by randomly sampling paths and then using tournments to choose the best instance.  Next a mate is selected and some of the orders are swapped and optionally mutated.  Random permutations of this process are then cycled through the tournment and procreate step several times -- eventually resulting in an efficient solution.

### What is Principal Component Analysis (2017)

In _StatQuest: PCA main ideas in only 5 minutes_; [Starmer, J](https://www.youtube.com/watch?v=HMOI_lkzW08) states that PCA is a _dimension reduction strategy_ that attempts to find the coorelation between different features within a dataset.  Then a PCA plot attempts to measure the differences between the correlated feature groups and inversely correlated groups.  When the data set is placed into the plot they will naturally cluster and provide a mechanism to determine their relevant correlated differences.

### What are other anomaly detection techniques

- Statistical Anomaly Detection Techniques
- Nearest Neighbor Based Anomaly Detection Techniques
- Clustering Based Anomaly Detection Techniques
- Information-Theoretic Anomaly Detection Techniques
- Classification Based Anomaly Detection Techniques
- Visualization Based Anomaly Detection Techniques
- Spectral Anomaly Detection Techniques
