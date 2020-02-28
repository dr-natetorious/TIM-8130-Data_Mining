# Keras Convolution2D Networks

The goal of on CNN is to perform deep learning on images of `Width x Height x Channels`.

## How do I load the example dataset

```python
from keras.datasets import fashion_mnist
(x_train,y_train), (x_test, y_test) = fashion_mnist.load_data()
```

The fashion image set is 60000 x (28 x 28 images) in greyscale, so the build function needs to be called as

```python
width=28
height=28
depth=1
classes=10

# define the model
model = build(width=width,height=height, depth=depth, classes=classes)

# reshape into include depth suffix
x_train = x_train.reshape((x_train.shape[0], width,height,depth))
x_test = x_test.reshape((x_test.shape[0], width,height,depth))

# onehot encode the y-predicts
y_train = np_utils.to_categorical(y_train, 10)
y_test = np_utils.to_categorical(y_test, 10)
labelNames = ["top", "trouser", "pullover", "dress", "coat","sandal", "shirt", "sneaker", "bag", "ankle boot"]
```

## How does the model build function work

```python
from keras.models import Sequential
from keras.layers import *

def build(width, height, depth, classes):
    model = Sequential()
    inputShape = (height, width, depth)
    chanDim = -1
```

This segment was stolen from [Rosebrock (2019)](https://www.pyimagesearch.com/2019/02/11/fashion-mnist-with-keras-and-deep-learning/).  The commented out portions do not appear to influence the accuracy.

> It's almost become a trend now to have a Conv2D followed by a ReLu followed by a BatchNormalization layer

- The `Activation` relu appears to be a common prelog to NN-chunks
- The `BatchNormalize` appears to be a common prelog to NN-chunks
- The `MaxPooling2D` is a way to reduce the number of parameters in our model by sliding a 2x2 pooling filter across the previous layer and taking the max of the 4 values in the 2x2 filter.
- The `Dropout` appears as common epilog to NN-chunks

```python
    model.add(Conv2D(32, (3, 3), padding="same",input_shape=inputShape))
    model.add(Activation("relu"))
    model.add(BatchNormalization(axis=chanDim))
```

It's not immediately clear the goal of this segment as it does not appear to improve accuracy.  My guess is that they are trying to leverage the MaxPool to reduce from 784 features to 196 (divide by 2*2).  Then normalize so a second MaxPool to divide by 4 again into 49 features.  These images are relatively small though this performance improvement could be significant on larger or full resolution images.

```python
    model.add(Conv2D(32, (3, 3), padding="same"))
    model.add(Activation("relu"))
    model.add(BatchNormalization(axis=chanDim))
    model.add(MaxPooling2D(pool_size=(2, 2)))
    model.add(Dropout(0.25))

    # second CONV => RELU => CONV => RELU => POOL layer set
    model.add(Conv2D(64, (3, 3), padding="same"))
    model.add(Activation("relu"))
    model.add(BatchNormalization(axis=chanDim))
    model.add(Conv2D(64, (3, 3), padding="same"))
    model.add(Activation("relu"))
    model.add(BatchNormalization(axis=chanDim))
    model.add(MaxPooling2D(pool_size=(2, 2)))
    model.add(Dropout(0.25))
```

This segment is required for the `model.fit` to initialize or there is an error that the dimensions do not align.

- The `Flatten()` function converts the input back into a linear array of 784 (28*28) floats
- The `BatchNormalization` needs to appear here as we're transitioning between [linear and non-linear layers](https://stackoverflow.com/questions/34716454/where-do-i-call-the-batchnormalization-function-in-keras).
- The Dense/Activation/../Dropout appear to be standard prolog/epilog constructs (removing them does not impact accuracy)

```python
    # first (and only) set of FC => RELU layers
    model.add(Flatten())
    model.add(Dense(512))
    model.add(Activation("relu"))
    model.add(BatchNormalization())
    model.add(Dropout(0.5))
```

The final activation drastically influences results:

- `softmax`(80%)
- `tanh`(20%)
- `sigmoid` (80%)

```python
    # softmax classifier
    model.add(Dense(classes))
    model.add(Activation("softmax"))

    # return the constructed network architecture
    return model


model = build(28,28, 1, 10)
model.compile(optimizer='adam', loss='mse', metrics=['accuracy'])

x_train_shaped = x_train.reshape((x_train.shape[0], 28,28,1))
x_test_shaped = x_test.reshape((x_test.shape[0], 28,28,1))

y_train_shaped = np_utils.to_categorical(y_train, 10)
y_test_shaped = np_utils.to_categorical(y_test, 10)
labelNames = ["top", "trouser", "pullover", "dress", "coat","sandal", "shirt", "sneaker", "bag", "ankle boot"]


history = model.fit(x_train_shaped, y_train_shaped, epochs=1, batch_size=128)
score = model.evaluate(x_test_shaped, y_test_shaped)
score
```
