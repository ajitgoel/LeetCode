using Xunit;
using FluentAssertions;
using System;
namespace RecursionDynamicProgramming
{
  /*https://structy.net/problems/counting-change
Write a function, countingChange, that takes in an amount and an array of coins. 
The function should return the number of different ways it is possible to make change for the 
given amount using the coins.You may reuse a coin as many times as necessary.
   */
  public class CountingChange
  {
    public int Calculate(int amount, int[] coins)
    {
      int[] cache = new int[amount+1];
      Array.Fill(cache,-1);
      return Calculate(amount, coins, cache);
    }
    public int Calculate(int amount, int[] coins, int[] cache)
    {
      return -1;
      //if (amount <0)
      //{
      //  return int.MaxValue/2;
      //}
      //if (amount == 0)
      //{
      //  return 0;
      //}
      //if(cache[amount]>-1)
      //{
      //  return cache[amount];
      //}
      //var minNoOfCoins = int.MaxValue/2;
      //foreach (var coin in coins)
      //{
      //  var result=Calculate(amount-coin, coins, cache);
      //  minNoOfCoins=Math.Min(minNoOfCoins, result);
      //}
      //cache[amount] = minNoOfCoins;
      //return minNoOfCoins;
    }
    [Fact]
    public void Test()
    {
      Calculate(4, new int[] { 1, 2, 3}).Should().Be(4);
      Calculate(4, new int[] { 1, 2, 3}).Should().Be(4);
      Calculate(8, new int[] { 1, 2, 3}).Should().Be(10);
      Calculate(24, new int[] { 5, 7, 3}).Should().Be(5);
      Calculate(13, new int[] { 2, 6, 12, 10}).Should().Be(0);
      Calculate(512, new int[] { 1, 5, 10, 25}).Should().Be(20119);
      Calculate(1000, new int[] { 1, 5, 10, 25 }).Should().Be(142511);
      Calculate(240, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }).Should().Be(1525987916);
    }
  }
}