using Xunit;
using FluentAssertions;

namespace Amazon
{  
  public class ReverseString
  {
    [Fact]
    public void Test()
    {
      CalculateUsingRecursion("ABC").Should().Be("CBA");
    }
    public static string CalculateUsingRecursion(string input)
    {
      if(input.Length<2)
      {
        return input;
      }
      return CalculateUsingRecursion(input.Substring(1, input.Length-1)) + input[0];
    }
  }
}
