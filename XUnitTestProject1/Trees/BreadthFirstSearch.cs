using Xunit;
using FluentAssertions;
//using System.Linq;
using System.Collections.Generic;

namespace XUnitTestProject1
{
  public class BreadthFirstSearch
  {
    /*      a
       b       c
     d   e       f
     [a, b, c, d, e, f]
     O(N): Time complexity, O(N): Space Complexity*/
    [Fact]
    public void Test()
    {
      Node<string> root = new("A")
      {
        Left = new Node<string>("B"),
        Right = new Node<string>("C")
      };
      root.Left.Left = new Node<string>("D");
      root.Left.Right = new Node<string>("E");
      root.Right.Right = new Node<string>("F");
      var result1 = Calculate_IterativeApproach(root);
      result1.Should().ContainInOrder(new string[] {"A", "B", "C", "D", "E", "F" });
    }
    public string[] Calculate_IterativeApproach(Node<string> input)
    {
      if(input==null)
      {
        return System.Array.Empty<string>();
      }
      var result= new List<string>();
      var queue=new Queue<Node<string>>();
      queue.Enqueue(input);
      while(queue.Count>0)
      {
        var node= queue.Dequeue();
        result.Add(node.Value);
        if (node.Left != null)
        {
          queue.Enqueue(node.Left);
        }
        if (node.Right != null)
        {
          queue.Enqueue(node.Right);
        }
      }
      return result.ToArray();
    }
  }
}
