using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestProject1
{
  public class FirstUniqueNumberInSequence
  {
    [Fact]
    public void Test1()
    {      
      solution(new int[] { 1,4,3,3,1,2}).Should().Be(4);
      solution(new int[] { 6,4,4,6}).Should().Be(-1);
    }
    public int solution(int[] N)
    {
      var dictionary=new Dictionary<int, int>();
      for(var counter=0;counter<N.Length;counter++)
      {
        var key=N[counter];
        if (dictionary.ContainsKey(key))
        {
          dictionary[key]= dictionary[key]+1;
        }
        else
        {
          dictionary.Add(key, 1);
        }        
      }
      var first=dictionary.Where(x => x.Value == 1).FirstOrDefault();
      return (first.Value==default?-1:first.Key);
    }
  }
}
