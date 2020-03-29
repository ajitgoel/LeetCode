using Xunit;

namespace XUnitTestProject1
{  
  public class Palindrome
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(true, Get(636));
    }
    public bool Get(int input)
    {
      int invertedInput=0;
      int remainder;
      int tempInput = input;
      while (tempInput > 0)
      {
        remainder = tempInput % 10;
        invertedInput = (invertedInput * 10) + remainder;
        tempInput = tempInput / 10;
      }
      return (input == invertedInput);
      /*
      636/10=63, 6
      63/10=6, 3
      6/10=0  6
      */
    }
  }
}
