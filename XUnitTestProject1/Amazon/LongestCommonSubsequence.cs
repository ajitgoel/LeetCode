using Xunit;
using System;
using FluentAssertions;

namespace Amazon
{
  /*https://leetcode.com/problems/longest-common-subsequence/
  Given two strings text1 and text2, return the length of their longest common subsequence. If there is no common subsequence, return 0.
A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.
For example, "ace" is a subsequence of "abcde".
A common subsequence of two strings is a subsequence that is common to both strings.
Constraints:
1 <= text1.length, text2.length <= 1000
text1 and text2 consist of only lowercase English characters.
Solution 1: https://www.youtube.com/watch?v=Ua0GhsJSlWM
Solution 2: https://leetcode.com/problems/longest-common-subsequence/discuss/598908/C-6-lines-DP-solution.
   */
  public class LongestCommonSubsequence
  {
    [Fact]
    public void Test()
    {
      Calculate("abcde", "ace").Should().Be(3);
      Calculate("abc", "abc").Should().Be(3);
      Calculate("abc", "def").Should().Be(0);

      CalculateUsingDynamicProgramming("abcde", "ace").Should().Be(3);
      CalculateUsingDynamicProgramming("abc", "abc").Should().Be(3);
      CalculateUsingDynamicProgramming("abc", "def").Should().Be(0);
    }
    public int Calculate(string input1, string input2)
    {
      int startindex = 0;
      int longestCommonSubsequenceLength = 0;
      foreach (var element2 in input2.ToCharArray())
      {
        var index=input1.IndexOf(element2, startindex);
        if (index >= 0)
        {
          startindex++;
          longestCommonSubsequenceLength++;
        }
      }
      return longestCommonSubsequenceLength;
    }

    public int CalculateUsingDynamicProgramming(string input1, string input2)
    {
      var matrix = new int[input1.Length+1, input2.Length+1];
      for (int row = 0; row < input1.Length; row++)
      {
        for (int column = 0; column < input2.Length; column++)
        {
          if(input1[row]==input2[column])
          {
            matrix[row+1, column+1] = matrix[row, column] + 1;
          }
          else
          {
            matrix[row+1, column+1] = Math.Max(matrix[row+1, column], matrix[row, column+1]);
          }
        }
      }
      return matrix[input1.Length, input2.Length];
    }
  }
}
