using System.Linq;
using Xunit;
using FluentAssertions;

namespace XUnitTestProject1.RecursionDynamicProgramming
{
  public class Hired_Com
  {
    [Fact]
    public void Test()
    {
      var result2 = Solution1(new long[] { 7,2,6,3});
      result2.Should().Be(7);
      var result1 = Solution1(new long[] { });
      result1.Should().Be(0);

      var result3 = Solution2(new long[] { 3,6,2,9,-1,10});
      result3.Should().Be("Left");
    }
    public static string Solution2(long[] arr)
    {
      if (arr?.Length == 0)
      {
        return "";
      }
      var elements=arr.Skip(0).Where(x => x != -1).ToList();
      var evenelementsSum=elements.Where((index, item)=>index%2==0).Sum();
      var oddelementsSum = elements.Where((index, item) => index % 2 != 0).Sum();
      if(oddelementsSum>evenelementsSum)
      {
        return "Right";
      }
      if (oddelementsSum < evenelementsSum)
      {
        return "Left";
      }
      else
      {
        return "Equal";
      }
    }
    public static long Solution1(long[] numbers)
    {
      if (numbers?.Length == 0)
      {
        return 0;
      }
      return numbers.Max();
    }
  }
}
