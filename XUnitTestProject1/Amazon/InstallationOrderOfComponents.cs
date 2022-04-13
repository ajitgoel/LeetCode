using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace Amazon
{
  class Node
  {
    string destination;
    string source;
    public Node(string destination,string source)
    {
      this.destination=destination;
      this.source = source;
    }
  }
  class Graph
  {
    int nodes;
    LinkedList<Node>[] adjList;
    public Graph(int nodes)
    {
      this.nodes = nodes;
      this.adjList=new LinkedList<Node>[nodes];
      for (int i = 0; i < nodes; i++)
      {
        this.adjList[i] = new LinkedList<Node>();
      }
    }
    public void AddEdge(string source, string destination, List<string> softwares)
    {
      Node node = new Node(source, destination);
      this.adjList[softwares.IndexOf(source)].AddFirst(node);
    }
    public string[] TopologicalSorting(List<string> softwares)
    {
      bool[] visited = new bool[this.nodes];
      var stack = new Stack<string>();
      // visit from each node if not already visited
      for (int i = 0; i < this.nodes; i++)
      {
        if (!visited[i])
        {
          this.topologicalSortUtil(softwares[i], visited, stack, softwares);
        }
      }
      int size = stack.Count();
      var result = new string[size];
      for (int i = 0; i < size; i++)
      {
        result[i]=stack.Pop();
      }
      return result;
    }
    public void topologicalSortUtil(string sftwr, bool[] visited, Stack<string> stack, List<string> softwares)
    {
      int index = softwares.IndexOf(sftwr);
      visited[index] = true;
      for (int i = 0; i < this.adjList[softwares.IndexOf(sftwr)].Count(); i++)
      {
        //var linkedlist = this.adjList[index];
        //Node node = linkedlist.FirstOrDefault(x=>x.);

        //Node node = this.adjList[index].get(i);
        //if (!visited[softwares.IndexOf(node.destination)])
        {
          //this.topologicalSortUtil(node.Destination, visited, stack, softwares);
        }
      }
      stack.Push(sftwr);
    }
  }
  /*https://algorithms.tutorialhorizon.com/graph-software-installation-problem/
Software’s: A B C D E F
E depends on B, D
D depends on B, C
C depends on A
B depends on A
F no dependency
Output: F A B C D E*/
  public class InstallationOrderOfComponents
  {    
    [Fact]
    public void Test2()
    {
      List<string> softwares = new List<string>
      {
        "A",
        "B",
        "C",
        "D",
        "E",
        "F"
      };
      int vertices = softwares.Count();
      Graph graph = new Graph(vertices);
      graph.AddEdge("A", "B", softwares);
      graph.AddEdge("A", "C", softwares);
      graph.AddEdge("B", "D", softwares);
      graph.AddEdge("B", "E", softwares);
      graph.AddEdge("C", "D", softwares);
      graph.AddEdge("D", "E", softwares);
      graph.TopologicalSorting(softwares).Should().ContainInOrder(new string[] {"F","A","B","C","D","E"});
    }
  }
}
