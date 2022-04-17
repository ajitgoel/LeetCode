using Xunit;
using System;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;

namespace Namely
{
  /*Given a collection of intervals, merge all overlapping intervals. For example: Given [8,10], [1,3], [15,18], [7,8], [4,5], [2,6], return [1,6], [7,10], [15,18].*/
  public class MergeOverlappingIntervals
  {
    [Fact]
    public void Test()
    {
      var input = new List<List<int>>
      {
        new List<int> { 8, 10},
        new List<int> { 15, 18},
        new List<int> { 1, 3},
        new List<int> { 2, 6},
        new List<int> { 4, 5},
        new List<int> { 7, 8},
      };
      var result = new List<List<int>>
      {
        new List<int> { 1, 6 },
        new List<int> { 7, 10 },
        new List<int> { 15, 18 }
      };
      merge_overlapping_intervals(input).Should().Contain(result);
    }
    public static List<List<int>> merge_overlapping_intervals(List<List<int>> intervals)
    {
      var inputs = intervals.OrderBy(x => x[0]);
      var results = new List<List<int>>();
      var firstelement = inputs.First()[0];
      var secondelement = inputs.First()[1];
      var remainingElements=inputs.Skip(1);
      foreach (var interval in remainingElements)
      {
        if (secondelement>=interval[0] )//3>=2 => 6>=4 => 6>=7=> 8>=8 => 8>=15
        {
          secondelement = Math.Max(secondelement, interval[1]);//max of 3 and 6=> max of 6 and 5=>max of 8 and 10
        }
        else
        {
          results.Add(new List<int> { firstelement, secondelement });//1,6 => 7, 10 => 
          firstelement = interval[0];//7=>15
          secondelement = interval[1];//8=>18
        }
      }
      return results;
    }
  }
}
