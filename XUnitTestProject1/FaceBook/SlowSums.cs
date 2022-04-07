using System;
using Xunit;
using FluentAssertions;
namespace GreedyAlgorithms.FaceBook
{
  /*Suppose we have a list of N numbers, and repeat the following operation until we're left with only a single number: Choose any two numbers and replace them with their sum. Moreover, we associate a penalty with each operation equal to the value of the new number, and call the penalty for the entire list as the sum of the penalties of each operation.
For example, given the list [1, 2, 3, 4, 5], we could choose 2 and 3 for the first operation, which would transform the list into [1, 5, 4, 5] and incur a penalty of 5. The goal in this problem is to find the highest possible penalty for a given input.
Signature:
int getTotalTime(int[] arr)
Input:
An array arr containing N integers, denoting the numbers in the list.
Output format:
An int representing the highest possible total penalty.
Constraints:
1 ≤ N ≤ 10^6
1 ≤ Ai ≤ 10^7, where *Ai denotes the ith initial element of an array.
The sum of values of N over all test cases will not exceed 5 * 10^6.*/
  public class SlowSums
  {
    [Fact]
    public void Test1()
    {
      getTotalTime(new int[] {4, 2, 1, 3}).Should().Be(26);
    }
    static int getTotalTime(int[] arr)
    {
      //1,2,3,4
      //  sum:      4=>  4+3=7=>  7+2=9=>  9+1=10
      //  penalty:  0=>      7=>  7+9+16=> 16+10=26
      Array.Sort(arr);
      var sum = arr[arr.Length - 1];
      var penalty = 0;
      for (var i = arr.Length - 2; i >= 0; i--)
      {
        sum = sum + arr[i];
        penalty = penalty +sum;
      }
      return penalty;
    }
  }
}