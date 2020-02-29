# Modern Information Theory

## Origin of Markov Chains (2014)

On [Khan Academy](https://www.khanacademy.org/computing/computer-science/informationtheory/moderninfotheory/v/markov_chains) they describe the origin of markov chains, as an evolutionary idea over the central limit theorm.  Previous theories suggested that _independent variables_ naturally converge to their expected ratio given sufficient examples.

Markov expanded on these ideas to propose that the same behavior is true for any closed state machine, where all states can be reached.  This means that even _dependent states_ can be efficiently modeled and should naturally converge.  Having such a mathmatical proof enables more complex interactions to be modeled such as population migrations and physical manifestations in the natural world.  That is critical because the world is _full of messy observations that depend on previous choices_ that rarely align with perfect independent states.

## Mathmatical Theory of Communication

Shannon extended these ideas to language by showing that given a random alphabet (e.g. A, B, and C) the sentence AAABABAAABABBACAB can be modeled as a Markov chain.  This process starts with an independent selection of 1/3 probability for each letter.  Next the n-gram considers the probability that 'A[B|C]' is more probable than e.g. C[B|A].  As the depth of the n-gram increases the structural output converges to the statistical structure of the arbitrary sentence.  Then he shows that using the statistical probabilities across English letters the generated words look almost real.  Increasing the n-gram depth to include words results in generated sentences that almost look normal.  Continuing the increase the depth even further would eventually converge into valid texts (per Markov chain proofs).

## Information entropy

> We have represented a discrete info9rmation source as a Markoff process.  Can we define a quanity which will measure in some sense, how much information is "produced" by such a process, or better, at what rate information is produced? [...] If there is such a measure, say `H(p1, p2, ... pn)`[...]

Shannon continues to describe entropy in terms of bits, where a bit is equal to the probability of flipping a fair coin.  Then he provides an analogy of a ball falling through a machine and at each junction has a 50/50 chance of going right or left.  Each junction would represent a single bit of entropy.  The total entropy (`H(...)`) is therefore equal to the `sum of probability i times bounce count to i`.  For instance, if an alphabet has letters (A,B,C,D) with equal probability, then it would take 2 questions on average to determine which random letter was next [(1) Is it AB? (2) Is it A or B].

This can be generalized into `H = sum( p[i] x log2(1/p[i]) )` is the probability of that simple appearing next.

## Compression Codes

Huffman provides an algorithm for compressing a random alphabet, by creating a binary tree from the bottom up.  Each iteration choose the least probable pair and creates a parent branch that is equal to the probability sum of its children.  Afterward, the path to a character equals the encoding and that tree is equal to the most efficient code page.  Shannon extended this to state that the length of the code path must be equal to the entropy, and any reduction beyond that is lossy.

## Error Coding

Hamming provides an algorithm for adding parity bits to datastreams, as a mechanism to automatically detect and correct errors.  These constructs continue to exist today in scenarios such as network transmissions and disk RAID technologies.  One of the challenges with adding parity bits is that it increases the size of the each datagram, which in turn decreases the rate of communication because the available bandwidth for more entropy has decreased.
