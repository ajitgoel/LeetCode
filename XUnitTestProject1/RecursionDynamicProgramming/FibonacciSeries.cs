using Xunit;
using System.Collections.Generic;
using System;

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
      var cache = new int[input+1];
      Array.Fill(cache, -1);
      return Get(input, cache);
    }      
    private int Get(int input, int[] cache)
    {
      if(input==0  || input == 1)
      {
        return input;
      }
      if (cache[input] > -1)
      {
        return cache[input];
      }
      var output = Get(input-1,cache) + Get(input-2, cache);
      cache[input]=output;
      return output;
    }
  }
}
