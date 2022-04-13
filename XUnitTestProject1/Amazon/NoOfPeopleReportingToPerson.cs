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
    public void AddChildren(List<NonBinaryTreeNode<T>> values)
    {
      foreach (var value in values)
      {
        AddChild(value);
      }
    }
    public void AddChild(NonBinaryTreeNode<T> value)
    {
      this.Children.Add(value);
    }
    public static NonBinaryTreeNode<T> FindNode(NonBinaryTreeNode<T> parentNode, T value)
    {
      if (parentNode.Value == value)
      {
        return parentNode;
      }
      foreach (var child in parentNode.Children)
      {
        var actualChild = FindNode(child, value);
        if (actualChild != null)
        {
          return actualChild;
        }
      }
      return null;
    }
    public static int NoOfNodesUnderANode(NonBinaryTreeNode<T> parentNode, T value)
    {
      var nodeWithValue = FindNode(parentNode, value);
      if (nodeWithValue == null)
      {
        return -1;
      }
      var runningSum = 0;
      var stack = new Stack<NonBinaryTreeNode<T>>();
      foreach (var child in nodeWithValue.Children)
      {
        stack.Push(child);
        runningSum++;
        while (stack.Count > 0)
        {
          var currentNode = stack.Pop();
          foreach (var currentNodeChild in currentNode.Children)
          {
            stack.Push(currentNodeChild);
            runningSum++;
          }
        }
      }
      return runningSum;
    }
  }
  public class NonBinaryTreeNodeTest
  {    
    /*                Alice
                  Bob       Erin
          Chuck
    David       Faith
    */
    [Fact]
    public void Test2()
    {
      #region set up tree
      var alice = new NonBinaryTreeNode<string>("Alice");
      var bob = new NonBinaryTreeNode<string>("Bob");
      var erin = new NonBinaryTreeNode<string>("Erin");
      var chuck = new NonBinaryTreeNode<string>("Chuck");
      var david = new NonBinaryTreeNode<string>("David");
      var faith = new NonBinaryTreeNode<string>("Faith");

      alice.AddChild(bob);
      alice.AddChild(erin);
      bob.AddChild(chuck);
      chuck.AddChild(david);
      chuck.AddChild(faith);
      #endregion

      NonBinaryTreeNode<string>.NoOfNodesUnderANode(alice, "Alice").Should().Be(5);
      NonBinaryTreeNode<string>.NoOfNodesUnderANode(alice, "Bob").Should().Be(3);
      NonBinaryTreeNode<string>.NoOfNodesUnderANode(alice, "David").Should().Be(0);
      NonBinaryTreeNode<string>.NoOfNodesUnderANode(alice, "Champa").Should().Be(-1);
    }
  }
}
