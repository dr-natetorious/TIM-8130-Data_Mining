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

## How can I apply logistic regression

```python
import pandas as pd
csv = pd.read_csv('DOHMH_New_York_City_Restaurant_Inspection_Results.csv')

from sklearn import feature_extraction
def one_hot_dataframe(data, cols, replace=False):
    vec = feature_extraction.DictVectorizer()
    mkdict = lambda row: dict((col, row[col]) for col in cols)
    vecData = pd.DataFrame(vec.fit_transform(
    data[cols].apply(mkdict, axis=1)).toarray())
    vecData.columns = vec.get_feature_names()
    vecData.index = data.index
    if replace:
        data = data.drop(cols, axis=1)
        data = data.join(vecData)
    return (data, vecData)

# Split the test and training data
train = csv[:200000][["CUISINE DESCRIPTION","CRITICAL FLAG","VIOLATION CODE","INSPECTION TYPE","SCORE"]].dropna()
test = csv[200000:][["CUISINE DESCRIPTION","CRITICAL FLAG","VIOLATION CODE","INSPECTION TYPE","SCORE"]].dropna()

# Build the train set
X_train = train.drop(columns=['SCORE'])
Y_train = train[["SCORE"]]

# Build the test set
X_test = test.drop(columns=['SCORE'])
Y_test = test[["SCORE"]]

# One Hot encode
x_train_hot = one_hot_dataframe(X_train, ["CUISINE DESCRIPTION","CRITICAL FLAG","VIOLATION CODE","INSPECTION TYPE"], replace=True)
x_test_hot = one_hot_dataframe(X_test, ["CUISINE DESCRIPTION","CRITICAL FLAG","VIOLATION CODE","INSPECTION TYPE"], replace=True)

# Drop the columns that are missing from each other
x_train_hot[1]  = x_train_hot[1].drop(columns=['INSPECTION TYPE=Administrative Miscellaneous / Re-inspection', 'VIOLATION CODE=20F'])

from sklearn.decomposition import PCA
pca = PCA(n_components=10)
pca = pca.fit(x_test_hot[1])
x_test = pca.transform(x_test_hot[1])

clr = LogisticRegression(solver='lbfgs')
clr = clr.fit(x_train, Y_train['SCORE'])
# 10.8%
```

## How can I use a DecisionTreeRegressor

```python
import pandas as pd
csv = pd.read_csv('DOHMH_New_York_City_Restaurant_Inspection_Results.csv')

from sklearn import feature_extraction
def one_hot_dataframe(data, cols, replace=False):
    vec = feature_extraction.DictVectorizer()
    mkdict = lambda row: dict((col, row[col]) for col in cols)
    vecData = pd.DataFrame(vec.fit_transform(
    data[cols].apply(mkdict, axis=1)).toarray())
    vecData.columns = vec.get_feature_names()
    vecData.index = data.index
    if replace:
        data = data.drop(cols, axis=1)
        data = data.join(vecData)
    return (data, vecData)

# Split the test and training data
train = csv[:200000][["BORO","CRITICAL FLAG","GRADE","VIOLATION CODE","INSPECTION TYPE","SCORE"]].dropna()
test = csv[200000:][["BORO","CRITICAL FLAG","GRADE","VIOLATION CODE","INSPECTION TYPE","SCORE"]].dropna()

# Build the train set
X_train = train.drop(columns=['SCORE'])
Y_train = train[["SCORE"]]

# Build the test set
X_test = test.drop(columns=['SCORE'])
Y_test = test[["SCORE"]]

# One Hot encode
x_train_hot = one_hot_dataframe(X_train, ["BORO","CRITICAL FLAG","GRADE","VIOLATION CODE"], replace=True)
x_test_hot = one_hot_dataframe(X_test, ["BORO","CRITICAL FLAG","GRADE","VIOLATION CODE"], replace=True)

x_train_data = x_train_hot[1].drop(columns=["VIOLATION CODE=06H"])
x_test_data = x_test_hot[1].drop(columns=['VIOLATION CODE=02E','VIOLATION CODE=04I'])

from sklearn import tree
clf = tree.DecisionTreeRegressor()
clf.fit(x_train_data, Y_train['SCORE'])
clf.score(x_test_data, Y_test['SCORE'])
# 67%

from sklearn.decomposition import PCA
pca = PCA(n_components=10)
pca = pca.fit(x_train_data, Y_train['SCORE'])
x_train_pca = pca.transform(x_train_data)
x_test_pca = pca.transform(x_test_data)

from sklearn import tree
clf = tree.DecisionTreeRegressor()
clf.fit(x_train_pca, Y_train['SCORE'])
clf.score(x_test_pca, Y_test['SCORE'])
# 67%
```

## What happens when using classifier instead of regression

Changing the bin-sizes dramatically influences the prediction score.

```python
bins = [-5, 15, 25,50,200]
Y_train_bins = pd.cut(Y_train['SCORE'], bins=bins, labels=bins[0:-1])
Y_test_bins =  pd.cut(Y_test['SCORE'], bins=bins, labels=bins[0:-1])

from sklearn.tree import DecisionTreeClassifier
clf = DecisionTreeClassifier()
clf.fit(x_train_pca, Y_train_bins)
clf.score(x_test_pca, Y_test_bins)
# 93.8%

import numpy as np
Y_rand_bins = pd.cut((np.random.random(Y_test_bins.shape)*100), bins=bins, labels=bins[0:-1])
clf.score(x_test_pca, Y_rand_bins)
# 10.7%
```
