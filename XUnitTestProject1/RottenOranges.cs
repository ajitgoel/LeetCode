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
      var grid = new int[3, 3] {{ 2, 1, 1},{ 1, 1, 0},{ 0, 1, 1} };
      Assert.Equal(4, TimeToInfectAllOranges(grid));
    }
    [Fact]
    public void Test2()
    {
      var grid = new int[3, 3] { {2, 1, 1},{ 0, 1, 1 },{ 1, 0, 1} };
      Assert.Equal(-1, TimeToInfectAllOranges(grid));
    }
    [Fact]
    public void Test3()
    {
      var grid = new int[1, 2] { { 0, 2 }};
      Assert.Equal(0, TimeToInfectAllOranges(grid));
    }

    public int TimeToInfectAllOranges(int[,] grid)
    {
      var rows = grid.GetLength(0);
      var columns = grid.GetLength(1);
      int timeElapsed = 0;
      if (rows == 0 || rows > 10 || columns == 0 || columns > 10)
      {
        return 0;
      }

      var validElements = new int[] { (int) Element.ROTTEN, (int)Element.FRESH, (int)Element.EMPTY }.Cast<int>();
      if (grid.Cast<int>().Any(x => x == (int)Element.FRESH)==false)
      {
        return 0;
      }

      while (true)
      {
        for (int row = 0; row < rows; row++)
        {
          for (int column = 0; column < columns; column++)
          {
            var item = grid[row, column];
            if (item == (int)Element.ROTTEN)
            {
              //itemLeft
              if (column - 1 >= 0 && grid[row, column - 1] == (int)Element.FRESH)
              {
                grid[row, column - 1] = (int)Element.ROTTEN;
              }
              //itemRight
              if (column + 1 < columns && grid[row, column + 1] == (int)Element.FRESH)
              {
                grid[row, column + 1] = (int)Element.ROTTEN;
              }
              //itemAbove
              if (row - 1 >= 0 && grid[row - 1, column] == (int)Element.FRESH)
              {
                grid[row - 1, column] = (int)Element.ROTTEN;
              }
              //itemBelow
              if (row + 1 < rows && grid[row + 1, column] == (int)Element.FRESH)
              {
                grid[row + 1, column] = (int)Element.ROTTEN;
              }
            }
          }
        }
        timeElapsed += 1;

        System.Diagnostics.Debug.WriteLine("grid: " + JsonConvert.SerializeObject(grid));
        if (grid.Cast<int>().All(x => new List<int>() { (int)Element.ROTTEN, (int)Element.EMPTY }.Contains(x)) == true)
        {
          break;
        }
      }
      return timeElapsed;
    }
  }
}
