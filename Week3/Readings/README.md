# Literature Review

## A Study of Algorithm Selection in Data Mining using Meta-Learning (2017)

In _Journal of Engineering Science & Technology Review. 2017, Vol. 10 Issue 2, p51-64. 14p._; [Tripathy, M; Panda, A](AlgorithmSelection.pdf) describes the challenges of the `No Free Lunch Theorm` that states _an algorithm does not exist which works equally well in all scenarios_.  They address the issue with a meta-learning strategy that applies several categories of learning algorithms and then measures the performance.  

The researchers also used clusters and classification algorithms to examine the shapes of aprx 77 open source data sets.  This approach allows them to partition large datasets into smaller blocks, then evaluate those blocks similarity.  After analyzing a datatroid they can ignore the other records within the same batch as they are known to be very similar.

The key take away from this piece is that _researchers need to always try new things, and iterate over the algorithm search space_.  We might know upfront that that a learning algorithm needs to do classification, but how?  There are hundreds of different functions available.  Through `metalearning` as a mechanism for _scanning the algorithmic search space_ we can identify "sonar pings" that say go that way towards Decision Trees or Naive Bayes.

Those metalearnings and metaexamples can be defined as super examples or feature composites that represent the problem.  For instance, a metaexample might be a single instance from a cluster of related records.  Meta features could be something derived, like a PCA or another highly correlated abstract representation.  In many scenarios these smaller data sets are equally represenative and easier to manage and train.

## An Investigation of Nonparametric DATA MINING TECHNIQUES for Acquisition Cost Estimating (2017)

In _Defense Acquisition Research Journal: A Publication of the Defense Acquisition University. Apr2017, Vol. 24 Issue 2, p302-332. 31p._; [Brown, G; White, E](Mining_AcquisitionCost_Estimates.pdf) state that _using meta-analysis indicate that, on average, the nonparametric techniques outperform OLS (ordinary least squares) regression for cost estimating_.  The authors then investigated how these more complex models performed when predicting the purchase of aircrafts at the DoD.  There was limited data available, so they relied on estimates for software projects as a research proxy.

They note that while nonparametric techniques are more precise, it comes with a need for significantly more data.  Using metaanalysis different software project estimates are first clustered to find similarities.  By looking at the Euclidian distance between the examples it emulates humans "apples-to-apples reasoning."

Next they looked at MultiLayer Perceptron (MLP) neural networks, which are simply a non-parametric function mapped to a parametric function.  The goal of the hidden layer is to discover the network weights through so that the output layer becomes a linear function.  This algorithm is frequently found in research as it is fairly simple to apply.  However, there can be challenges with explaining the "black box" even when its accurate, and that can lower confidence to decision makers.

The third category of algorithms is decision tree regressors, that attempt to split the continuous output range into regions based on tree braches.  A critical strength of these structures comes from their ability to be easily explained.  The researchers recommend limiting the number decisions to a fairly small number (e.g., 3-5) to avoid overfitting.

When there is insufficient data they also recommend not estimating additional ranges.  They state that without evidence those estimates would be correct it only pollutes the optimization algorithm with overfitting.

## A survey on pre-processing techniques: Relevant issues in the context of environmental data mining (2016)

In _AI Communications. 2016, Vol. 29 Issue 6, p627-663. 37p._; [Gibert, K; Sanchez-Marre, M; Izquierdo, J](PreProcessing_Techniques.pdf)...

## Recommending Learning Activities in Social Network Using Data Mining Algorithms (2017)

In _Journal of Educational Technology & Society. Oct2017, Vol. 20 Issue 4, p11-23. 13p._; [Mahnane, L](RecommendationLearning_SocialNetworks.pdf)...

## Data Mining: Practical Machine Learning Tools and Techniques (2011)

In chapter 4, _Algorithms: The Basic Methods_, [Witten, I](DataMining_ch4.pdf)...