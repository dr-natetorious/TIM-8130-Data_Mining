# Section 2: Week 4: Readings

## Synchrotron imaging and Markov Chain Monte Carlo reveal tooth mineralization patterns (2017)

In _Plos One [PLoS One] 2017 Oct 19; Vol. 12 (10)_; [Green et al.](MonteCarlo_Tooth_Mineralization.pdf) state that mammalian tooth mineralization remains poorly characterized.  The authors created X-ray microtomography scans of sheep molars and then applied Markov Chain + Monte Carlo sampling.  These results apply a Bayesian approach to form a density model of how the teeth naturally form.  They report that tooth formation occurs in two phases _secretion and maturation_ with maturation poorly understood despite being an active research area for nearly 300 years.  Understanding enamel formations can provide insights into past worlds as these structures do not decay postmortem.

### How did they perform the experiment

The authors used software to extract from the tooth scans the enamel density (HAp desnity per cubice centimeter) and plotted this against the degree of secetory-cell extension and the age-at-death as auxileray metrics.  These features were fed into [NLopt](https://nlopt.readthedocs.io/en/latest/), a nonlinear optimization library, to calculate the `Multi-Level Single-Linkage` and `Constrained Optimization BY Linear Approximations`.

To estimate the density they applied a MCMC(Monte Carlo Markov Chain) to determine the rate of enamel build up over an interval of `t`.  These samplings allowed them to account for the 3-D scan that used software to approximate the enamel from that 2-D view.

## When absence of evidence is evidence of absence (2017)

In _Cognitive Science. May2017, Vol. 41 Issue 5, p1155-1167. 13p._; [Hsu; Horng; Grittiths; Chater](Evidence_is_Absence.pdf) point out that "identifying patterns in the world requires noticing not only unusual occurrences, but also unusual absences."  People can make two types of inferences from the absence of an event: either the event is possible but has not yet occurred, or the event never occurs. A rational analysis using Bayesian inference predicts that inferences from absent data should depend on how much the absence is expected to occur, with less probable absences being more salient.

The authors provide an analogy of predicting _does Bob wear a tie_, that considers the difference between `rarely versus never`.  To determine this distinction can be statistically challenging because too say never requires a lot of samples over a long period of time.  These samples need to include various context (e.g., at home versus at work, etc.) or there is a high probability of `undergeneralization`.  In terms of real research the majority of the effort occurs with _language learning tasks_, as the absense of examples is a critical component of fully understanding grammar.

### What experiments did they perform

A study was placed on Amazon Mechanical Turk and participants were paid 0.35$ to complete the 12-minute experiment.  Participants were shown randomly generated mine sweep maps, and asked to randomly choose 10 of the 100 remaining squares.  Afterward, they needed to determine if the map was Type 1 (has mines) or Type 2 (no mines).  100% of the users that encountered a mine said the map was type 1.  For the remainder there compared against a Bayse equation to show that responses were correlated though humans were more conservative in judgement.

There was concern that the wording was ambigious so another study group was created to test a different mine sweeper.  This one explicitly asks are there mines in the control area, versus the former might have inferred they haven't occurred.  The second and more explicit test also provides a high correlation to the bayes model that is perhaps overly conservative.

## A Markov Chain Model for Changes in Users' Assessment of Search Results (2016)

In _Plos One [PLoS One] 2016 May 12; Vol. 11 (5)_; [Zhitomirsky-Geffet et al.](Markov_Assessment_of_Search_Results.pdf) note that "previous research shows that users tend to change their assessment of search results over time. This is a first study that investigates the factors and reasons for these changes, and describes a stochastic model of user behaviour that may explain these changes."

> According to the theory of coarse beliefs and categorical thinking, humans tend to divide the range of values under consideration into coarse categories, and are thus able to distinguish only between cross-category values but not within them.  We make use of a Markov chain model to [...] demonstrates that the changes converge, and that a majority of the changes are local to a neighbouring relevance category.

### What did they test

Their hypothesis is that people are poor judges of search result relevance.  Some studies report that 15-25% of results are irrelevant, despite a statistical analysis showing they are in the same category (cluster).  To explore this phenomena they asked a fixed audience of students to rank search the same set of results over a semester.  This process constrains all variables except for time (4 rounds).

## AUTOMATION OF GENERALIZED ADDITIVE NEURAL NETWORKS FOR PREDICTIVE DATA MINING (2011)

In _Applied Artificial Intelligence. May/Jun2011, Vol. 25 Issue 5, p380-425_; [de Waal; du Toit](Generalized_Additive_NeuralNetworks.pdf)...

## What is Missing? Using Data Mining Techniques with Business Cycle Phases for Predicting Company Financial Crises (2011)

In _Asia Pacific Management Review. Dec2011, Vol. 16 Issue 4, p535-549_; [I-Hsien; Yu-Cheng](DataMining_BusinessCycles.pdf) consider the influence of business cycles (e.g., peak, trough, expansion and recession pg6) on Taiwanese organizations that encounter a financial crisis and enter into bankrupcy.  They propose that other financial studies have not considered the cycle in their analysis despite the potential criticality.  One of the challenges with comparing their work to others, is that a concise shared definition does not exist.  The authors chose to use the state that the business has entered into catestrophic failure (e.g., trading has stopped, chairman fired, or opertions must halt).

> In detail, the main objectives of this paper are (a) building a financial crisis prediction model based on data mining techniques that also takes into consideration the phases of the business cycle as a new variable, (b) using these phases of the business cycle as a means to divide the financial data, and (c) using various data mining techniques, such as SVM
(Support Vector Machine), ANN (Artificial Neural Network) and LR (Logistic Regression), to identify important financial variables operative during different phases of the business
cycle.

### What did the literature tell them

The literature review covers several different scenarios for measuring the probability that an organization will enter into bankrupcy.  Several authors incorporate common fundamental analysis metrics into regression and classification algorithms.  More advanced studies rely on artifical intelligence methods, such as backpropigation neural networks, to map scoring similar fundamental metrics into business classifications.  Others rely on `ensemble strategies`, which combine multiple different algorithms (e.g., Support Vector Machines, Logistic Regression, and Multiple Discriminates Analysis) into a blended group of results-- then perform a weighted aggregation across those results.  Similar to the [Netflix Prize](../Week3_Application/Readings/NetflixPrize2007.pdf), ensemble continues to be highly effective through multiple intelligent signals confirming or disputing each other.

### How did was the experiment process occur

The authors created five models to account for the influence of cycle and various disclosure date specific scenarios.  Each of these models uses an experiment process of:

- Feature Selection - (58 variables => reduce via SVM into top 5,10,15,20,25)
- Classification
- K-fold Cross Validation - accuracy = [(True Positives + True Negatives) / Total Predictions]
- Best Result Score
- Model Construction for Prediction
