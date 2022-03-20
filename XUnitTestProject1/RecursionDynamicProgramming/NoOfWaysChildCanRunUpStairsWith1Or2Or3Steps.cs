using FluentAssertions;
using System;
using Xunit;
using System.Linq;

namespace XUnitTestProject1
{
  /*A child is running up a staircase with n steps, and can hop either 1 step, 2 steps, or 3 steps at a time. Implement a method to count how many possible ways the child
can run up the stairs*/
  public class NoOfWaysChildCanRunUpStairsWith1Or2Or3Steps
  {
    [Fact]
    public void Test1()
    {
      countWaysUsingRecursion(27).Should().Be(8646064L);
    }
    [Fact]
    public void Test2()
    {
      var map=new long[38];
      Array.Fill(map, -1);
      countWaysUsingRecursionDynamicProgramming(37, map).Should().Be(3831006429L);
    }
    public long countWaysUsingRecursion(int n)
    {
      if (n < 0)
      {
        return 0;
      }
      if (n == 0)
      {
        return 1;
      }
      return countWaysUsingRecursion(n - 1) + countWaysUsingRecursion(n - 2) + countWaysUsingRecursion(n - 3);
    }
    public long countWaysUsingRecursionDynamicProgramming(long n, long[] map)
    {
      if (n < 0)
      {
        return 0;
      }
      if (n == 0)
      {
        return 1;
      }
      if(map[n]>-1)
      {
        return map[n];
      }
      map[n]= countWaysUsingRecursionDynamicProgramming(n - 1, map) + countWaysUsingRecursionDynamicProgramming(n - 2, map) + 
        countWaysUsingRecursionDynamicProgramming(n - 3, map);
      return map[n];
    }
  }
}
