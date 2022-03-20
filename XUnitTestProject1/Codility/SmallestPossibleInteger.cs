using FluentAssertions;
using System;
using Xunit;

namespace XUnitTestProject1
{
  public class SmallestPossibleInteger
  {
    [Fact]
    public void Test1()
    {
      solution(new int[] {}).Should().Be(1);
      solution(new int[] { 1}).Should().Be(2);
      solution(new int[] { -1,-3}).Should().Be(1);
      solution(new int[] {1,2,3}).Should().Be(4);
      solution(new int[] { 1, 3, 6, 4, 1, 2}).Should().Be(5); 
    }
    public int solution(int[] A)
    {
      Array.Sort(A);
      var min = 0;
      var index = 0;
      while (index < A.Length)
      {
        if (A[index] > min + 1)
        {    
          break;
        }
        if (A[index] > min)
        {
          min = A[index];
        }
        index++;
      }
      return min + 1;
    }
    //public int solution(int[] A)
    //{
    //  if(A.Length==0)
    //  {
    //    return 1;
    //  }
    //  Array.Sort(A);
    //  var minvalue = A[0];
    //  var maxvalue = A[A.Length - 1];
    //  if(maxvalue<1)
    //  {
    //    return 1;
    //  }
    //  var result = 0;
    //  for (var counter = minvalue; counter < maxvalue; counter++)
    //  {
    //    if (A.Contains(counter)==false)
    //    {
    //      result = counter;
    //      break;
    //    }
    //  }
    //  if(result == 0)
    //  {
    //    if(maxvalue<1)
    //    {
    //      result = 1;
    //    }
    //    else
    //    {
    //      result = maxvalue + 1;
    //    }
    //  }
    //  return result;
    //}
  }
}
