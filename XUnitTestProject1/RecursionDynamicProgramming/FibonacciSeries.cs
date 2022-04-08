using Xunit;
using System.Collections.Generic;
using System;
using FluentAssertions;

namespace RecursionDynamicProgramming
{

  /*The next number is found by adding up the two numbers before it. 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
  Brute Force: Time: O(2^n), Space: O(n), Memoized: Time: O(n), Space: O(n)*/
  public class FibonacciSeries
  {
    [Fact]
    public void Test()
    {
      Get(0).Should().Be(0);
      Get(1).Should().Be(1);
      Get(2).Should().Be(1);
      Get(3).Should().Be(2);
      Get(4).Should().Be(3);
      Get(5).Should().Be(5);
      Get(6).Should().Be(8);
      Get(7).Should().Be(13);
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
      cache[input] = Get(input-1,cache) + Get(input-2, cache);
      return cache[input];
    }
  }
}
