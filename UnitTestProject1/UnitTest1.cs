using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace UnitTestProject1
{
  public class UnitTest2
  {
    [Fact]
    public void Test1()
    {
      string return1 = CheckChainStatus("4-2;BEGIN-3;3-4;2-END");
      Assert.Equal("GOOD", return1);
    }

    [Fact]
    public void Test2()
    {
      string return2 = CheckChainStatus("4-2;BEGIN-3;3-4;2-3");
      Assert.Equal("BAD", return2);
    }

    public string CheckChainStatus(string chain)
    {
      var keyValues = chain.Split(';');
      var dictionary = keyValues.ToDictionary(x => x[0], x => x[1]);
      if (dictionary.Count > 0)
      {
        return "GOOD";
      }
      else
      {
        return "BAD";
      }
    }
  }

  //[TestClass]
  //public class UnitTest1
  //{
  //  [TestMethod]
  //  public void TestMethod1()
  //  {
  //    int result1 = ClassLibrary1.Class1.minSum2(new List<int>() { 10, 20, 7 }, 4);
  //    Assert.AreEqual(14, result1);

  //    int result2 = ClassLibrary1.Class1.minSum2(new List<int>() { 20,30,10,6,5}, 3);
  //    Assert.AreEqual(39, result2);

  //    int result3 = ClassLibrary1.Class1.minSum2(new List<int>() { 30, 30, 30 }, 3);
  //    Assert.AreEqual(45, result3);

  //    int result4 = ClassLibrary1.Class1.minSum2(new List<int>() { 30, 30, 30 }, 3);
  //    Assert.AreEqual(45, result4);

  //    var list = new List<int>();
  //    for (var counter=0;counter<10000;counter++)
  //    {
  //      list.Add(10000);
  //    }
  //    var watch = System.Diagnostics.Stopwatch.StartNew();
  //    int result5 = ClassLibrary1.Class1.minSum2(list, 50000);
  //    Assert.AreEqual(250000000, result5);
  //    watch.Stop();
  //    var elapsedMs = watch.ElapsedMilliseconds;
  //  }

  //}
}
