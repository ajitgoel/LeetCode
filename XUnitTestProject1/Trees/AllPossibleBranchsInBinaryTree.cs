using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using XUnitTestProject1;

namespace BinaryTree.Amazon
{
  public class AllPossibleBranchsInBinaryTree
  {
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
      root.Right.Left = new Node<string>("F");
      root.Right.Right = new Node<string>("G");
      var result = GetBranchSums(root);
      //Does not work, returns {"A", "AB", "ABD", "ABE", "AC", "ACF", "ACG"}, should return 
      //{ "AB", "BD", "BE", "AC", "CF", "CG", "ABD", "ABE", "ACF", "ACG"}
      result.Should().Contain(new string[] { "AB", "BD", "BE", "AC", "CF", "CG", "ABD", "ABE", "ACF", "ACG"});
    }
    //O(N): Time complexity, O(N): Space Complexity
    /*              A
     *          B        C
     *      D      E   F    G
     */ 
    public string[] GetBranchSums(Node<string> input)
    {
      var result = new List<string>();
      CalculateBranchSums(input, "", result);
      return result.ToArray();
    }
    void CalculateBranchSums(Node<string> input, string runningSum, List<string> runningListOfPaths)
    {
      if (input == null)
      {  
        return;
      }
      var newRunningSum=$"{runningSum}{input.Value}";
      runningListOfPaths.Add(newRunningSum);
      if (input.Left==null && input.Right==null)
      {
        return;
      }
      CalculateBranchSums(input.Left, newRunningSum, runningListOfPaths);
      CalculateBranchSums(input.Right, newRunningSum, runningListOfPaths);
    }
  }
}
