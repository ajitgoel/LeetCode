using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
  public class SearchInSortedMatrix
  {
    [Fact]
    public void Test1()
    {
      var array = new int[5, 6]
      {
        { 1, 4, 7, 12, 15, 1000 },
        { 2, 5, 19, 31, 32, 1001 },
        { 3, 8, 24, 33, 35, 1002 },
        { 40, 41, 42, 44, 45, 1003 },
        { 99, 100, 103, 106, 128, 1004 }
      };
      var result1 = Calculate(array, 44);
      var result2 = Calculate(array, 98);
      //result1.Length.Equals(2);
      //result1.Contains(28).Equals(true);
      //result1.Contains(26).Equals(true);
    }
    //O(N+M): Time complexity: O(1):Space complexity, constant space
    public static int[] Calculate(int[,] array, int targetValueInArray)
    {
      return null;      
    }
  }
}
