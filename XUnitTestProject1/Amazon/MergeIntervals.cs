using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
  public class MergeIntervals_Amazon
  {
    [Fact]
    public void Test1()
    {
      var input = new int[][] { new int[]{ 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
      var output = new int[][] { new int[] { 1, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
      var result = Get(input);
      Assert.True(output[0].SequenceEqual(result[0]));
      Assert.True(output[1].SequenceEqual(result[1]));
      Assert.True(output[2].SequenceEqual(result[2]));
    }
    [Fact]
    public void Test2()
    {
      var input = new int[][] { new int[] { 1, 4 }, new int[] { 4, 5 }};
      var output = new int[][] { new int[] { 1, 5 } };
      var result = Get(input);
      Assert.True(output[0].SequenceEqual(result[0]));
    }
    /*Given a collection of intervals, merge all overlapping intervals.*/
    public int[][] Get(int[][] input)
    {
      var length = input.Length;
      if (length <= 1)
      {
        return input;
      }
      Array.Sort(input, (a, b) => a[0] - b[0]);
      var result = new List<int[]>
      {
        input.ElementAt(0)
      };
      for (int counter = 1; counter < length; counter++)
      {
        var currentElementInLoop = input.ElementAt(counter);
        var lastAddedElementToResult = result.Last();
        if (lastAddedElementToResult[1] >= currentElementInLoop[0])
        {
          lastAddedElementToResult[1] = Math.Max(lastAddedElementToResult[1], currentElementInLoop[1]);
        }
        else
        {
          result.Add(currentElementInLoop);
        }
      }
      return result.ToArray();
    }
  }
}
