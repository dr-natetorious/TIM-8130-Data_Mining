# Processing Financial Data

## How do I process an options file

```python
def read_option_file(fileName):
    import pandas as pd
    import math

    csv = pd.read_csv(fileName,
                    names=['UnderlyingSymbol','UnderlyingPrice','Exchange',
                        'OptionSymbol','OptionExt','Type','Expiration',
                        'DataDate','Strike','Last','Bid','Ask','Volume',
                        'OpenInterest','IV','Delta','Gamma','Theta','Vega','AKA'])

    # Remove the exchange columns...
    csv = csv.drop(columns=['Exchange','OptionExt','AKA'])

    # Parse the date columns into datetimes...
    csv['Expiration'] = pd.to_datetime(csv['Expiration'])
    csv['DataDate'] = pd.to_datetime(csv['DataDate'])
    csv['TimeRemaining'] = (csv['Expiration'] - csv['DataDate']).dt.days

    # Tag the quality of the option
    bins = [0, 0.16, 0.32, 0.64, 1]
    moneynes = pd.cut(x=abs(csv.Delta), bins=bins, labels=['OTM','NTM','ATM','ITM'])
    csv['ITM'] = moneynes == 'ITM'
    csv['NTM'] = moneynes == 'NTM'
    csv['ATM'] = moneynes == 'ATM'
    csv['OTM'] = moneynes == 'OTM'


    # OneHotEncode the Type property
    csv['IsCall'] = csv['Type'] == 'call'
    csv['IsPut'] = csv['Type'] == 'put'
    csv = csv.drop(columns=['Type'])

    # Filter out no/bid records...
    csv = csv[(csv.Bid>0) & (csv.OpenInterest >0)]

    # Sort the values
    csv = csv.sort_values(by=['Expiration','DataDate','Strike'])
    return csv
```

## How can I split test/training data

```python
def split_csv(csv, test_size):
    '''
    Split the dataframe based on a ratio between 0 to 1
    '''

    x_data = csv[['IV','Delta','Gamma','Theta','Vega',
              'TimeRemaining','IsCall','IsPut',
              'OTM','NTM','ATM','NTM']]
    midprice = (csv['Bid']+csv['Ask'])/2
    #ratio = csv['UnderlyingPrice']/csv['Strike']
    y_data = midprice

    from sklearn.model_selection import train_test_split
    x_train, x_test, y_train, y_test = train_test_split(x_data, y_data, test_size=test_size, random_state=42)

    from sklearn.preprocessing import StandardScaler
    scaler = StandardScaler().fit(x_train)
    x_train = scaler.transform(x_train)
    x_test = scaler.transform(x_test)

    return x_train, x_test, y_train, y_test

spy = read_option_file('SPY.csv')
for test_size in [0.1, 0.2, 0.4, 0.6, 0.8, 0.9]:
    # Split the datasets
    x_train, x_test, y_train, y_test = split_csv(spy, test_size)

    # Train the model
    from sklearn.tree import DecisionTreeRegressor
    clf = DecisionTreeRegressor().fit(x_train, y_train)
    print("test_size: %f - score: %f" % (test_size, clf.score(x_test, y_test)))

# Output:
#test_size: 0.100000 - score: 0.975440
#test_size: 0.200000 - score: 0.975177
#test_size: 0.400000 - score: 0.969589
#test_size: 0.600000 - score: 0.961804
#test_size: 0.800000 - score: 0.941840
#test_size: 0.900000 - score: 0.921469
```

## Making the model more portable

```python
def split_csv(csv, test_size):
    x_data = csv[['IV','Delta','Gamma','Theta','Vega',
              'TimeRemaining','IsCall','IsPut']]

    # Calculate the y_predict
    midprice = (csv['Bid']+csv['Ask'])/2
    notional = csv['UnderlyingPrice'] * csv['Delta']

    y_data = midprice / csv['UnderlyingPrice']

    from sklearn.model_selection import train_test_split
    x_train, x_test, y_train, y_test = train_test_split(x_data, y_data, test_size=test_size, random_state=42)

    from sklearn.preprocessing import StandardScaler
    scaler = StandardScaler().fit(x_train)
    x_train = scaler.transform(x_train)
    x_test = scaler.transform(x_test)

    return x_train, x_test, y_train, y_test


# Split the datasets
x_train, x_test, y_train, y_test = split_csv(spy, test_size=0.7)

# Train the model
from sklearn.tree import DecisionTreeRegressor
clf = DecisionTreeRegressor().fit(x_train, y_train)
clf.score(x_test, y_test)
# 97.9%

# Load a different dataset
iwm = read_option_file("IWM.csv")
x_train, x_test, y_train, y_test = split_csv(iwm, test_size=0.7)

# Train the model
clf.score(x_test, y_test)
# 65%
```

## What if we include different symbols in this test

```python
spy = read_option_file('SPY.csv')
tlt = read_option_file('TLT.csv')

concat = pd.concat([spy, tlt], ignore_index=True)
x_train, x_test, y_train, y_test = split_csv(spy, test_size=0.7)

# Train the model
from sklearn.tree import DecisionTreeRegressor
clf = DecisionTreeRegressor().fit(x_train, y_train)
clf.score(x_test, y_test)
# 98.7%

qqq = read_option_file('QQQ.csv')
x_train, x_test, y_train, y_test = split_csv(qqq, test_size=0.3)
clf.score(x_test, y_test)
# 78.5%

baba = read_option_file('BABA.csv')
x_train, x_test, y_train, y_test = split_csv(baba, test_size=0.3)
clf.score(x_test, y_test)
# 64.9%
```
