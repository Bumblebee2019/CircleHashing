# Consistent Hashing POC

Consistent hashing is a technique used to distribute data efficiently across many servers. I became curious about this process, and decided to create a simple hashing model. 

## Language-specific code
Most articles I read on the topic use C++ as the language of choice, but I wanted to challenge myself and write my example in C#. I researched a language-specific function GetHashCode() for the hashing algorithm itself. Since I am familiar with the most common hash functions like MD5, SHA-1, and SHA-256, it was interesting to learn the inner-workings of the GetHashCode() and determine what algorithm it uses. The function utilizes different hashing algorithms, depending on the object. For instance, for working with strings, it may use a DJB2 algorithm, but even more importantly, the user can specify what algorithm to use. If the user wants to use SHA-256, he can specify "using (SHA256 sha256 = SHA256.Create())" inside the GetHashCode() function. This functionality is provided in the System.Security.Cryptography library.

## Design choices 
Q: Why a hash ring? 

A: Consistent hashing allows for **scalability** . When we add/remove nodes, consistent hashing minimizes data movement. This method also helps with **load balancing** which is crucial for efficient utilization of resources. Also, consistent hahsing helps with the process of **database sharding** because when we assign key to a node, we can determine which node corresponds to which piece of data


Q: So, you've created this model as a POC, but how is it actually used in the industry?

A: Distributed databases, like Cassandra use consistent hashing to ensure **high availability** and **fault tolerance**. Also, caching systems, like DynamoDB use consistent hashing to ensure that data is **evenly distributed**.



