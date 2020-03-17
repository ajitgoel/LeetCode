using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{  
  public class ValidParentheses
  {
    [Fact]
    public void ValidParenthesesTest()
    {
      Assert.True(IsValid("()"));
      Assert.True(IsValid("()[]{}"));
      Assert.False(IsValid("(]"));
      Assert.False(IsValid("([)]"));
      Assert.True(IsValid("{[]}"));
    }
    public bool IsValid(string input)
    {
      if (string.IsNullOrWhiteSpace(input))
      {
        return true;
      }
      var stack = new Stack<char>();
      foreach (char character in input)
      {
        if (character.Equals('(') || character.Equals('[') || character.Equals('{'))
        {
          stack.Push(character);
        }
        else if (character.Equals(')') && (stack.Count <= 0 || stack.Pop() != '('))
        {
          return false;
        }
        else if (character.Equals(']') && (stack.Count <= 0 || stack.Pop() != '['))
        {
          return false;
        }
        else if (character.Equals('}') && (stack.Count <= 0 || stack.Pop() != '{'))
        {
          return false;
        }
      }
      return stack.Count <= 0;
    }
  }
}
