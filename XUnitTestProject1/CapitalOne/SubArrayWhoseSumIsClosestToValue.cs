using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1.CapitalOne
{
  public class Stairs
  {
    [Fact]
    public void Test()
    {
      string str = String.Empty;
      PrintAllWays(5, str);
    }
    void PrintAllWays(int n, string str)
    {
      string str1 = str;
      StringBuilder sb = new StringBuilder(str1);
      if (n == 0)
      {
        Debug.WriteLine(str1);
        return;
      }
      if (n >= 1)
      {
        sb = new StringBuilder(str1);
        PrintAllWays(n - 1, sb.Append('1').ToString());
      }
      if (n >= 2)
      {
        sb = new StringBuilder(str1);
        PrintAllWays(n - 2, sb.Append('2').ToString());
      }
    }
    //public List<int[]> Calculate(int noOfStairs, int maximumNoOfSteps)
    //{
    //  for (int counter1=0;counter1<noOfStairs; counter1++)
    //  {
    //    for (int counter2 = 0; counter2 < maximumNoOfSteps; counter2++)
    //    {

    //    }
    //  }

    //}
  }
  public class SubArrayWhoseSumIsClosestToValue
  {
    [Fact]
    public void Test()
    {
      //Assert.True(Maskify("4556364607935616") == "############5616");
      //Assert.True(Maskify("64607935616") == "#######5616");
      //Assert.True(Maskify("1") == "1");
      //Assert.True(Maskify("") == "");
      //Assert.True(Maskify("Skippy") == "##ippy");
      //Assert.True(Maskify("Nananananananananananananananana Batman!") == "####################################man!");
    }
    //public (int, int) FirstTwoElementsInArrayWhoseSumIsMinimum(int[] array)
    //{
    //  if(array == null ||array.Length<2)
    //  {
    //    throw new Exception("Invalid input");
    //  }
    //  //20, -22, 10, -11, 0, -1 => 20, 10, 0, -1, -11, -22
    //  //1. order by increasing values,
    //  //2. compare left array value to right array value, if sum is less 
    //  var sortedarray =array.OrderByDescending(x=>x);
    //  var currentleftelementposition = 0;
    //  var currentrightelementposition = array.Length - 1;
      
    //  var minimumleftelementposition = 0;
    //  var minimumrightelementposition = array.Length - 1;
      
    //  var minimumsum = int.MaxValue;
    //  var sum = array[currentleftelementposition] +array[currentrightelementposition];
    //  if (Math.Abs(sum)< Math.Abs(minimumsum))
    //  {
    //    minimumleftelementposition = currentleftelementposition;
    //    minimumrightelementposition = currentrightelementposition;
    //    minimumsum = sum;
    //  }
    //}
  }
}
