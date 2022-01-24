using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1.CapitalOne
{  
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
    public (int, int) FirstTwoElementsInArrayWhoseSumIsMinimum(int[] array)
    {
      if(array == null ||array.Length<2)
      {
        throw new Exception("Invalid input");
      }
      //20, -22, 10, -11, 0, -1 => 20, 10, 0, -1, -11, -22
      //1. order by increasing values,
      //2. compare left array value to right array value, if sum is less 
      var sortedarray =array.OrderByDescending(x=>x);
      var currentleftelementposition = 0;
      var currentrightelementposition = array.Length - 1;
      
      var minimumleftelementposition = 0;
      var minimumrightelementposition = array.Length - 1;
      
      var minimumsum = int.MaxValue;
      var sum = array[currentleftelementposition] +array[currentrightelementposition];
      if (Math.Abs(sum)< Math.Abs(minimumsum))
      {
        minimumleftelementposition = currentleftelementposition;
        minimumrightelementposition = currentrightelementposition;
        minimumsum = sum;
      }
    }
  }
}
