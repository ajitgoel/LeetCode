using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{  
  public class InsertTextInValidParentheses
  {
    [Fact]
    public void Test()
    {
      Assert.Equal("", Do("(]"));
      Assert.Equal("", Do("([)]"));
      
      Assert.Equal("(Valid)", Do("()"));
      Assert.Equal("()[Valid]{}", Do("()[]{}"));
      Assert.Equal("{[Valid]}", Do("{[]}"));
    }
    public string Do(string input)
    {
      if (string.IsNullOrWhiteSpace(input) || input.Length%2!=0)
      {
        return "";
      }
      var stack = new Stack<char>();
      for (int counter=0;counter<input.Length;counter++)
      {
        char character = input[counter];
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
            return "";
          }
        }
        else if (character.Equals(']'))
        {
          if (stack.Count > 0 && stack.Pop() == '[')
          {
          }
          else
          {
            return "";
          }
        }
        else if (character.Equals('}'))
        {
          if (stack.Count > 0 && stack.Pop() == '{')
          {
          }
          else
          {
            return "";
          }
        }
      }
      if (stack.Count == 0)
      {
        return input.Insert(input.Length / 2, "Valid"); 
      }
      return "";
    }
  }
}
