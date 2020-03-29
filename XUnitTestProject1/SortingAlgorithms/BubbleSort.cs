using Xunit;

namespace XUnitTestProject1.SortingAlgorithms
{  
  public class BubbleSort
  {
    [Fact]
    public void Test()
    {
      var array=new int[] { 50, 40, 30, 20, 10 };
      Apply(array);
      Assert.Equal(array[0], 10);
      Assert.Equal(array[1], 20);
      Assert.Equal(array[2], 30);
      Assert.Equal(array[3], 40);
      Assert.Equal(array[4], 50);
    }

    public static void Apply(int[] array)
    {
      if(array==null || array.Length==0)
      {
        return;
      }

      for (int outerCounter = 0; outerCounter <= array.Length - 2; outerCounter++)
      {
        for (int innerCounter = 0; innerCounter <= array.Length - 2; innerCounter++)
        {
          if (array[innerCounter] > array[innerCounter + 1])
          {
            int temp = array[innerCounter + 1];
            array[innerCounter + 1] = array[innerCounter];
            array[innerCounter] = temp;
          }
        }
      }
    }
  }
}
