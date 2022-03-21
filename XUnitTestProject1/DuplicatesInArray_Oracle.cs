using System.Linq;
using Xunit;
using FluentAssertions;

namespace XUnitTestProject1
{
  public class DuplicatesInArray_Oracle
  {
    [Fact]
    public void Test()
    {
      var result1 = DoesArrayContainDuplicates(new int[] { 1, 2, 37, 56, 2 });
      result1.Should().BeTrue();

      var result2 = DoesArrayContainDuplicates(new int[] { 1, 2, 37, 56, 87 });
      result2.Should().BeFalse();
    }
    public static bool DoesArrayContainDuplicates(int[] words)
    {
      //approach 1: using linq
      //approach 2: add elements to hashset if it does not exist else return that duplicate is found
      //approach 3: sort array, in forloop if an element is same as the next element then we have a duplicate.
      return words.GroupBy(x => x).Any(x => x.Count()>1);
    }
  }
}
