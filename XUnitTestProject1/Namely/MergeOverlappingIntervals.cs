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
    public void Test1()
    {
      var input1 = new List<List<int>>
      {
        new List<int> { 1, 3},
        new List<int> { 2, 6},
        new List<int> { 4, 5},
        new List<int> { 7, 8},
        new List<int> { 8, 10},
        new List<int> { 15, 18},
        };
      var result1 = new List<List<int>>
      {
        new List<int> { 1, 6 },new List<int> { 7, 10 },new List<int> { 15, 18 }
      };
      Calculate(input1).Should().BeEquivalentTo(result1);

      var input2 = new List<List<int>>
      {
        new List<int> {1,3}, new List<int> {4,6},new List<int> {5,9}, new List<int> {10,12}
      };
      var expectedResult2 = new List<List<int>>
      {
        new List<int> {1,3},new List<int>{4,9}, new List<int>{10,12}
      };
      Calculate(input2).Should().BeEquivalentTo(expectedResult2);
    }
    [Fact]
    public void Test2()
    {
      //var input1 = new List<List<int>>
      //{
      //  new List<int> { 8, 10},
      //  new List<int> { 15, 18},
      //  new List<int> { 1, 3},
      //  new List<int> { 2, 6},
      //  new List<int> { 4, 5},
      //  new List<int> { 7, 8},
      //};
      //var result1 = new List<List<int>>
      //{
      //  new List<int> { 1, 6 },
      //  new List<int> { 7, 10 },
      //  new List<int> { 15, 18 }
      //};
      //merge_overlapping_intervals(input1).Should().BeEquivalentTo(result1);

      var input2 = new List<List<int>>
      {
        new List<int> {1,3}, new List<int> {4,6},new List<int> {5,9}, new List<int> {10,12}
      };
      var expectedResult2 = new List<List<int>>
      {
        new List<int> {1,3},new List<int>{4,9}, new List<int>{10,12}
      };
      merge_overlapping_intervals(input2).Should().BeEquivalentTo(expectedResult2);
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

    /*https://www.educative.io/edpresso/what-is-the-merge-overlapping-intervals-problem
    Sort the given list of time intervals in ascending order of starting time.
    Then, push the first time interval in the stack and compare the next interval with the one in the stack.
    If it’s overlapping, then merge them into one interval; otherwise, push it in the stack.
    In the end, the intervals left in the stack will be mutually exclusive.
    Time complexity: take O(nLog n) time because we have to sort n intervals making it nlogn time complexity.
    {1,3}{4,6},{5,9}, {10,12} => {1,3},{4,9}, {10,12}*/
    public static List<List<int>> Calculate(List<List<int>> intervals)
    {
      intervals=intervals.OrderBy(x => x[0]).ToList();
      var result = new List<List<int>>();
      var stack = new Stack<List<int>>();
      stack.Push(intervals[0]);
      for (int counter= 1; counter < intervals.Count; counter++)
      {
        var intervalInStack=stack.Peek();
        if(intervalInStack[1]>intervals[counter][0])
        {
          stack.Pop();
          stack.Push(new List<int> {intervalInStack[0], intervals[counter][1] });
        }
        else
        {
          stack.Push(intervals[counter]);
        }
      }
      while(stack.Count>0)
      {
        result.Add(stack.Pop());
      }
      return result;              
    }
  }
}
