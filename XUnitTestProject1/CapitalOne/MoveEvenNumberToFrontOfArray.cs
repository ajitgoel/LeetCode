using System;
using Xunit;

namespace XUnitTestProject1
{
  public class MoveEvenNumberToFrontOfArray
  {
    [Fact]
    public void Test()
    {
      var array1 = new int[] {1,2,3,4,5,6,7,8,9,10};
      Calculate(array1);
      Assert.True(array1[0] == 10);
      Assert.True(array1[1] == 8);
      Assert.True(array1[2] == 6);
      Assert.True(array1[3] == 4);
      Assert.True(array1[4] == 2);
      Assert.True(array1[5] == 9);
      Assert.True(array1[6] == 7);
      Assert.True(array1[7] == 5);
      Assert.True(array1[8] == 3);
      Assert.True(array1[9] == 1);
    }
    public static int[] Calculate(int[] array)
    {
      if (array == null)
      {
        throw new Exception("invalid input");
      }
      int left = 0, right = array.Length - 1;
      while(left<right)
      {
        while(left<array.Length && array[left]%2==0)
        {
          left++;
        }
        while (right>= 0 && array[right] % 2 != 0)
        {
          right--;
        }
        if(left<right)
        {
          var temp=array[left];
          array[left]=array[right];
          array[right] = temp;
        }
      }
      return array;
    }
  }
}
