using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{  
  public class ZombieInMatrix_Amazon
  {
    enum Element
    {
      Zombie = 1,
      Human = 0
    }

    [Fact]
    public void Test1()
    {
      var list1=new List<int>();
      list1.AddRange(new int[] { 0, 1, 1, 0, 1 });
      var list2 = new List<int>();
      list2.AddRange(new int[] { 0, 1, 0, 1, 0 });
      var list3 = new List<int>();
      list3.AddRange(new int[] { 0, 0, 0, 0, 1 });
      var list4 = new List<int>();
      list4.AddRange(new int[] { 0, 1, 0, 0, 0 });

      var grid = new List<List<int>> {list1,list2,list3,list4};
      Assert.Equal(2, HoursToInfectAllHumans(grid.Count, grid[0].Count, grid));
    }

    [Fact]
    public void Test2()
    {
      var list1 = new List<int>();
      list1.AddRange(new int[] { 2, 1, 1 });
      var list2 = new List<int>();
      list2.AddRange(new int[] { 0, 1, 1 });
      var list3 = new List<int>();
      list3.AddRange(new int[] { 1, 0, 1 });
      var grid = new List<List<int>> { list1, list2, list3 };
      Assert.Equal(1, HoursToInfectAllHumans(grid.Count, grid[0].Count, grid));
    }
    [Fact]
    public void Test3()
    {
      var list1 = new List<int>();
      list1.AddRange(new int[] { 0, 2 });
      var grid = new List<List<int>> { list1};
      Assert.Equal(-1, HoursToInfectAllHumans(grid.Count, grid[0].Count, grid));
    }

    //if there are no humans then return zero
    //if in the end, there are still humans then return -1
    public int HoursToInfectAllHumans(int rows, int columns, List<List<int>> grid)
    {
      if(grid?.Count==0)
      {
        return 0;
      }

      int timeElapsed = 0;
      int totalHumans = 0;
      int totalZombies = 0;
      var queue = new Queue<int[]>();
      for (var outer=0;outer< rows; outer++)
      {
        for (var inner= 0; inner < columns; inner++)
        {
          if(grid[outer][inner] == (int)Element.Human)
          {
            totalHumans++;
          }
          else if (grid[outer][inner] == (int)Element.Zombie)
          {
            queue.Enqueue(new int[] { outer, inner });
            totalZombies++;
          }
        }
      }
      if (totalHumans == 0 && totalZombies>0)
      {
        return 0;
      }
      if (totalZombies ==0)
      {
        return -1;
      }
      while (queue.Count>0)
      {
        int queueCount=queue.Count;
        for (int counter = 0; counter < queueCount; counter++)
        {
          var rowColumn=queue.Dequeue();
          var row = rowColumn[0];
          var column= rowColumn[1];

          //itemLeft
          if (column - 1 >= 0 && grid[row][column - 1] == (int)Element.Human)
          {
            grid[row][column - 1] = (int)Element.Zombie;
            queue.Enqueue(new int[] { row, column - 1 });
            totalHumans--;
          }
          //itemRight
          if (column + 1 < columns && grid[row][column + 1] == (int)Element.Human)
          {
            grid[row][column + 1] = (int)Element.Zombie;
            queue.Enqueue(new int[] { row, column + 1 });
            totalHumans--;
          }
          //itemAbove
          if (row - 1 >= 0 && grid[row - 1][column] == (int)Element.Human)
          {
            grid[row - 1][column] = (int)Element.Zombie;
            queue.Enqueue(new int[] { row-1, column});
            totalHumans--;
          }
          //itemBelow
          if (row + 1 < rows && grid[row + 1][column] == (int)Element.Human)
          {
            grid[row + 1][column] = (int)Element.Zombie;
            queue.Enqueue(new int[] { row+1, column});
            totalHumans--;
          }
        }
        timeElapsed += 1;
        if (totalHumans ==0)
        {
          break;
        }
      }
      
      if (totalHumans > 0)
      {
        return -1;
      }

      return timeElapsed;
    }
  }
}
