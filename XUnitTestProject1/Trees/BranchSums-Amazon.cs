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
  public class BranchSums
  {
    [Fact]
    public void Test()
    {
      Node<int> root = new(1)
      {
        Left = new Node<int>(2),
        Right = new Node<int>(3)
      };
      root.Left.Left = new Node<int>(4);
      root.Left.Right = new Node<int>(5);
      root.Right.Left = new Node<int>(6);
      root.Right.Right = new Node<int>(7);
      root.Left.Left.Left = new Node<int>(8);
      root.Left.Left.Right = new Node<int>(9);
      root.Left.Right.Left = new Node<int>(10);
      var result = GetBranchSums(root);
      //Result array should contain 15,16,18,10,11
      result.Should().Contain(15);
      result.Should().Contain(16);
      result.Should().Contain(18);
      result.Should().Contain(10);
      result.Should().Contain(11);
    }
    //O(N): Time complexity, O(N): Space Complexity
    /*              1
     *          2       3
     *      4     5   6   7
     *     8  9 10
     */ 
    public int[] GetBranchSums(Node<int> input)
    {
      var result = new List<int>();
      CalculateBranchSums(input, 0, result);
      return result.ToArray();
    }
    void CalculateBranchSums(Node<int> input, int runningSum, List<int> sums)
    {
      if (input == null)
      {  
        return;
      }
      var newRunningSum=runningSum+input.Value;
      if(input.Left==null && input.Right==null)
      {
        sums.Add(newRunningSum);
        return;
      }
      CalculateBranchSums(input.Left, newRunningSum,sums);
      CalculateBranchSums(input.Right, newRunningSum, sums);
    }
  }
}
