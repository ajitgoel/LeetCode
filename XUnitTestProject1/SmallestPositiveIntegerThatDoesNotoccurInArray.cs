using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
  public class SmallestPositiveIntegerThatDoesNotOccurInArray
  {
    [Fact]
    public void Test1()
    {
      //var result1=solution(new int[] { 1, 3, 6, 4, 1, 2 });
      //Assert.Equal(5, result1);
      var result2 = solution(new int[] { 1, 2, 3 });
      Assert.Equal(4, result2);
      var result3=solution(new int[] { -1, -3 });
      Assert.Equal(1, result3);
    }

    public int solution(int[] A)
    {
      if(A.Length < 1 || A.Length> 100000)
      {
        throw new Exception("Invalid");
      }
      int result= 1;
      foreach(var element in A)
      {
        if(element < -1000000 || element > 1000000)
        {
          throw new Exception("Invalid");
        }
      }
      
      int max = A.Max();
      if(max<1)
      {
        return 1;
      }
      //go over (max number-1) till 1 and check if the number exists in array, if it does not exist then return that number else return (max number +1)
      var currentResult = max - 1;
      do
      {
        if (A.Contains(currentResult))
        {
          currentResult = currentResult - 1;
          if(currentResult ==0)
          {
            return (max+1);
          }
        }
      }while(currentResult<1);
      return max;
    }
  }
}
