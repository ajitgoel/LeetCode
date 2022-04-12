using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Amazon
{
  public class ThreeNumberEqualToTargetSum
  {
    [Fact]
    public void Test1()
    {
      var result1 = CalculateUsingBruteForce(new int[] { 12, 3, 1, 2, -6, 5, -8, 6 }, 0);
      result1.Contains(new List<int> { -8, 2, 6 });
      result1.Contains(new List<int> { -8, 3, 5 });
      result1.Contains(new List<int> { -6, 1, 5 });

      var result2 = Calculate(new int[] { 12,3,1,2,-6,5,-8,6},0);
      result2.Contains(new List<int>{-8, 2, 6 });
      result2.Contains(new List<int>{ -8, 3, 5 });
      result2.Contains(new List<int>{ -6, 1, 5 });
    }
    /*Time complexity: O(N*N*N) | Space complexity: O(1)
     */
    List<List<int>> CalculateUsingBruteForce(int[] array, int targetsum)
    {
      List<List<int>> output = new List<List<int>>();
      if (array.Length <= 2)
      {
        return output;
      }
      //first loop: loop from the first element to the third last element
      //second loop: loop from the element in first loop to the second last element
      //third loop: loop from the element in second loop to the last element
      for (int i = 0; i < array.Length - 2; i = i + 1)
      {
        for (int j = i + 1; j < array.Length - 1; j = j + 1)
        {
          for (int k = j + 1; k < array.Length; k = k + 1)
          {
            if (array[i] + array[j] + array[k] == targetsum)
            {
              output.Add(new List<int>{ array[i], array[j], array[k] });
            }
          }
        }
      }
      return output;
    }
    /*Time complexity: O(N*N) | Space complexity: O(N)
    first sort the array and traverse the array from left to right. 
    Now for each element array[i], we use two pointers leftposition (initialized with i + 1) and 
    rightposition (initialized with arrayLength - 1) and run a loop until rightposition > leftposition
    to find out if there are any triplets (array[i], array[leftposition], array[rightposition]) with 
    sum equal to targetsum or not.
     -3,-2,0,2,5 => 0,-2,2 and -2, 5, -3*/
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
