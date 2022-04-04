using Xunit;
using System.Collections.Generic;

namespace XUnitTestProject1
{  
  public class FibonacciSeries
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(0, Get(0));
      Assert.Equal(1, Get(1));
      Assert.Equal(1, Get(2));
      Assert.Equal(2, Get(3));
      Assert.Equal(3, Get(4));
      Assert.Equal(5, Get(5));
      Assert.Equal(8, Get(6));
      Assert.Equal(13, Get(7));
    }
    public int Get(int input)
    {
      return Get2(input, new List<int>());
    }      
    /*The next number is found by adding up the two numbers before it.
    * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34*/
    private int Get2(int input, List<int> cache)
    {
      if(cache.Exists(x=>x==input))
      {
        return input;
      }
      if(input==0  || input == 1)
      {
        return input;
      }
      var output= Get2(input-1,cache) + Get2(input-2, cache);
      cache.Add(output);
      return output;
    }
  }
}
