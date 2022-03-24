using Xunit;
using FluentAssertions;

namespace XUnitTestProject1.RecursionDynamicProgramming
{
  public class MinNumberOfCoinsForChange
  {
    public int Calculate(int amount, int[] coins)
    {
      // this will store the optimal solution
      // for all the values — from 0 to given amount.
      int[] coinReq = new int[amount + 1];
      coinReq[0] = 0; // 0 coins are required to make the change for 0
                      // now solve for all the amounts
      for (int amt = 1; amt <= amount; amt++)
      {
        coinReq[amt] = int.MaxValue;
        // Now try taking every coin one at a time and pick the minimum
        for (int j = 0; j < coins.Length; j++)
        {
          if (coins[j] <= amt)
          { 
            // check if coin value is less than amount
            // select the coin and add 1 to solution of (amount-coin value)
            //coinReq[amt] = Math.min(coinReq[amt – coins[j]] + 1, coinReq[amt]);
          }
        }
      }
      //return the optimal solution for amount
      return coinReq[amount];

    }

    [Fact]
    public void Test()
    {
      int[] coins = { 1, 2, 3 };
      int amount = 20;
      Calculate(amount, coins).Should().Be(7);
    }
  }
}
