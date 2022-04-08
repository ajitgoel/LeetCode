using Xunit;
using System;
using FluentAssertions;

namespace RecursionDynamicProgramming
{
  /*Write a function sumPossible that takes in an amount and an array of positive numbers. 
   * The function should return a boolean indicating whether or not it is possible to create the amount by summing numbers of the array. You may reuse numbers of the array as many times as necessary.
  You may assume that the target amount is non-negative.*/
  public class SumPossible
  {
    [Fact]
    public void Test()
    {
      Get(8, new int[] { 5, 12, 4 }).Should().Be(true);
      Get(15, new int[] { 6, 2, 10, 19 }).Should().Be(false);
      Get(13, new int[] { 6, 2, 1 }).Should().Be(true);
      Get(103, new int[] { 6, 20, 1 }).Should().Be(true);
      Get(12, new int[] { }).Should().Be(false);
      Get(12, new int[]{ 12}).Should().Be(true);
      Get(0, new int[] { }).Should().Be(true);
      Get(13, new int[] { 3, 5 }).Should().Be(true);
      //Get(271, new int[] { 10, 8, 265, 24 }).Should().Be(false);
      //Get(2017, new int[] { 4, 2, 10 }).Should().Be(false);
    }
    public bool Get(int amount, int[] numbers)
    {
      var cache = new bool[amount + 1];
      return Get(amount, numbers, cache);
    }
    private bool Get(int amount, int[] numbers, bool[] cache)
    {
      if (amount <0)
      {
        return false;
      }
      if (amount == 0)
      {
        return true;
      }
      if (Array.IndexOf(cache, amount) > -1)
      {
        return cache[amount];
      }
      System.Diagnostics.Debug.Print($"{amount} {System.Text.Json.JsonSerializer.Serialize(numbers)} " +
        $"{System.Text.Json.JsonSerializer.Serialize(cache)}");
      for (int i = 0; i < numbers.Length; i++)
      {
        if(Get(amount - numbers[i], numbers, cache))
        {
          cache[amount] = true;
          return true;
        }
      }
      cache[amount] = false;
      return false;
    }
  }
}
