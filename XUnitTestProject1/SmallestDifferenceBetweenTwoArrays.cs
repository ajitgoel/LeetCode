using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
  public class SmallestDifferenceBetweenTwoArrays
  {
    [Fact]
    public void Test1()
    {
      var result1 = Calculate(new int[] { -1,5,10,20,28,3}, new int[] { 26,134,135,15,17});
      result1.Length.Equals(2);
      result1.Contains(28).Equals(true);
      result1.Contains(26).Equals(true);
    }
    //O(N log (N) + M log(M)): Time complexity=> due to sorting of the two arrays: O(1):Space complexity, constant space
    public static int[] Calculate(int[] array1, int[] array2)
    {
      //sort the arrays
      // -1, 3, 5, 10, 20, 28
      // 15, 17, 26, 134, 135
      Array.Sort(array1);
      Array.Sort(array2);
      var leftposition = 0;
      var rightposition = array2.Length-1;
      var smallestarray = new int[2];
      var smallestnumber = Int32.MaxValue;
      var currentnumber = Int32.MaxValue;

      while (leftposition< array1.Length && rightposition< array2.Length)
      {
        var leftelement = array1[leftposition];
        var rightelement = array2[rightposition];
        if(leftelement < rightelement)
        {
          currentnumber = rightelement - leftelement;
          leftposition++;
        }
        else if(leftelement > rightelement)
        {
          currentnumber = rightelement - leftelement;
          rightposition--;
        }
        else
        {
          smallestarray[0] = leftelement;
          smallestarray[1] = rightelement;
          return smallestarray;
        }
        if(smallestnumber>currentnumber)
        {
          smallestnumber = currentnumber;
          smallestarray[0] = leftelement;
          smallestarray[1] = rightelement;
        }
      }
      return smallestarray;
    }
  }
}
