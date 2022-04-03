using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace XUnitTestProject1.Graphs
{
  //O(rc): Time | O(rc): Space where r is no of rows and c is no of cols. 
  public class IslandCountInJaggedGrid
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
      Calculate(grid).Should().Be(3);
    }
    [Fact]
    public void Test2()
    {
      string[][] grid =  {
        new string[]{"L", "L", "L"},
        new string[]{"L", "L", "L"},
        new string[]{"L", "L", "L"}
      };
      Calculate(grid).Should().Be(1);
    }
    [Fact]
    public void Test3()
    {
      string[][] grid =  {
        new string[]{"W", "W"},
        new string[]{"W", "W"},
        new string[]{"W", "W"}
      };
      Calculate(grid).Should().Be(0);
    }

    /*Write a function, islandCount, that takes in a grid containing Ws and Ls. W represents water and L represents land. 
     * The function should return the number of islands on the grid. An island is a vertically or horizontally connected region of land.*/
    public int Calculate(string[][] grid)
    {
      var visitedNodes = new HashSet<string>();
      var count = 0;
      for (var row=0;row<grid.Length;row++)
      {
        for (var col= 0; col< grid[row].Length; col++)
        {
          if (Explore(grid, row, col, visitedNodes) == true)
          {
            count++;
          }
        }
      }
      return count;
    }
    public bool Explore(string[][] grid, int row, int col, HashSet<string> visitedNodes)
    {
      if (row >= 0 && row < grid.Length) { }
      else
      {
        return false;
      }
      if (col>= 0 && col< grid[row].Length) { }
      else
      {
        return false;
      }
      if (grid[row][col] == "W") return false;
      var position = $"{row},{col}";
      if (visitedNodes.Contains(position))
      {
        return false;
      }
      visitedNodes.Add(position);
      Explore(grid, row-1, col, visitedNodes);
      Explore(grid, row + 1, col, visitedNodes);
      Explore(grid, row, col-1, visitedNodes);
      Explore(grid, row, col+1, visitedNodes);
      return true;
    }
  }
}
