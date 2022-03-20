using FluentAssertions;
using Xunit;

namespace XUnitTestProject1
{
  public class stringfunction
  {
    [Fact]
    public void Test1()
    {
      solution("aabbb").Should().Be(true);
      solution("ba").Should().Be(false);
      solution("aaa").Should().Be(true);
      solution("b").Should().Be(true);
      solution("abba").Should().Be(false);
    }
    public bool solution(string input)
    {
      if(input.Length==1 && input[0]=='b')
      {
        return true;
      }
      for(var counter=0;counter<input.Length-1;counter++)
      {
        if ((input[counter] == 'a' && input[counter + 1] == 'a') || (input[counter] == 'a' && input[counter + 1] == 'b') || (input[counter] == 'b' && input[counter + 1] == 'b'))
        {
          continue;
        }
        else
        {
          return false;
        }
      }
      return true;
    }
  }

  public class SymmetryPointOfString
  {
    [Fact]
    public void Test1()
    {
      solution("racecar").Should().Be(3);
      solution("x").Should().Be(-1);
      solution(" ").Should().Be(-1);
    }
    public int solution(string input)
    {
      input= input.Trim();
      if (input.Length == 0)
      {
        return 0;
      }
      if (input.Length == 1 || input.Length % 2 == 0)
      {
        return -1;
      }
      var counter = 0;
      while (counter < (input.Length - 1) / 2)
      {
        var indextocheck = input.Length-1-counter;
        if (input[counter]==input[indextocheck])
        {
          counter++;
          continue;
        }
        return -1;
      }
      return counter;
    }
  }
}
