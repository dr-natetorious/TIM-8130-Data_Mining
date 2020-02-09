# Machine Learning .net

## Machine Learning at Microsoft with ML.NET (2019)

At _International Conference on Knowledge Discovery and Data Mining_; [Zeehan et al](MachineLearning_at_Microsoft.pdf) state that is difficult to introduce machine learning strategies into production systems, because the tooling relies on non-standard interfaces (required input-schemas), programming languages that differ from developer norms (e.g., dynamic typing of python), etc.  Even common toolkits like `Scikit` are challenging to scale as the hosted environment lacks hardware acceleration and native parallelism primitives.

ML.net addresses these issues with three design goals: unification, extensibility, and scalability.  The framework revolves around an `MLContext` that binds managed objects into a `DataView` that can be distributed across multiple nodes and is not limited to the size of RAM.  The library supports 40 different models and 80 featurizers to cover most common use cases.  There is also support for interop with scikit pipeline interface (NimbusML), so tooling can interweave where ML.net is faster or Python interface supports missing functionality.

There is no public support for neural networks, as they instead defer to open source connectors that are more relevant to the general public.
