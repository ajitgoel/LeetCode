using FluentAssertions;
using Xunit;

namespace XUnitTestProject1
{
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
