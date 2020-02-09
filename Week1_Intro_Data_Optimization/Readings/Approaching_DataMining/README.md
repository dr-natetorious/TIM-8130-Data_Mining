# Approaching Data Mining

## Practical Approach to Data Mining: I Have All These Data; Now What Should I Do? (2015)

In _Quality Engineering, 27:477–487, 2015_; [Snee, R](PracticalApproach_DataMining.pdf) describes the misconception that `lots of data + analysis = magic` and then continues with a proposed _building blocks of analytics_ that begins with questions and then seeks answers to confirm or deny the theory.

> It is critical to think carefully about the problem, then collect data that answers key questions that are central to solving the problem and do exploratory analysis typically involving some variety of graphics and a variety of models—both qualitative and quantitative (Snee 2002).

Critical aspects of data-based problem solving should be `practical, graphical, and analytical`.  Without a basis is subject matter, the predictions will be arbitrary and irrelevant. Graphical aspects means that the technique should allow be exploratory and allow for a conversation around the data and results.  Analyticial refers to the statistical and modeling strategies that are used.  Sometime the sequence will be practical -- then analytical concluded by graphical as a mechanism to reduce dimensionality.

![building_blocks.png](building_blocks.png)

### How do I evaluate data quality

Before using data it is important to know how it was generated and what it represents.  There should be descriptive statistics that check the data for completeness and correctiveness.  For instance, if the data represents a year long process then confirm that there are observations during all twelve months.

Confirm the data does not have `Multicollinearity` _a statistical phenomenon in which multiple independent variables show high correlation between each other_ [My Accounting Course 2019](https://www.myaccountingcourse.com/accounting-dictionary/multicollinearity).

> Best results are obtained when the predictors (Xs) are independent (zero correlation). It is helpful to recall that designed experiments are constructed so that the correlations
among the Xs are typically near zero or equal to zero.

- Collect additional data to reduce the effects of multicollinearity
- Revise the model by deleting or combining variables that are multicollinearity
- Use ridge regression and other biased estimation procedures to estimate the model coefficients

### What is observational data

Data which is collected without controls and careful administration.  These datasets often contain errors and missing data values, such as weather sensors and IoT devices that might miss points due to networking glitches or mechanical failure.  This ties directly back into understanding the data before using it.

### What is model validation

After extracting patterns from the dataset it is important to also verify that they align with expectations.  Snee describes a case study where they built a model based on defect information, but after verifying the measurement and results discovered that a callibration problem caused all of the data to become skewed.

### How do I plan for success

It is important to have a strategy at the start to guide the effort, and goals to address by the end.
The project execution strategy answers questions such as the following ones:

- What is the goals and objectives for the project?
- What is the timeline and critical milestones?
- What are the sources of data?
- What resources are needed: project team members, equipment, funding?
- How will the results be used?

The data analysis and modelling strategy answers questions such as the following ones:

- What specific data sets will be used and how will these data sets be integrated?
- How will the data pedigree be assessed?
- What are the goals for the analysis: Develop a prediction equation? Identify critical variables? Assess process capability and stability? And so on.
- What statistical tools will be used and how will the tools be linked and sequenced?
- How will the results of the statistical analysis be confirmed and validated?
- How will the results be displayed and communicated?

In addition, there are some other critical success factors that need to be considered including the following
ones:

- Do not wait for your data to be “perfect” or you will never get started. But think sequential—Few problems are solved with a single data set;
- Get results quickly and look for quick fixes—Results encourage you and your customers to maintain the investment;
- Do not assume that the data keepers will be cooperative;
- Pay attention to the communication and implementation of results;
- Consider within the business context how the models will be used.
