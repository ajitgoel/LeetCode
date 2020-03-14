using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{  
  public class SearchSuggestionsSystem
  {
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
      var result = SuggestedProducts(new[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" }, "mouse");
      for (int counter= 0;counter< output.Count; counter++)
      {
        Assert.True(output[counter].SequenceEqual(result[counter]));
      }      
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

      var result = SuggestedProducts(new[] { "havana" }, "havana");
      for (int counter = 0; counter < output.Count; counter++)
      {
        Assert.True(output[counter].SequenceEqual(result[counter]));
      }
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
      var result = SuggestedProducts(new[] { "bags", "baggage", "banner", "box", "cloths" }, "bags");
      for (int counter = 0; counter < output.Count; counter++)
      {
        Assert.True(output[counter].SequenceEqual(result[counter]));
      }
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
      var result=SuggestedProducts(new[] { "havana" }, "tatiana");
      for (int counter = 0; counter < output.Count; counter++)
      {
        Assert.True(output[counter].SequenceEqual(result[counter]));
      }
    }
    /*
     * Given an array of strings products and a string searchWord. We want to design a system that suggests at most three product names 
     * from products after each character of searchWord is typed. Suggested products should have common prefix with the searchWord. 
     * If there are more than three products with a common prefix return the three lexicographically minimums products.
     * Return list of lists of the suggested products after each character of searchWord is typed. 
     */
    public static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
      IList<IList<string>> result = new List<IList<string>>();
      if (products == null || searchWord == null)
      {
        return result;
      }
      var orderedProducts = products.OrderBy(x => x).ToList();
      for (var counter = 0; counter < searchWord.Length; counter++)
      {
        var searchString = searchWord.Substring(0,counter+1);
        var partialList = orderedProducts.Where(x => x.StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase));
        if (partialList.Any())
        {
          result.Add(partialList.Take(3).ToList());
        }
        else
        {
          result.Add(new List<string> {""});
        }
      }
      return result;
    }
  }
}
