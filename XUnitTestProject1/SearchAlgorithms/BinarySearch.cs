using System.Linq;
using Xunit;

namespace XUnitTestProject1.SearchAlgorithms
{  
  public class BinarySearch
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(3, Apply(new int[] { 10,20,30,40,50}, 40));
      Assert.Equal(1, Apply(new int[] { 10, 20, 30, 40, 50 }, 20));
    }

    public static int Apply(int[] sortedArray, int valueToSearch)
    {

      var result1=Enumerable.Range(1, 10).Select(x => x + 2);
      var result2 = Enumerable.Range(1, 10).Aggregate((acc, x) => acc + x);
      var result3 = Enumerable.Range(1, 10).Where(x => x % 2 == 0);

      if (sortedArray==null || sortedArray.Length==0)
      {
        return -1;
      }

      int lowerBound = 0;
      int length = sortedArray.Length;
      int upperBound = length - 1;
      while (lowerBound <= upperBound)
      {
        int midIndex = (lowerBound + upperBound) / 2;
        if (sortedArray[midIndex] == valueToSearch)
        {
          return midIndex;
        }
        if (sortedArray[midIndex] < valueToSearch)
        {
          lowerBound = midIndex + 1;
        }
        else
        {
          upperBound = midIndex - 1;
        }
      }
      return -1;
    }
  }
}
