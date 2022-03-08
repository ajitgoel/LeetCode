using Xunit;
using System;

namespace XUnitTestProject1
{
  public class CountOfSubStringsThatAreDivisibleByKClass
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(3, CountOfSubStringsThatAreDivisibleByK("33445", 11));
    }
    static int CountOfSubStringsThatAreDivisibleByK(string str, int k)
    {
      int count = 0;
      for (int i = 0; i < str.Length; i++)
      {
        for (int j = i; j < str.Length; j++)// Take all sub-strings starting from i
        {
          if (Convert.ToInt32(str[i..(j+1)]) % k == 0)// If current sub-string is divisible by k
            count++;
        }
      }
      return count;
    }
  }
}
