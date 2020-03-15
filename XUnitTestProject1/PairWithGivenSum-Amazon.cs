using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{  
  public class PairWithGivenSumAmazon
  {
    [Fact]
    public void Test1()
    {
      var output = new[]{2,3};
      var result = PairWithGivenSum(new[] { 1, 10, 25, 35, 60 }, 90);
      Assert.True(output.SequenceEqual(result));
    }

    [Fact]
    public void ForMuliplePairsSelectPairWithLargestNumber_Test()
    {
      var output = new[] {1,5};
      var result = PairWithGivenSum(new[] { 20, 50, 40, 25, 30, 10 }, 90);
      Assert.True(output.SequenceEqual(result));
    }

    [Fact]
    public void Tes3()
    {
      var output = new[] {0, 1};
      var result = PairWithGivenSum(new[] { 0,0}, 30);
      Assert.True(output.SequenceEqual(result));
    }
    /*Given a list of positive integers nums and an int target, return indices of the two numbers such that 
     * they add up to a target - 30.
    Conditions:
    You will pick exactly 2 numbers.
    You cannot pick the same element twice.
    If you have muliple pairs, select the pair with the largest number.*/
    public int[] PairWithGivenSum(int[] items, int target)
    {
      int largestNumber = -1;
      int number1Index = -1;
      int number2Index = -1;

      for (var counter1 = 0; counter1 < items.Length; counter1++)
      {
        for (var counter2 = counter1; counter2 < items.Length; counter2++)
        {
          if (counter1 == counter2)
          {
            continue;
          }
          if ((items[counter1] + items[counter2]) == target - 30)
          {
            if (largestNumber == -1 ||
              largestNumber > items[counter1] || largestNumber > items[counter2]
              )
            {
              number1Index = counter1;
              number2Index = counter2;
              largestNumber = items[counter1] > items[counter2] ? items[counter1] : items[counter2];
            }
          }
        }
      }
      return (number1Index == -1 || number2Index == -1) ? null : new[] { number1Index, number2Index };
    }
  }
}
