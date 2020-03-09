using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
  [DebuggerDisplay("{DebuggerDisplay,nq}")]
  public class MyLinkedList<T> : LinkedList<T>
  {
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay
    {
      get
      {
        return JsonConvert.SerializeObject(this);
      }
    }
  }
  public class CheckChainStatusTest
  {
    [Fact]
    public void Test2()
    {
      string return2 = CheckChainStatus("4-2;BEGIN-3;3-4;2-3");
      Assert.Equal("BAD", return2);
    }
    [Fact]
    public void Test1()
    {
      string return1 = CheckChainStatus("4-2;BEGIN-3;3-4;2-END");
      Assert.Equal("GOOD", return1);
    }
    [Fact]
    public void Test3()
    {
      string return1 = CheckChainStatus("4-2;BEGIN-3;3-4;2-END;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;;3-4;");
      Assert.Equal("BAD", return1);
      Assert.Equal("BAD", CheckChainStatus(""));
    }

    [Fact]
    public void Test4()
    {
      Assert.Equal("BAD", CheckChainStatus("4-1;BEGIN-3;3-4;2-END"));
      Assert.Equal("BAD", CheckChainStatus("4-10001;BEGIN-3;3-4;2-END"));
    }
    public string CheckChainStatus(string chain)
    {
      try
      {
        var keyValues = chain.Split(';');
        var dictionary = keyValues.Select(x => x.Split('-')).ToDictionary(x => x[0], x => x[1]);
        //System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(dictionary));
        var beginEnd = new List<string>() { "BEGIN", "END" };
        var dictionaryValuesWithoutBeginEnd = dictionary.Values.Except(beginEnd.AsEnumerable()).Select(int.Parse);

        if (dictionary.Keys.Count() < 1 || dictionary.Keys.Count() > 500 ||
          dictionaryValuesWithoutBeginEnd.Min() < 2 || dictionaryValuesWithoutBeginEnd.Max() > 10000)
        {
          return "BAD";
        }
        var linkedList = new MyLinkedList<string>();
        
        dictionary.TryGetValue("BEGIN", out string beginValue);
        if (string.IsNullOrEmpty(beginValue))
        {
          return "BAD";
        }

        var firstNode = linkedList.AddFirst("BEGIN");
        var secondNode=linkedList.AddAfter(firstNode, beginValue);
        dictionary.Remove("BEGIN");

        var currentValueOrKey = beginValue;
        var currentNode=secondNode;
        while (currentValueOrKey.Equals("END")==false)
        {
          dictionary.TryGetValue(currentValueOrKey, out string currentValue);
          if (string.IsNullOrEmpty(currentValue))
          {
            return "BAD";
          }
          currentNode = linkedList.AddAfter(currentNode, currentValue);
          dictionary.Remove(currentValueOrKey);
          currentValueOrKey = currentValue;
        }
        return "GOOD";
      }
      catch
      {
        return "BAD";
      }
    }
  }
}
