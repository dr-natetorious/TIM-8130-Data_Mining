# City of NYC Open Data

The city of NYC provides open data sets for the public to analyze.

- [Open Parking and Camera Violations](https://data.cityofnewyork.us/City-Government/Open-Parking-and-Camera-Violations/nc67-uf89)
- [Film Permits](https://data.cityofnewyork.us/City-Government/Film-Permits/tg4x-b46p)
- [NYPC Complaint Data Historic](https://data.cityofnewyork.us/Public-Safety/NYPD-Complaint-Data-Historic/qgea-i56i)
- [Demographic Statistics](https://data.cityofnewyork.us/City-Government/Demographic-Statistics-By-Zip-Code/kku6-nxdu)
- [311 Service Requests](https://data.cityofnewyork.us/Social-Services/311-Service-Requests-from-2010-to-Present/7ahn-ypff)

## How can I create a decision tree

The following script was executed across the NYPC Complaint Data Historic.

### Install Rendering Software

```bash
pip install graphviz
yes | conda install graphviz
```

### Generate the tree

```python
import pandas as pd
from sklearn import tree

# Read the csv file...
csv = pd.read_csv('NYPD_Complaint_Data_Historic.csv')

# Choose the subset and transform it...
df = csv[['Latitude','Longitude','SUSP_RACE','VIC_RACE','PD_CD']].dropna()
df['srace_factor'] = pd.factorize(df['SUSP_RACE'])[0]
df['vrace_factor'] = pd.factorize(df['VIC_RACE'])[0]

# Select the features...
X=df[["Latitude","Longitude","srace_factor","vrace_factor"]].to_numpy()
y=df["PD_CD"]

# Build the tree
clf = tree.DecisionTreeClassifier(max_depth=3)
clf = clf.fit(X,y)

from sklearn.tree.export import export_text
print(export_text(clf, feature_names=["Latitude","Longitude","srace_factor","vrace_factor"]))

graphviz.Source(tree.export_graphviz(clf, out_file=None,
    feature_names=["Latitude","Longitude","srace_factor","vrace_factor"],
    filled=True, rounded=True))
```
