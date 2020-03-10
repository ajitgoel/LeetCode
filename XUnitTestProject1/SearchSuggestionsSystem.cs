using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{  
  public class SearchSuggestionsSystem
  {
    enum Element
    {
      WATER = '0',
      LAND= '1'
    }

    [Fact]
    public void Test1()
    {
      var output = new List<List<string>>
      {
        new List<string> { "mobile", "moneypot", "monitor" },
        new List<string> { "mobile", "moneypot", "monitor" },
        new List<string> { "mouse", "mousepad" },
        new List<string> { "mouse", "mousepad" },
        new List<string> { "mouse", "mousepad" }
      };
      Assert.Equal(output, SuggestedProducts(new[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" }, "mouse"));
    }

    [Fact]
    public void Test2()
    {
      var output = new List<List<string>>
      {
        new List<string> { "havana"},
        new List<string> { "havana"},
        new List<string> { "havana"},
        new List<string> { "havana"},
        new List<string> { "havana"},
        new List<string> { "havana"}
      };
      Assert.Equal(output, SuggestedProducts(new[] {"havana"}, "havana"));
    }
    [Fact]
    public void Test3()
    {
      var output = new List<List<string>>
      {
        new List<string> { "baggage", "bags", "banner"},
        new List<string> { "baggage", "bags", "banner"},
        new List<string> { "baggage", "bags"},
        new List<string> { "bags"}
      };
      Assert.Equal(output, SuggestedProducts(new[] { "bags", "baggage", "banner", "box", "cloths" }, "bags"));
    }

    [Fact]
    public void Test4()
    {
      var output = new List<List<string>>
      {
        new List<string> { ""},
        new List<string> { "" },
        new List<string> { "" },
        new List<string> { "" },
        new List<string> { "" },
        new List<string> { "" },
        new List<string> { "" }
      };
      Assert.Equal(output, SuggestedProducts(new[] { "havana" }, "tatiana"));
    }

    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
      return null;
      //if (grid == null)
      //{
      //  throw new ArgumentNullException(nameof(grid), "Grid input paramter should not be null");
      //}

      ////var rows = grid.Length;

      ////if no elements are fresh then return zero
      //var gridArray=grid.SelectMany(x => x).ToArray();
      //if (gridArray.All(x => x == (char)Element.WATER) == true)
      //{
      //  return 0;
      //}
      //if (gridArray.All(x => x == (char)Element.LAND) == true)
      //{
      //  return 1;
      //}
      //return 3;
      //var rottenOrangesLocation = new Queue<int[]>();
      //for (int row = 0; row < rows; row++)
      //{
      //  var columns=grid[row].Length;
      //  for (int column = 0; column < columns; column++)
      //  {
      //    var item = grid[row][column];
      //    if (columns == 0 || columns > 10)
      //    {
      //      return 0;
      //    }

      //    if (item == (int)Element.ROTTEN)
      //    {
      //      rottenOrangesLocation.Enqueue(new int[] { row, column });
      //    }
      //  }
      //}

      //int timeElapsed = 0;
      //while (rottenOrangesLocation.Count>0)
      //{
      //  var rottenOrangesCount=rottenOrangesLocation.Count;
      //  for (int counter = 0; counter < rottenOrangesCount; counter++)
      //  {
      //    var item = rottenOrangesLocation.Dequeue();
      //    var row = item[0];
      //    var column = item[1];
      //    var columns = grid[row].Length;
      //    //itemLeft
      //    if (column - 1 >= 0 && grid[row][column - 1] == (int)Element.FRESH)
      //    {
      //      grid[row][column - 1] = (int)Element.ROTTEN;
      //      rottenOrangesLocation.Enqueue(new int[] { row, column - 1 });
      //    }
      //    //itemRight
      //    if (column + 1 < columns && grid[row][column + 1] == (int)Element.FRESH)
      //    {
      //      grid[row][column + 1] = (int)Element.ROTTEN;
      //      rottenOrangesLocation.Enqueue(new int[] { row, column + 1 });
      //    }
      //    //itemAbove
      //    if (row - 1 >= 0 && grid[row - 1][column] == (int)Element.FRESH)
      //    {
      //      grid[row - 1][column] = (int)Element.ROTTEN;
      //      rottenOrangesLocation.Enqueue(new int[] { row - 1, column });
      //    }
      //    //itemBelow
      //    if (row + 1 < rows && grid[row + 1][column] == (int)Element.FRESH)
      //    {
      //      grid[row + 1][column] = (int)Element.ROTTEN;
      //      rottenOrangesLocation.Enqueue(new int[] { row + 1, column });
      //    }
      //  }
      //  timeElapsed += 1;

      //  if (grid.SelectMany(x => x).ToArray().All(x => new[] { (int)Element.ROTTEN, (int)Element.EMPTY }.Contains(x)) == true)
      //  {
      //    break;
      //  }
      //}
      ////if any of the elements are still fresh then it means that they are unreachable, return -1 in this case
      //if (grid.SelectMany(x => x).ToArray().Any(x => x==(int)Element.FRESH) == true)
      //{
      //  return -1;
      //}
      //return timeElapsed;
    }
  }
}
