using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using XUnitTestProject1;

namespace BinaryTree.Amazon
{
  public class EachBranchSum
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
      result.Should().Contain(new int[] { 15, 16, 18, 10, 11 });
    }
    //O(N): Time complexity, O(N): Space Complexity
    /*              1
     *          2        3
     *      4      5   6   7
     *    8   9 10
     */ 
    public int[] GetBranchSums(Node<int> input)
    {
      var result = new List<int>();
      Calculate(input, 0, result);
      return result.ToArray();
    }
    void Calculate(Node<int> input, int runningSum, List<int> sums)
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
      Calculate(input.Left, newRunningSum,sums);
      Calculate(input.Right, newRunningSum, sums);
    }
  }
}
