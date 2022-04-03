using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace XUnitTestProject1.Graphs
{
  public class ShortestPathInGraph
  {
    //BFS: explore all directions evenly from a node
    //DFS: look in one possible direction before I have to switch directions
    [Fact]
    public void Test1()
    {
      var graph1 = new Graph();
      graph1.AddNodes(new string[] { "w", "x", "y", "z", "v" });
      graph1.AddAnEdge("w", "x");
      graph1.AddAnEdge("x", "y");
      graph1.AddAnEdge("z", "y");
      graph1.AddAnEdge("z", "v");
      graph1.AddAnEdge("w", "v");
      Calculate(graph1, "w", "z").Should().Be(2);
    }
    [Fact]
    public void Test2()
    {
      var graph2 = new Graph();
      graph2.AddNodes(new string[] { "w", "x", "y", "z", "v"});
      graph2.AddAnEdge("w", "x");
      graph2.AddAnEdge("x", "y");
      graph2.AddAnEdge("z", "y");
      graph2.AddAnEdge("z", "v");
      graph2.AddAnEdge("w", "v");
      Calculate(graph2, "y", "x").Should().Be(1);
    }
    [Fact]
    public void Test3()
    {
      var graph3 = new Graph();
      graph3.AddNodes(new string[] { "a", "b", "c", "d", "e", "f", "g" });
      graph3.AddAnEdge("a", "c");
      graph3.AddAnEdge("a", "b");
      graph3.AddAnEdge("c", "b");
      graph3.AddAnEdge("c", "d");
      graph3.AddAnEdge("b", "d");
      graph3.AddAnEdge("e", "d");
      graph3.AddAnEdge("g", "f");
      Calculate(graph3, "a", "e").Should().Be(3);
      Calculate(graph3, "e", "c").Should().Be(2);
      Calculate(graph3, "b", "g").Should().Be(-1);
    }
    [Fact]
    public void Test4()
    {
      var graph = new Graph();
      graph.AddNodes(new string[] { "c", "n", "e", "s", "w", "e"});
      graph.AddAnEdge("c", "n");
      graph.AddAnEdge("c", "e");
      graph.AddAnEdge("c", "s");
      graph.AddAnEdge("c", "w");
      graph.AddAnEdge("c", "e");
      graph.AddAnEdge("w", "e");
      Calculate(graph, "w", "e").Should().Be(1);
      Calculate(graph, "n", "e").Should().Be(2);
    }
    [Fact]
    public void Test5()
    {
      var graph = new Graph();
      graph.AddNodes(new string[] { "m", "n", "o", "p", "q", "t","r", "s"});
      graph.AddAnEdge("m", "n");
      graph.AddAnEdge("n", "o");
      graph.AddAnEdge("o", "p");
      graph.AddAnEdge("p", "q");
      graph.AddAnEdge("t", "o");
      graph.AddAnEdge("r", "q");
      graph.AddAnEdge("r", "s");
      Calculate(graph, "m", "s").Should().Be(6);
    }
    /*Write a function, shortestPath, that takes in an array of edges for an undirected graph and two nodes (nodeA, nodeB). 
     * The function should return the length of the shortest path between A and B. 
     * Consider the length as the number of edges in the path, not the number of nodes. If there is no path between A and B, then return -1.*/
    public int Calculate(Graph graph, string nodefrom, string nodeto)
    {
      var visitedNodes = new HashSet<string>();
      var queue = new Queue<(string, int)>();
      queue.Enqueue((nodefrom, 0));
      while(queue.Count>0)
      {
        var item=queue.Dequeue();
        if(item.Item1==nodeto)
        {
          return item.Item2;
        }
        var neighbours=graph.Neighbours(item.Item1);
        foreach (var neighbour in neighbours)
        {
          if(visitedNodes.Contains(neighbour)==false)
          {
            visitedNodes.Add(neighbour);
            queue.Enqueue((neighbour, item.Item2+1));
          }
        }
      }
      return -1;
    }
  }
}
