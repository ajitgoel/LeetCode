using Xunit;
using System.Collections.Generic;

namespace XUnitTestProject1
{
  /*The next number is found by adding up the two numbers before it. 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
  Brute Force: Time: O(2^n), Space: O(n), Memoized: Time: O(n), Space: O(n)*/
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
      return Get(input, new Dictionary<int, int>());
    }      
    private int Get(int input, Dictionary<int, int> cache)
    {
      if(cache.ContainsKey(input))
      {
        return cache[input];
      }
      if(input==0  || input == 1)
      {
        return input;
      }
      var output= Get(input-1,cache) + Get(input-2, cache);
      cache[input]=output;
      return output;
    }
  }
}
