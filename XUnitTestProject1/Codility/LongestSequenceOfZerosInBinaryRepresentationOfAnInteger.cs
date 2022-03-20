using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;

namespace XUnitTestProject1
{
  public class LongestSequenceOfZerosInBinaryRepresentationOfAnInteger
  {
    [Fact]
    public void Test1()
    {
      solution(1041).Should().Be(5);//10000010001 
      solution(32).Should().Be(0);//100000
      solution(9).Should().Be(2);
      solution(529).Should().Be(4);
      solution(20).Should().Be(1);
      solution(15).Should().Be(0);
      solution(32).Should().Be(0);
    }
    //Loop through all indices, if character is 1, store that index in array.
    public int solution(int N)
    {
      string binarystring = Convert.ToString(N, 2);
      var ones=new List<int>();
      for(var counter=0;counter<binarystring.Length;counter++)
      {
        if(binarystring[counter]=='1')
        {
          ones.Add(counter);
        }
      }
      if(ones.Count<=1)
      {
        return 0;
      }
      var maxlength = 0;
      for (var counter = 0; counter < ones.Count-1; counter++)
      {
        var start = ones[counter] + 1;
        var length = ones[counter + 1]-start;
        var counterlength = binarystring.Substring(start, 
          length).Length;
        if (maxlength<counterlength)
        {
          maxlength = counterlength;
        }
      }
      return maxlength;
    }
  }
}
