using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
  public class IsPowerOfThreeTest
  {
    [Fact]
    public void Test()
    {
      Assert.True(IsPowerOfThree(27));
      Assert.False(IsPowerOfThree(0));
      Assert.True(IsPowerOfThree(9));
      Assert.False(IsPowerOfThree(45));
      Assert.True(IsPowerOfThree(1));
    }
    public bool IsPowerOfThree(int n)
    {
      if(n<1)
      {
        return false;
      }
      while(n%3 ==0)
      {
        n = n / 3;
      }
      var returnResult = (n==1);
      return returnResult;
    }
  }
}
