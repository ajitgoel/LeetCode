using Xunit;
using System;
using System.Collections.Generic;
using FluentAssertions;

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
      Get(0).Should().Be(0);
      Get(1).Should().Be(0);
      Get(2).Should().Be(1);
      Get(3).Should().Be(1);
      Get(4).Should().Be(2);
      Get(5).Should().Be(4);
      Get(6).Should().Be(7);
      Get(7).Should().Be(13);
      Get(8).Should().Be(24);
      Get(9).Should().Be(44);
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
      cache[input] = Get(input-1,cache) + Get(input-2, cache)+ Get(input - 3, cache);
      return cache[input];
    }
  }
}
