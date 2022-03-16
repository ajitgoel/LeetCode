using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace XUnitTestProject1
{
  public class TopKFrequentWords_Oracle
  {
    [Fact]
    public void Test()
    {
      var result1 = TopKFrequent(new string[] { "i", "love", "leetcode", "i", "love", "coding" }, 2);
      //"i" and "love" are the two most frequent words. Note that "i" comes before "love" due to a lower alphabetical order.
      result1.Should().Equal(new string[] { "i", "love" });

      var result2 = TopKFrequent(new string[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" }, 4);
      //"the", "is", "sunny" and "day" are the four most frequent words, with the number of occurrence being 4, 3, 2 and 1 respectively.
      result2.Should().Equal(new string[] { "the", "is", "sunny", "day" });
    }
    public static string[] TopKFrequent(string[] words, int k)
    {
      var dictionary = new Dictionary<string, int>();
      foreach (var counter in words)
      {
        if (dictionary.ContainsKey(counter) == false)
        { 
          dictionary.Add(counter, 1);
        }
        else
        {
          dictionary[counter]= dictionary[counter]+1;
        }
      }
      return dictionary.OrderByDescending(x => x.Value).Take(k).OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).Select(x=>x.Key).ToArray();
    }
  }
}
