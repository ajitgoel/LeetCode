﻿using Xunit;
using FluentAssertions;
using System.Linq;

namespace XUnitTestProject1
{
  public class Node<T>
  {
    public Node(T data)
    {
      Data = data;
    }
    public T Data { get; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }
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
    public int[] GetBranchSums(Node<int> input)
    {
      int[] result = System.Array.Empty<int>();
      CalculateBranchSums(input, 0, ref result);
      return result;
    }
    void CalculateBranchSums(Node<int> input, int runningSum, ref int[] sums)
    {
      if (input == null)
      {  
        return;
      }
      var newRunningSum=runningSum+input.Data;
      if(input.Left==null && input.Right==null)
      {
        sums=sums.Append(newRunningSum).ToArray();
        return;
      }
      CalculateBranchSums(input.Left, newRunningSum,ref sums);
      CalculateBranchSums(input.Right, newRunningSum, ref sums);
    }
  }
}
