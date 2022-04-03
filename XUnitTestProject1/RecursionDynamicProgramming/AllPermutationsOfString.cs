using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestProject1.RecursionDynamicProgramming
{
  public class Maze
  {
    [Fact]
    public void Test()
    {
      var result2 = GetPermutations(
        new long[3][] 
        { 
          new long[3]{ 0, 0, 1 },
          new long[3]{ 1, 0, 0},
          new long[3]{ 1, 1, 0 }
        }, 3);
    }

    private bool GetPermutations(long[][] maze, long n)
    {
      return false;
      for (var outer=0; outer< maze.Length;outer++)
      {
        for (var inner= 0; inner< maze[outer].Length; inner++)
        {

        }
      }
    }
  }

  public class ArrayWhichoccursLeastNumberOfTimes
  {
    [Fact]
    public void Test()
    {
      var result2 = GetPermutations(new long[] { 10,941, 13,13,13,941});
      var result1 = GetPermutations(new long[] { });
    }

    private long[] GetPermutations(long[] input)
    {
      var dictionary = new Dictionary<long, long>();
      for(var x=0;x<input.Length;x++)
      {
        if(dictionary.ContainsKey(input[x])==false)
        {
          dictionary.Add(input[x],1);
        }
        else
        {
          dictionary[input[x]] = dictionary[input[x]]+1;
        }
      }
      var minvalue = long.MaxValue;
      var key = -1;
      foreach (var counter in dictionary)
      {
        if(counter.Value<minvalue)
        {
          minvalue = counter.Value;
        }
      }
      return dictionary.Where(x => x.Value == minvalue).Select(x => x.Key).ToArray();
    }
  }

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
