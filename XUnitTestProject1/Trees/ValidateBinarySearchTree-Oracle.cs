using Xunit;
using FluentAssertions;

namespace XUnitTestProject1
{
  public class ValidateBinarySearchTree
  {
    [Fact]
    public void Test()
    {
      Node<int> root = new(10)
      {
        Left = new Node<int>(5),
        Right = new Node<int>(15)
      };
      root.Left.Left = new Node<int>(2);
      root.Left.Right = new Node<int>(5);
      root.Right.Left = new Node<int>(13);
      root.Right.Right = new Node<int>(22);
      root.Left.Left.Left = new Node<int>(1);
      root.Right.Left.Right = new Node<int>(14);
      Validate(root, int.MinValue, int.MaxValue).Should().Be(true);
    }
    /*left nodes must be less than parent node, 
     * right node must be equal or more than parent node, 
     * left,right nodes must be BST themselves
     *        10
     *    5       15
     *  2  5  13    22
     * 1        14
     * at 2nd level 5 node=> nodeValue<=node.rightnodevalue<10
     * at 2nd level 13 node=> 10<=node.leftnodevalue<nodeValue*/
    //O(N): Time complexity-where N is the number of nodes,
    //O(d): Space Complexity, where d is the depth
    bool Validate(Node<int> input, int minvalue, int maxvalue )
    {
      if (input == null)
      {
        return true;
      }
      if(input.Value<minvalue || input.Value >= maxvalue)
      {
        return false;
      }
      return (Validate(input.Left, minvalue, input.Value) &&
        Validate(input.Right, input.Value, maxvalue));
    }
  }
}
