using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{  
  public class OptimalUtilization_Amazon
  {
    /*There are only three combinations {1, 1], {2, 1], and {3, 1], which have a total sum of 4, 6 and 8, respectively.
    Since 6 is the largest sum that does not exceed 7, {2, 1] is the optimal pair.*/
    [Fact]
    public void Test1()
    {
      var output = new[,] { { 2, 1 } };
      var result = GetOptimalUtilization(new[,] { { 1, 2 }, { 2, 4 }, { 3, 6 } }, new[,] { { 1, 2 } }, 7);
      for (var row = 0; row < output.GetLength(0); row++)
      {
        for (var column = 0; column < output.GetLength(1); column++)
        {
          Assert.Equal(output[row, column], result[row, column]);
        }
      }
    }

    /*There are two pairs possible. Element with id = 2 from the list `a` has a value 5, and element with id = 4 from the list `b` also has a value 5.
    Combined, they add up to 10. Similarily, element with id = 3 from `a` has a value 7, and element with id = 2 from `b` has a value 3.
    These also add up to 10. Therefore, the optimal pairs are {2, 4] and {3, 2].*/
    [Fact]
    public void Test2()
    {
      var output = new[,] {{2, 4}, {3, 2}};
      var result = GetOptimalUtilization(new[,] {{1, 3}, {2, 5}, {3, 7}, {4, 10}}, new[,] {{1, 2}, {2, 3}, {3, 4}, {4, 5}}, 10);
      for(var row=0; row < output.GetLength(0);row++)
      {
        for (var column = 0; column< output.GetLength(1); column++)
        {
          Assert.Equal(output[row, column], result[row, column]);
        }
      }
    }

    [Fact]
    public void Test3()
    {
      var output = new[,] { { 3, 1 } };
      var result = GetOptimalUtilization(new[,] { { 1, 8 }, { 2, 7 }, { 3, 14 } }, new[,] { { 1, 5 }, { 2, 10 }, { 3, 14 } }, 20);
      for (var row = 0; row < output.GetLength(0); row++)
      {
        for (var column = 0; column < output.GetLength(1); column++)
        {
          Assert.Equal(output[row, column], result[row, column]);
        }
      }
    }

    [Fact]
    public void Test4()
    {
      var output = new[,]{{1,3},{3,2}};
      var result = GetOptimalUtilization(new[,]{{1,8},{2,15},{3,9}}, new[,]{{1, 8},{2,11},{3,12}}, 7);
      for (var row = 0; row < output.GetLength(0); row++)
      {
        for (var column = 0; column < output.GetLength(1); column++)
        {
          Assert.Equal(output[row, column], result[row, column]);
        }
      }
    }

    /*Given 2 lists a and b.Each element is a pair of integers where the first integer represents the unique id and 
     * the second integer represents a value.Your task is to find an element from a and an element form b such that the 
     * sum of their values is less or equal to target and as close to target as possible.Return a list of ids of selected elements. 
     * If no pair is possible, return an empty list.
      */
    public int[,] GetOptimalUtilization(int[,] items1, int[,] items2, int target)
    {
      return null;      
    }
  }
}
