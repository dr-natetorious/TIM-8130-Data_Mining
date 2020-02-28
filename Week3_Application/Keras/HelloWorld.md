# Keras Tutorial

## How do I install Keras within Notebooks

```bash
$ pip install keras

Collecting keras
Downloading https://files.pythonhosted.org/packages/ad/fd/6bfe87920d7f4fd475acd28500a42482b6b84479832bdc0fe9e589a60ceb/Keras-2.3.1-py2.py3-none-any.whl (377kB)
|████████████████████████████████| 378kB 4.3MB/s eta 0:00:01
Requirement already satisfied: numpy>=1.9.1 in /opt/conda/lib/python3.7/site-packages (from keras) (1.17.3)
Requirement already satisfied: pyyaml in /opt/conda/lib/python3.7/site-packages (from keras) (5.1.2)
Requirement already satisfied: six>=1.9.0 in /opt/conda/lib/python3.7/site-packages (from keras) (1.13.0)
Requirement already satisfied: keras-preprocessing>=1.0.5 in /opt/conda/lib/python3.7/site-packages (from keras) (1.1.0)
Requirement already satisfied: scipy>=0.14 in /opt/conda/lib/python3.7/site-packages (from keras) (1.3.2)
Requirement already satisfied: keras-applications>=1.0.6 in /opt/conda/lib/python3.7/site-packages (from keras) (1.0.8)
Requirement already satisfied: h5py in /opt/conda/lib/python3.7/site-packages (from keras) (2.9.0)
Installing collected packages: keras
Successfully installed keras-2.3.1
```

## How do I train first model

```python
# Read the OptionFile
spy = read_option_file('SPY.csv')
x_train, x_test, y_train, y_test = split_csv(spy, test_size=0.3)
print(x_train.shape)
print(x_test.shape)
print(y_train.shape)
print(y_test.shape)

# Define the model
from keras.models import Sequential
from keras.layers import Dense, Activation

model = Sequential([
    Dense(64, input_dim=10),
    Activation('relu'),
    GaussianNoise(0.5),
    Dense(1, kernel_initializer='normal')
])

model.compile(optimizer='adam', loss='mse')
history = model.fit(x_train, y_train, epochs=5, batch_size=128)

# Measure performance
score = model.evaluate(x_test, y_test)
# 96.8%
```

## How Do I Visualize results

```python
model.compile(optimizer='adam', loss='mse', metrics=['accuracy'])
history = model.fit(..., epocs=5, ...)
model.evaluate(...)

import matplotlib.pyplot as plt
for x in history.history:
    print("key: %s" % x)

# Plot training & validation accuracy values
plt.plot(history.history['accuracy'])
#plt.plot(history.history['val_accuracy'])
plt.title('Model accuracy')
plt.ylabel('Accuracy')
plt.xlabel('Epoch')
plt.legend(['Train', 'Test'], loc='upper left')
plt.show()

# Plot training & validation loss values
plt.plot(history.history['loss'])
#plt.plot(history.history['val_loss'])
plt.title('Model loss')
plt.ylabel('Loss')
plt.xlabel('Epoch')
plt.legend(['Train', 'Test'], loc='upper left')
plt.show()
```
