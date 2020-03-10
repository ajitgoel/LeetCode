using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{  
  public class AmazonTopNBuzzwords
  {
    [Fact]
    public void Return_a_list_of_strings_of_the_most_popular_N_toys_in_order_of_most_to_least_frequentlycmentioned()
    {
      int topToys = 2;
      var toys = new string[] { "elsa","elmo", "legos", "drone", "tablet", "warcraft" };
      var quotes = new string[] { "Elmo is the hottest of the season! Elmo will be on every kid's wishlist!",
                    "The new Elmo dolls are super high quality",
                    "Expect the Elsa dolls to be very popular this year, Elsa!",
                    "Elsa and Elmo are the toys I'll be buying for my kids, Elsa is good",
                    "For parents of older kids, look into buying them a drone",
                    "Warcraft is slowly rising in popularity ahead of the holiday season"
                    };
      var result=Get(topToys, toys, quotes);
      var expectedResult = new string[] { "elmo", "elsa" };
      Assert.True(result.SequenceEqual(expectedResult));
    }

    [Fact]
    public void If_the_value_of_topToys_is_more_than_the_number_of_toys_return_the_names_of_only_the_toys_mentioned_in_the_quotes()
    {
      int topToys = 3;
      var toys = new string[] { "elmo", "elsa"};
      var quotes = new string[] { "Elmo is the hottest of the season! Elmo will be on every kid's wishlist!",
                    "The new Elmo dolls are super high quality",
                    "Expect the Elsa dolls to be very popular this year, Elsa!",
                    "Elsa and Elmo are the toys I'll be buying for my kids, Elsa is good",
                    "For parents of older kids, look into buying them a drone",
                    "Warcraft is slowly rising in popularity ahead of the holiday season"
                    };
      var result = Get(topToys, toys, quotes);
      var expectedResult = new string[] { "elmo", "elsa" };
      Assert.True(result.Length == 2);
      Assert.True(result.SequenceEqual(expectedResult));
    }
    
    [Fact]
    public void If_toys_are_mentioned_an_equal_number_of_times_in_quotes_sort_alphabetically()
    {
      int topToys = 3;
      var toys = new string[] { "elsa", "elmo"};
      var quotes = new string[] { 
        "Elmo is the hottest of the season! Elmo will be on every kid's wishlist!",
        "Expect the Elsa dolls to be very popular this year, Elsa!"
        };
      var result = Get(topToys, toys, quotes);
      var expectedResult = new string[] { "elmo", "elsa" };
      Assert.True(result.SequenceEqual(expectedResult));
    }

    public static string[] Get(int topToys, string[] toys, string[] quotes)
    {
      var dictionaryResult = new Dictionary<string, int>();
      foreach(var toy in toys)
      {
        dictionaryResult.Add(toy, 0);
      }
      
      foreach(var quote in quotes)
      {
        var lowerQuote = quote.ToLowerInvariant();
        var lowerQuoteSplitStrings=lowerQuote.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach(var lowerQuoteSplitString in lowerQuoteSplitStrings)
        {
          foreach (var toy in toys)
          {
            var lowerToy = toy.ToLowerInvariant();
            if (lowerQuoteSplitString.Contains(lowerToy))
            {
              dictionaryResult[toy] = dictionaryResult[toy] + 1;
              continue;
            }
          }
        }       
      }
      var noOfItemsToReturn = topToys > toys.Length ? toys.Length : topToys;
      var result=dictionaryResult.OrderByDescending(x => x.Value).Take(noOfItemsToReturn).OrderBy(x=>x.Key).Select(x=>x.Key).ToArray();
      System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(dictionaryResult));
      return result;
    }
  }
}
