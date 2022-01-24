using System;
using Xunit;
using System.Linq;

namespace XUnitTestProject1
{

  public class ArrayWhoseSumIsClosestToZero
  {
    [Fact]
    public void Test()
    {
      var array1 = new int[]{-10,-2,-1,3,5,9};
      var result1= Calculate(array1);
      Assert.True(result1[0]==-10);
      Assert.True(result1[1] == 9);

      var array2 = new int[] { -10, 9 }; 
      var result2 = Calculate(array2);
      Assert.True(result2[0] == -10);
      Assert.True(result2[1] == 9);
    }
    public static int[] Calculate(int[] array)
    {
      if(array==null || array.Length<2)
      {
        throw new Exception("invalid input");
      }
      var sortedarray=array.OrderBy(x=>x).ToArray();
      int left = 0, right = sortedarray.Length - 1;
      int minimumleft = left,minimumright = right;
      int currentsum = Math.Abs(sortedarray[left] + sortedarray[right]);
      int minimumsum = currentsum;
      while (left<right)
      {
        currentsum = Math.Abs(sortedarray[left] + sortedarray[right]);
        if (currentsum < 0 && currentsum<minimumsum)
        {
          minimumsum = currentsum;
          minimumleft = left;
          minimumright = right;
          left++;
        }
        else
        {
          right--;
        }
      }
      return new int[] { sortedarray[minimumleft],sortedarray[minimumright] };
    }
  }
}
