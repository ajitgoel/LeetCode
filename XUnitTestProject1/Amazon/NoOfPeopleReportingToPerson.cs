using Xunit;
using FluentAssertions;

namespace Amazon
{
  public class NoOfPeopleReportingToPerson
  {    
    /*                Alice
                  Bob       Erin
          Chuck
    David       Faith
    */
    [Fact]
    public void Test()
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
