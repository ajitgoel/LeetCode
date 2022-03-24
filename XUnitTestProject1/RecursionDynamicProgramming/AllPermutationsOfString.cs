using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace XUnitTestProject1.RecursionDynamicProgramming
{
  public class AllPermutationsOfString
  {
    [Fact]
    public void Test()
    {
      var result2 = GetPermutations("ab");
      result2.Should().HaveCount(2);
      result2.Should().Contain(new string[] { "ab" });
      result2.Should().Contain(new string[] { "ba" });

      var result1 = GetPermutations("abc");
      result1.Should().HaveCount(6);
      result1.Should().Contain(new string[] { "abc" });
      result1.Should().Contain(new string[] { "acb" });
      result1.Should().Contain(new string[] { "bac" });
      result1.Should().Contain(new string[] { "bca" });
      result1.Should().Contain(new string[] { "cba" });
      result1.Should().Contain(new string[] { "cab" });
    }

    private string[] GetPermutations(string input)
    {
      result = new List<string>();
      var arr = input.ToCharArray();
      GetPermutations(arr, 0, arr.Length - 1);
      return result.ToArray();
    }
    List<string> result = null;
    private void GetPermutations(char[] elements, int startindex, int endindex)
    {
      if (startindex == endindex)
      {
        result.Add(new string(elements));
        return;
      }
      for (int i = startindex; i <= endindex; i++)
      {
        //https://www.youtube.com/watch?v=GuTPwotSdYw, swapping the elements before getting the permutations
        (elements[startindex], elements[i]) = (elements[i], elements[startindex]);
        GetPermutations(elements, startindex + 1, endindex);
        //backtracking the swapped elements so we can get the remaining permutations
        (elements[startindex], elements[i]) = (elements[i], elements[startindex]);
      }
    }
  }
}
