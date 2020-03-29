using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{  
  public class ValidParentheses
  {
    [Fact]
    public void ValidParenthesesTest()
    {
      Assert.Equal(true,IsValid("()"));
      Assert.Equal(true, IsValid("()[]{}"));
      Assert.Equal(false, IsValid("(]"));
      Assert.Equal(false, IsValid("([)]"));
      Assert.Equal(true, IsValid("{[]}"));
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
        else if (character.Equals(')'))
        {
          if(stack.Count > 0 && stack.Pop() == '(')
          {
          }
          else
          {
            return false;
          }
        }
        else if (character.Equals(']'))
        {
          if (stack.Count > 0 && stack.Pop() == '[')
          {
          }
          else
          {
            return false;
          }
        }
        else if (character.Equals('}'))
        {
          if (stack.Count > 0 && stack.Pop() == '{')
          {
          }
          else
          {
            return false;
          }
        }
      }
      return stack.Count <= 0;
    }
  }
}
