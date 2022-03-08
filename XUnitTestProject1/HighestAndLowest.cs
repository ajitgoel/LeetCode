using Xunit;
using System.Linq;
using System;

namespace XUnitTestProject1
{
  public class HighestAndLowestClass
  {
    [Fact]
    public void Test()
    {
      Assert.Equal("42 -9", HighestAndLowest("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
      Assert.Equal("3 1", HighestAndLowest("1 2 3"));
    }
    public static string HighestAndLowest(string numbers)
    {
      if(string.IsNullOrEmpty(numbers))
      {
        throw new System.Exception("Invalid input");
      }
      var array = numbers.Split(new char[] { ' '});
      var array1=array.Select(x=>Convert.ToInt32(x)).OrderByDescending(x=>x).ToList();
      return ($"{array1.FirstOrDefault()} {array1.LastOrDefault()}");
    }

  }
}
