# Outline for Paper

## Section I: Business Structure

### What is Black Bean Virtual Organization

- History
- Growth int - challenges
- Challenges of the organization
  - Health and Safety
  - Customer Satisfaction
- What scenarios use IoT
  - Smart Kitchens
  - Customer Satisfaction
  - Video of Cashier Interactions
  - Tracking Inventory
  - Sensors for safety
  - Automate Key Performance Indictators for Business Units
  - Physical Security – Moniton sensors and night

### What types of data artifacts exist

- Inventory Tracking by RFID
- Point of Sales information
- Business Reporting on KPI
- Health and Safety – Eg. Refrigeration information
- Customer Satisfaction

### What business goals use these artifacts

- Snee (2015) misconception that lots of data + analysis = magic.
- A recent outbreak of food poisoning at some locations has damaged the brand’s image and caused a significant decrease in sales.  The leadership team wants t  - restore consumer confidence by operationalizing their data lake t  - answer targeted questions about the incident.  Which sites are likely t  - have an outbreak next?  Are food handling procedures being followed?  Wh  - should promotional material target?
- Cost for carrying inventory and (Viale, 1996)
- Social media intelligence and impact on customer satisfaction (Gioti, Ponis, & Panayiotou, 2018)

## Section II: Collecting and Enhancement

Preprocessing Data Resources
- According t  - Gibert et al. (2016), nearly 70% of all data mining occurs during the cleaning phase.
- Data Catalog as step in lifecycle (Zambetti, Pinto, & Pezzotta, 2019) 
- Before analysis can begin, the data analyst needs t  - normalize the incoming data through an extract-transform-load (ETL) process.  This process needs t  - perform column renaming and reordering, adjusting quantity units, filtering erroneous values, populating missing values, and similar cleanup actions.  When analysis does not handle these aspects upfront, it creates a garbage-in/garbage-out scenario.  For example, a temperature reading of 55 degrees could be manually entered as 555 degrees, causing later analysis t  - become skewed.
- After cleaning and schematizing the incoming data, the next analyst needs t  - determine which aspects are relevant for their data mining objective.  Having large amounts of unrelated information does not improve results, and for many scenarios, it only slows down model training times.
- Another critical challenge is handling missing values (Rawal et al., 2017) as they need t  - be normalized or removed.  These decisions become scenarios specific.
- The cleaned data set might need additional enhancements by combining across related information.  For instance, the marketing team can use Point Of Sales + Mobile App + seasonal trends t  - create targeted marketing campaigns
Required Collection Resources
- Tracking inventory across the supply chain has several human touch points that need t  - consider.  From the supplier placing RFID tags on containers t  - the workers at the distribution center that hold these items until needed.  Managers need t  - be responsible and accountable for their staff t  - follow the standards and report metrics in a timely and accurate manner.  Local network managers d  - not exist, s  - some central networking team would need t  - work with IoT vendors t  - support these sensors.  Operations teams need t  - monitor for anomalies using models created by the data analysis team.  The analysis prioritize which aspects t  - model based on the business leadership direction.
- Multiple hardware technologies need t  - be deployed t  - monitor from the garden t  - the customer’s review.  These technologies include
  - RFID General tags  (Balic et al., 2010)
  - Inventory Tracking with RFID (Zhang et al., 2018)
  - Sharing Point of Sales Systems (Croson & K, 2003)
  - Smart Restaurant with IoT (Koubai & Bouyakoub, 2018)
- Future Capacity or needs exist
  - What happens as the number of sensors increases (e.g., instance learning) (Witten, 2011)
  - Stream processing and realtime analysis (Basanta-Val et al., 2017)
What logical components or assumptions exist
- Logical Component 1 of 2
- Logical Component 2 of 2

## Section III: Evaluation Procedures

What statistical techniques can measure process ROI
- A successful strategy needs t  - align the business goals t  - KPI and then deliver data solutions that improve those objectives. (Gonzales & Wareham, 2019) discuss how this becomes more prominent as the organization grows in maturity
- Liyanage et al. (2018) provide a list of KPIs for smart restaurants such as correct products, reducing delays between orders, recommendation accuracies, and the amount of friction bridging int  - mobile.
- Statistical analysis
  - Snee (2005) points out that by random chance some features are randomly correlated (ala Multicollinearity)
  - Correlation versus Causation
  - Variance and standard deviations
Section IV: Future Applications
What data mining strategies can apply t  - this information
- Time Series analysis with clustering data t  - form a semantic model and then use spark t  - process the algorithms (Talei & Benhaddou, 2018)
- LTSM and neural networks (Keras)?
- Using gestures from vide  - - metalearning (Fong et al., 2016)
- Ensemble methods like Netflix (Bell, Koren, & Volinsky, 2007)

## Conclusions

I. Black Bean is a growing multinational organization
  - They have embraced the need for IoT t  - automate many internal processes
  - Health and Safety, Customer Satisfaction, Inventory Management
  - Collecting for analysis these data points is complex due t  - the unstructured nature and heterogeneous formats.
II. The organization needs t  - identify specific KPIs of interest and then determine which relevant facts support their hypothesis.  These facts will need t  - be cleaned, this is 70% of the total data mining.  Garbage in/out. 
  - After cleaning the data needs t  - be segmented and structured in such a way that it supports model training.  The model produced needs t  - be scientificially sound and explainable, ideally through a graphical process.
  - Collecting and recording these figures requires numerous personal and hardware resources.  Care needs t  - take place that it does not become corrupt through errorous data entry and similar situations
