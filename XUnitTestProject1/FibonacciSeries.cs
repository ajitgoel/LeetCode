using Xunit;
using System.Linq;
using System;

namespace XUnitTestProject1
{  
  public class FibonacciSeries
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(0, Get(0));
      Assert.Equal(1, Get(1));
      Assert.Equal(1, Get(2));
      Assert.Equal(2, Get(3));
      Assert.Equal(3, Get(4));
      Assert.Equal(5, Get(5));
      Assert.Equal(8, Get(6));
      Assert.Equal(13, Get(7));
    }
    List<int> cache=new List<int>();
    /*The next number is found by adding up the two numbers before it.
    * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34*/
    public int Get(int input)
    {
      if(Array.Exists(arraycache,x=>x.Equals(input)))
      {
        return input;
      }
      if(input==0  || input == 1)
      {
        return input;
      }
      var output= Get(input-1) + Get(input-2);
      cache.add
    }
  }
}
