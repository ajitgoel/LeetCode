using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace XUnitTestProject1.Graphs
{
  //O(rc): Time | O(rc): Space where r is no of rows and c is no of cols. 
  public class SizeOfMinimumIslandInJaggedGrid
  {
    [Fact]
    public void Test1()
    {
      string[][] grid =  {
        new string[]{"W", "L", "W", "W", "W"},
        new string[]{"W", "L", "W", "W", "W"},
        new string[]{"W", "W", "W", "L", "W"},
        new string[]{"W", "W", "L", "L", "W"},
        new string[]{"L", "W", "W", "L", "L"},
        new string[]{"L", "L", "W", "W", "W"}
      };
      Calculate(grid).Should().Be(2);
    }
    [Fact]
    public void Test2()
    {
      string[][] grid =  {
        new string[]{"L", "W", "W", "L", "W" },
        new string[]{"L", "W", "W", "L", "L" },
        new string[]{"W", "L", "W", "L", "W" },
        new string[]{"W", "W", "W", "W", "W" },
        new string[]{"W", "W", "L", "L", "L"}
      };
      Calculate(grid).Should().Be(1);
    }
    [Fact]
    public void Test3()
    {
      string[][] grid =  {
        new string[]{"L", "L", "L"},
        new string[]{"L", "L", "L"},
        new string[]{"L", "L", "L"}
      };
      Calculate(grid).Should().Be(9);
    }
    [Fact]
    public void Test4()
    {
      string[][] grid =  {
        new string[]{"W", "W"},
        new string[]{"L", "L"},
        new string[]{"W", "W"},
        new string[]{"W", "L"}
      };
      Calculate(grid).Should().Be(1);
    }
    /*Write a function, minimumIsland, that takes in a grid containing Ws and Ls. W represents water and L represents land. 
     * The function should return the size of the smallest island. An island is a vertically or horizontally connected region of land.
     * You may assume that the grid contains at least one island.*/
    public int Calculate(string[][] grid)
    {
      var visitedNodes = new HashSet<string>();
      var minimumsize = int.MaxValue;
      for (var row=0;row<grid.Length;row++)
      {
        for (var col= 0; col< grid[row].Length; col++)
        {
          var currentsize = Explore(grid, row, col, visitedNodes);
          if (currentsize >0 && currentsize < minimumsize)
          {
            minimumsize=currentsize;
          }
        }
      }
      return minimumsize;
    }
    public int Explore(string[][] grid, int row, int col, HashSet<string> visitedNodes)
    {
      if (row >= 0 && row < grid.Length) { }
      else
      {
        return 0;
      }
      if (col>= 0 && col< grid[row].Length) { }
      else
      {
        return 0;
      }
      if (grid[row][col] == "W") return 0;
      var position = $"{row},{col}";
      if (visitedNodes.Contains(position))
      {
        return 0;
      }
      visitedNodes.Add(position);
      var size = 1;
      size=size+Explore(grid, row-1, col, visitedNodes) + 
        Explore(grid, row + 1, col, visitedNodes) + 
        Explore(grid, row, col-1, visitedNodes)+
        Explore(grid, row, col+1, visitedNodes);
      return size;
    }
  }
}