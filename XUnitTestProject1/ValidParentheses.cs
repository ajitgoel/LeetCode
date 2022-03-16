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
    public static bool IsValid(string input)
    {
      var openingbrackets = "[{(";
      var closingbrackets = "}])";
      var dictionary = new Dictionary<char, char>() { { ']', '[' }, { '}', '{' }, { ')', '(' } };
      var stack = new Stack<char>();
      foreach (char counter in input)
      {
        if (openingbrackets.Contains(counter))
        {
          stack.Push(counter);
        }
        else if (closingbrackets.Contains(counter))
        {
          if (stack.Count == 0)
          {
            return false;
          }
          if (stack.Peek() == dictionary[counter])
          {
            stack.Pop();
          }
          else
          {
            return false;
          }
        }
      }
      return stack.Count == 0;
    }
  }
}