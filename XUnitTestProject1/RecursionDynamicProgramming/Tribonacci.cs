using Xunit;
using System;
using System.Collections.Generic;

namespace XUnitTestProject1
{
/*Write a function tribonacci that takes in a number argument, n, and returns the n-th number of the Tribonacci sequence.
The 0-th and 1-st numbers of the sequence are both 0.
The 2-nd number of the sequence is 1.
To generate further numbers of the sequence, calculate the sum of previous three numbers.Solve this recursively.
The next number is found by adding up the three numbers before it. 0, 0, 1, 1, 2, 4, 7, 13, 24, 44
Brute Force: Time: O(3^n), Space: O(n), Memoized: Time: O(n), Space: O(n)*/
  public class Tribonacci
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(0, Get(0));
      Assert.Equal(0, Get(1));
      Assert.Equal(1, Get(2));
      Assert.Equal(1, Get(3));
      Assert.Equal(2, Get(4));
      Assert.Equal(4, Get(5));
      Assert.Equal(7, Get(6));
      Assert.Equal(13, Get(7));
      Assert.Equal(24, Get(8));
      Assert.Equal(44, Get(9));
    }
    public int Get(int input)
    {
      var cache=new int[input+1];
      Array.Fill(cache ,- 1);
      return Get(input, cache);
    }      
    private int Get(int input, int[] cache)
    {
      if(input==0  || input == 1)
      {
        return 0;
      }
      if (input == 2)
      {
        return 1;
      }
      if (cache[input] > -1)
      {
        return cache[input];
      }
      //Tribonacci value is sum of three values before it.
      var output = Get(input-1,cache) + Get(input-2, cache)+ Get(input - 3, cache);
      cache[input]=output;
      return output;
    }
  }
}
