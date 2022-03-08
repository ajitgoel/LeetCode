using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestProject1
{  
  public class DuplicateCountClass
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(0, DuplicateCount(""));
      Assert.Equal(0, DuplicateCount("abcde"));
      Assert.Equal(2, DuplicateCount("aabbcde"));
      Assert.Equal(2, DuplicateCount("aabBcde"));
      Assert.Equal(1, DuplicateCount("Indivisibility"));
      Assert.Equal(2, DuplicateCount("Indivisibilities"));
    }
    public static int DuplicateCount(string str)
    {
      if(string.IsNullOrEmpty(str))
      {
        return 0;
      }
      var dictionary = new Dictionary<string, int>();
      for(var i=0;i<str.Length;i++)
      {
        var lowerstring = str.ToLowerInvariant();
        if (dictionary.ContainsKey(lowerstring[i].ToString())==false)
        {
          dictionary.Add(lowerstring[i].ToString(), 1);
        }
        else
        {
          dictionary[lowerstring[i].ToString()] = dictionary[lowerstring[i].ToString()] + 1;
        }
      }
      return dictionary.Values.Where(x => x > 1).Count();
    }
  }
}
