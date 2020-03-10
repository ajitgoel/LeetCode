using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{  
  public class RottenOranges
  {
    enum Element
    {
      ROTTEN = 2,
      FRESH = 1,
      EMPTY = 0
    }    

    [Fact]
    public void Test1()
    {
      int[][] grid =  { new int[] { 2, 1, 1}, new int[] { 1, 1, 0}, new int[] { 0, 1, 1} };
      Assert.Equal(4, TimeToInfectAllOranges(grid));
    }
    [Fact]
    public void Test2()
    {
      int[][] grid = 
        {
          new int[] {2, 1, 1}, 
          new int[] { 0, 1, 1 }, 
          new int[] { 1, 0, 1} 
        };
      Assert.Equal(-1, TimeToInfectAllOranges(grid));
    }
    [Fact]
    public void Test3()
    {
      int[][] grid = { new int[]{ 0, 2 }};
      Assert.Equal(0, TimeToInfectAllOranges(grid));
    }

    public int TimeToInfectAllOranges(int[][] grid)
    {
      if (grid == null)
      {
        throw new ArgumentNullException(nameof(grid), "Grid input paramter should not be null");
      }

      var rows = grid.Length;
      if (rows == 0 || rows > 10)
      {
        return 0;
      }
      //if no elements are fresh then return zero
      if (grid.SelectMany(x=>x).ToArray().Any(x => x == (int)Element.FRESH) == false)
      {
        return 0;
      }

      var rottenOrangesLocation = new Queue<int[]>();
      for (int row = 0; row < rows; row++)
      {
        var columns=grid[row].Length;
        for (int column = 0; column < columns; column++)
        {
          var item = grid[row][column];
          if (columns == 0 || columns > 10)
          {
            return 0;
          }

          if (item == (int)Element.ROTTEN)
          {
            rottenOrangesLocation.Enqueue(new int[] { row, column });
          }
        }
      }

      int timeElapsed = 0;
      while (rottenOrangesLocation.Count>0)
      {
        var rottenOrangesCount=rottenOrangesLocation.Count;
        for (int counter = 0; counter < rottenOrangesCount; counter++)
        {
          var item = rottenOrangesLocation.Dequeue();
          var row = item[0];
          var column = item[1];
          var columns = grid[row].Length;
          //itemLeft
          if (column - 1 >= 0 && grid[row][column - 1] == (int)Element.FRESH)
          {
            grid[row][column - 1] = (int)Element.ROTTEN;
            rottenOrangesLocation.Enqueue(new int[] { row, column - 1 });
          }
          //itemRight
          if (column + 1 < columns && grid[row][column + 1] == (int)Element.FRESH)
          {
            grid[row][column + 1] = (int)Element.ROTTEN;
            rottenOrangesLocation.Enqueue(new int[] { row, column + 1 });
          }
          //itemAbove
          if (row - 1 >= 0 && grid[row - 1][column] == (int)Element.FRESH)
          {
            grid[row - 1][column] = (int)Element.ROTTEN;
            rottenOrangesLocation.Enqueue(new int[] { row - 1, column });
          }
          //itemBelow
          if (row + 1 < rows && grid[row + 1][column] == (int)Element.FRESH)
          {
            grid[row + 1][column] = (int)Element.ROTTEN;
            rottenOrangesLocation.Enqueue(new int[] { row + 1, column });
          }
        }
        timeElapsed += 1;

        if (grid.SelectMany(x => x).ToArray().All(x => new[] { (int)Element.ROTTEN, (int)Element.EMPTY }.Contains(x)) == true)
        {
          break;
        }
      }
      //if any of the elements are still fresh then it means that they are unreachable, return -1 in this case
      if (grid.SelectMany(x => x).ToArray().Any(x => x==(int)Element.FRESH) == true)
      {
        return -1;
      }
      return timeElapsed;
    }
  }
}
