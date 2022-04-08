using Xunit;
using FluentAssertions;
using System;

namespace RecursionDynamicProgramming
{
  /*https://structy.net/problems/min-change
   * Write a function minChange that takes in an amount and an array of coins. 
   * The function should return the minimum number of coins required to create the amount. 
   * You may use each coin as many times as necessary.If it is not possible to create the amount, then return -1.
   Brute Force: Time Complexity: O(c to the power of a), Space Complexity: O(a) where c is the no of coins and a is the amount
   Brute Force with memoization: Time Complexity: O(c*a), Space Complexity: O(a) where c is the no of coins and a is the amount
   */
  public class MinNumberOfCoinsForChange
  {
    public int Calculate(int amount, int[] coins)
    {
      int[] cache = new int[amount+1];
      Array.Fill(cache,-1);
      var result=Calculate(amount, coins, cache);
      return (result == int.MaxValue/2 ? -1 : result);
    }
    public int Calculate(int amount, int[] coins, int[] cache)
    {
      if (amount <0)
      {
        return int.MaxValue/2;
      }
      if (amount == 0)
      {
        return 0;
      }
      if(cache[amount]>-1)
      {
        return cache[amount];
      }
      var minNoOfCoins = int.MaxValue/2;
      foreach (var coin in coins)
      {
        var result=1+Calculate(amount-coin, coins, cache);
        minNoOfCoins=Math.Min(minNoOfCoins, result);
      }
      cache[amount] = minNoOfCoins;
      return minNoOfCoins;
    }
    [Fact]
    public void Test()
    {
      Calculate(2, new int[] { 1, 2}).Should().Be(1);
      Calculate(8, new int[] { 1, 5, 4, 12 }).Should().Be(2);
      Calculate(13, new int[] { 1, 9, 5, 14, 30 }).Should().Be(5);
      Calculate(23, new int[] { 2, 5, 7 }).Should().Be(4);
      Calculate(102, new int[] { 1, 5, 10, 25 }).Should().Be(6);
      Calculate(200, new int[] { 1, 5, 10, 25 }).Should().Be(8);
      Calculate(2017, new int[] { 4, 2, 10 }).Should().Be(-1);
      Calculate(271, new int[] { 10, 8, 265, 24 }).Should().Be(-1);
      Calculate(0, new int[] { 4, 2, 10 }).Should().Be(0);
      Calculate(20, new int[] { 1, 2, 3 }).Should().Be(7);
    }
  }
}
