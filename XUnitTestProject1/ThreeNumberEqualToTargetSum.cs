using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
  public class ThreeNumberEqualToTargetSum
  {
    [Fact]
    public void Test1()
    {
      var result = Calculate(new int[] { 12,3,1,2,-6,5,-8,6},0);
      result.Contains(new List<int>{-8, 2, 6 });
      result.Contains(new List<int>{ -8, 3, 5 });
      result.Contains(new List<int>{ -6, 1, 5 });
    }
    //O(N*N): Time complexity: O(N):Space complexity
    public static List<List<int>> Calculate(int[] array, int targetsum)
    {
      //sort the arrays
      // -8, -6, 1, 2, 3, 5, 6, 12
      Array.Sort(array);
      
      var result = new List<List<int>>();
      for (var counter=0; counter < array.Length;counter++)
      {
        var leftposition = counter+1;
        var rightposition = array.Length - 1;
        var currentelement = array[counter];
        while(leftposition < rightposition)
        {
          var currentsum = array[leftposition] + array[rightposition] + currentelement;
          if (currentsum == targetsum)
          {
            result.Add(new List<int> { array[leftposition], array[rightposition], currentelement });
            leftposition++;
            rightposition--;
          }
          else if (currentsum < targetsum)
          {
            leftposition++;
          }
          else if (currentsum > targetsum)
          {
            rightposition--;
          }
        }        
      }
      return result;
    }
  }
}
