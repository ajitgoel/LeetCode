using Xunit;

namespace XUnitTestProject1
{  
  public class SumOfDigitsOfANumberUsingRecursion
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(6,Get(51));
      Assert.Equal(12, Get(156));
    }
    public int Get(int input)
    {
      if(input==0)
      {
        return 0;
      }
      var remainder=input % 10;
      var quotient = Get(input / 10);
      return remainder + quotient;
    }
  }
}
