using System;
using System.Collections.Generic;
using System.Linq;

class HashRing
{
    private Dictionary<int, string> ring = new Dictionary<int, string>();
    private SortedSet<int> sortedKeys = new SortedSet<int>();
    private int replicas;

    private int GetHash(string value)
    {
        return value.GetHashCode();
    }

    public HashRing(int replicas = 5)
    {
        this.replicas = replicas;
    }

    public void AddNode(string node)
    {
        for (int i = 0; i < replicas; ++i)
        {
            int replicaKey = GetHash(node + "_" + i);
            ring[replicaKey] = node;
            sortedKeys.Add(replicaKey);
        }
    }

    public void RemoveNode(string node)
    {
        for (int i = 0; i < replicas; ++i)
        {
            int replicaKey = GetHash(node + "_" + i);
            ring.Remove(replicaKey);
            sortedKeys.Remove(replicaKey);
        }
    }

    public string GetNode(string key)
    {
        if (ring.Count == 0)
        {
            return "";
        }

        int hashValue = GetHash(key);
        var it = sortedKeys.FirstOrDefault(k => k >= hashValue); //use LINQ instead for clear code

        if (it == default(int))
        {
            it = sortedKeys.First();
        }

        return ring[it];
    }
}

class Program
{
    static void Main(string[] args)
    {
        HashRing hashRing = new HashRing();

        hashRing.AddNode("Node_A");
        hashRing.AddNode("Node_B");
        hashRing.AddNode("Node_C");

        string key = "first key";
        string node = hashRing.GetNode(key);

        Console.WriteLine("The key '{0}' is mapped to node: {1}", key, node);
    }
}
