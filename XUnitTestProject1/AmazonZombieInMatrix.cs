using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{  
  public class AmazonZombieInMatrix
  {
    readonly int zombie = 1;
    readonly int human = 0;

    [Fact]
    public void Test1()
    {
      var grid = new int[4,5] {
         { human, zombie, zombie, human, zombie },
         { human, zombie, human, zombie, human},//human=row 1,column 2=>above zombie=row 0, column 2
         { human, human, human, human, zombie },
         { human, zombie, human, human, human}
      };
      var rows = grid.GetLength(0);
      var columns = grid.GetLength(1);
      Assert.Equal(2, HoursToInfectAllHumans(rows, columns, grid));
    }

    [Fact]
    public void Test2()
    {
      var grid = new int[3, 3] { { 2, 1, 1 }, { 0, 1, 1 }, { 1, 0, 1 } };
      var rows = grid.GetLength(0);
      var columns = grid.GetLength(1);
      Assert.Equal(-1, HoursToInfectAllHumans(rows, columns, grid));
    }
    [Fact]
    public void Test3()
    {
      var grid = new int[1, 2] { { 0, 2 } };
      var rows = grid.GetLength(0);
      var columns = grid.GetLength(1);
      Assert.Equal(-1, HoursToInfectAllHumans(rows, columns, grid));
    }

    public int HoursToInfectAllHumans(int rows, int columns, int[,] grid)
    {
      int timeElapsed = 0;
      var validElements = new int[] { human, zombie}.Cast<int>();
      if(grid.Cast<int>().All(x=> validElements.Contains(x)) ==false)
      {
        return -1;
      }

      while (true)
      { 
        for (int row = 0; row < rows; row++)
        {
          for (int column = 0; column < columns; column++)
          {
            var item = grid[row, column];
            if (item == zombie)
            {
              //itemLeft
              if (column - 1 >= 0 && grid[row, column - 1] == human)
              {
                grid[row, column - 1] = zombie;
              }
              //itemRight
              else if (column + 1 < columns && grid[row, column + 1] == human)
              {
                grid[row, column + 1] = zombie;
              }
              //itemAbove
              else if (row - 1 >= 0 && grid[row - 1, column] == human)
              {
                grid[row - 1, column] = zombie;
              }
              //itemBelow
              else if (row + 1 < rows && grid[row + 1, column] == human)
              {
                grid[row + 1, column] = zombie;
              }
            }
          }
        }
        timeElapsed += 1;
        if (grid.Cast<int>().All(x => x==zombie) == true)
        {
          break;
        }
      }
      return timeElapsed;
    }
  }
}
