using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace Amazon
{
  public class NonBinaryTreeNode<T> where T : class
  {
    public NonBinaryTreeNode(T value)
    {
      Value = value;
      this.Children = new List<NonBinaryTreeNode<T>>();
    }
    public T Value { get; }
    public List<NonBinaryTreeNode<T>> Children { get; private set; }
    public void AddChild(NonBinaryTreeNode<T> value)
    {
      this.Children.Add(value);
    }
  }
  public class NonBinaryTreeNodeTest
  {
    public NonBinaryTreeNode<string> FindNode(NonBinaryTreeNode<string> parentNode, string value)
    {
      if (parentNode.Value == value)
      {
        return parentNode;
      }
      foreach (var child  in parentNode.Children)
      {
        var actualChild=FindNode(child, value);
        if (actualChild != null)
        {
          return actualChild;
        }
      }
      return null;
    }
    public int NoOfNodesUnderANode(NonBinaryTreeNode<string> parentNode, string value)
    {
      var nodeWithValue= FindNode(parentNode, value);
      if (nodeWithValue == null)
      {
        return -1;
      }
      var runningSum = 0;
      foreach (var child in nodeWithValue.Children)
      {
        runningSum = runningSum + 1+ NoOfNodesUnderANode(child, child.Value);
      }
      return runningSum;
    }
    /*                Alice
                  Bob       Erin
          Chuck
    David       Faith
    */
    [Fact]
    public void Test1()
    {
      #region set up tree
      var alice = new NonBinaryTreeNode<string>("Alice");
      var bob = new NonBinaryTreeNode<string>("Bob");
      var erin = new NonBinaryTreeNode<string>("Erin");
      var chuck= new NonBinaryTreeNode<string>("Chuck");
      var david= new NonBinaryTreeNode<string>("David");
      var faith= new NonBinaryTreeNode<string>("Faith");
      
      alice.AddChild(bob);
      alice.AddChild(erin);
      bob.AddChild(chuck);
      chuck.AddChild(david);
      chuck.AddChild(faith);
      #endregion

      NoOfNodesUnderANode(alice,"Alice").Should().Be(5);
      NoOfNodesUnderANode(alice,"Bob").Should().Be(3);
      NoOfNodesUnderANode(alice,"David").Should().Be(0);
      NoOfNodesUnderANode(alice, "Champa").Should().Be(-1);
    }
  }
}
