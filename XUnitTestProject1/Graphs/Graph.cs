using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace XUnitTestProject1.Graphs
{
  public class UnitTest
  {
    [Fact]
    public void Test1()
    {
      // Undirected Graph
      /**
       *                  Chicago
       *                  |     \
       *                  |      \
       *              Dallas    Atlanta
       *                  |         \
       *                  |          \
       *           San Francisco----Orlando
       *                   \        /
       *                    \     /
       *                   Las Vegas
       * **/
      var graph = new Graph();
      graph.AddNode("Chicago");
      graph.AddNode("Dallas");
      graph.AddNode("Atlanta");
      graph.AddNode("San Francisco");
      graph.AddNode("Orlando");
      graph.AddNode("Las Vegas");

      graph.AddAnEdge("Chicago", "Dallas");
      graph.AddAnEdge("Chicago", "Atlanta");
      graph.AddAnEdge("Dallas", "San Francisco");
      graph.AddAnEdge("Atlanta", "Orlando");
      graph.AddAnEdge("San Francisco", "Orlando");
      graph.AddAnEdge("San Francisco", "Las Vegas");
      graph.AddAnEdge("Orlando", "Las Vegas");
      graph.DFSRecursive("Chicago").Should().
        ContainInOrder(new string[] { "Chicago", "Dallas", "San Francisco", "Orlando", "Atlanta", "Las Vegas" });
      graph.DFSIterative("Chicago").Should().
        ContainInOrder(new string[] { "Chicago", "Atlanta", "Orlando", "Las Vegas", "San Francisco", "Dallas" });
      graph.BFSTraversal("Chicago").Should().
        ContainInOrder(new string[] { "Chicago", "Dallas", "Atlanta", "San Francisco", "Orlando", "Las Vegas" });
    }
  }

  public class Graph
  {
    public List<Node> AdjacencyList { get; set; }
    public Graph()
    {
      AdjacencyList = new List<Node>();
    }
    public string[] Neighbours(string node)
    {
      return AdjacencyList.Where(x => x.Name == node).SelectMany(x => x.Edges).ToArray();
    }
    public void AddNodes(string[] newNodes)
    {
      foreach (var item in newNodes)
      {
        AddNode(item);
      }
    }
    public bool AddNode(string newNode)
    {
      // We will keep the implementation simple and focus on the concepts
      // Ignore duplicate vertices.
      if (AdjacencyList.Find(v => v.Name == newNode) != null) return true;
      // Add vertex to the graph
      AdjacencyList.Add(new Node(newNode));
      return true;
    }
    /// Adds a new edge between two given nodes in the graph
    public bool AddAnEdge(string v1, string v2)
    {
      // We will keep the implementation simple and focus on the concepts
      // Do not worry about handling invalid indexes or any other error cases.
      // We will assume all vertices are valid and already exist.
      // Add vertex v2 to the edges of vertex v1
      AdjacencyList.Find(v => v.Name == v1).Edges.Add(v2);
      // Add vertex v1 to the edges of vertex v2
      AdjacencyList.Find(v => v.Name == v2).Edges.Add(v1);
      return true;
    }
    /// Removes an edge between two given nodes in the graph
    public bool RemoveAnEdge(string v1, string v2)
    {
      // We will keep the implementation simple and focus on the concepts
      // Do not worry about handling invalid indexes or any other error cases.
      // We will assume all vertices are valid and already exist.
      // Remove vertex v2 to the edges of vertex v1
      AdjacencyList.Find(v => v.Name == v1).Edges.Remove(v2);
      // Remove vertex v1 to the edges of vertex v2
      AdjacencyList.Find(v => v.Name == v2).Edges.Remove(v1);
      return true;
    }
    #region " DFS Traversal "
    /// <summary>
    /// Recursively traverse the graph and return an array of vertex names
    /// </summary>
    /// <param name="startVertex">Name for the starting vertex from where the traversal should start.</param>
    /// <returns>Returns array of strings</returns>
    public List<string> DFSRecursive(string startVertex)
    {
      var startNode = AdjacencyList.Find(v => v.Name == startVertex);
      if (startNode == null) return null;
      // List to keep track of the result
      var result = new List<string>();
      // Lookup for keep track of visited nodes
      var visited = new HashSet<string>();
      DFSR(startNode, result, visited);
      return result;
    }
    private void DFSR(Node startVertex, List<string> result, HashSet<string> visited)
    {
      if (startVertex == null || visited.Contains(startVertex.Name)) return;      
      result.Add(startVertex.Name);//Add the vertex to the visited list      
      visited.Add(startVertex.Name);// Mark the vertex as visited
      // Traverse through the neighbors of the vertex
      foreach (var neighbor in startVertex.Edges)
      {
        // If the neighbor vertex is not visited already, perform DFS on the neighbor vertex
        if (!visited.Contains(neighbor))
        {
          DFSR(AdjacencyList.Find(v => v.Name == neighbor), result, visited);
        }
      }
    }
    /// Iteratively traverse the graph and return an array of vertex names
    /// <param name="startVertex">Name for the starting vertex from where the traversal should start.</param>
    /// <returns>Returns array of strings</returns>
    public List<string> DFSIterative(string startVertex)
    {
      Node start = AdjacencyList.Find(v => v.Name == startVertex);
      if (start == null) return null;
      List<string> result = new List<string>();
      HashSet<string> visited = new HashSet<string>();
      Stack<Node> stack = new Stack<Node>();
      stack.Push(start);
      while (stack.Count > 0)
      {
        var current = stack.Pop();
        if (visited.Contains(current.Name)) continue;
        result.Add(current.Name);
        visited.Add(current.Name);
        foreach (var neighbor in current.Edges)
        {
          if (!visited.Contains(neighbor))
          {
            stack.Push(AdjacencyList.Find(v => v.Name == neighbor));
          }
        }
      }
      return result;
    }
    #endregion
    /// Iteratively traverse the graph and return an array of vertex names
    /// <param name="startVertex">Name for the starting vertex from where the traversal should start.</param>
    /// <returns>Returns array of strings</returns>
    public List<string> BFSTraversal(string startVertex)
    {
      Node start = AdjacencyList.Find(v => v.Name == startVertex);
      if (start == null) return null;
      List<string> result = new List<string>();
      HashSet<string> visited = new HashSet<string>();
      Queue<Node> queue = new Queue<Node>();
      queue.Enqueue(start);
      while (queue.Count > 0)
      {
        var current = queue.Dequeue();
        // If current vertex is already visited, move to the next vertex in the queue
        if (visited.Contains(current.Name)) continue;
        result.Add(current.Name);
        visited.Add(current.Name);
        foreach (var neighbor in current.Edges)
        {
          if (!visited.Contains(neighbor))
          {
            queue.Enqueue(AdjacencyList.Find(v => v.Name == neighbor));
          }
        }
      }
      return result;
    }
  }
  public class Node
  {
    public string Name { get; set; }
    public List<string> Edges { get; set; }
    public Node(string name)
    {
      this.Name = name;
      this.Edges = new List<string>();
    }
  }
}
