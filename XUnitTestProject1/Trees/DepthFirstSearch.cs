using Xunit;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;

namespace XUnitTestProject1
{
  public class DepthFirstSearch
  {
    /*      a
       b       c
     d   e       f
     [a, b, d, e, c, f]
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
      result1.Should().ContainInOrder(new string[] {"A", "B", "D", "E", "C", "F"});

      var result2 = Calculate_RecursiveApproach(root, new List<string>());
      result2.Should().ContainInOrder(new string[] { "A", "B", "D", "E", "C", "F" });
    }
    public string[] Calculate_RecursiveApproach(Node<string> input, List<string> result=null)
    {
      if (input == null)
      {
        return System.Array.Empty<string>();
      }
      var leftvalues=Calculate_RecursiveApproach(input.Left, result);
      var rightvalues = Calculate_RecursiveApproach(input.Right, result);
      result.Add(input.Value);
      result.AddRange(leftvalues);
      result.AddRange(rightvalues);
      return result.ToArray();
    }
    public string[] Calculate_IterativeApproach(Node<string> input)
    {
      if(input==null)
      {
        return System.Array.Empty<string>();
      }
      var result= new List<string>();
      var stack=new Stack<Node<string>>();
      stack.Push(input);
      while(stack.Count()>0)
      {
        var node=stack.Pop();
        result.Add(node.Value);
        if (node.Right != null)
        {
          stack.Push(node.Right);
        }
        if (node.Left != null)
        {
          stack.Push(node.Left);
        }
      }
      return result.ToArray();
    }
  }
}
