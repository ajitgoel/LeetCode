using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{  
  public class SumOfConcantenationOfEveryPossibleCombination_CodeFights
  {
    [Fact]
    public void Test1()
    {
      var output = 1344;
      var result = ConcatenationsSum(new[] {10,2});
      Assert.Equal(output, result);
    }

    [Fact]
    public void Test2()
    {
      var output = 88;
      var result = ConcatenationsSum(new[] {8});
      Assert.Equal(output, result);
    }

    /*Given an array of positive integers a, your task is to calculate the sum of every possible a[i] ∘ a[j], 
     * where a[i] ∘ a[j] is the concatenation of the string representations of a[i] and a[j] respectively.*/
    public long ConcatenationsSum(int[] items)
    {
      if(items ==  null || items.Length==0 ||items.Length > 106)
      {
        throw new Exception("invalid input parameter: items");
      }
      if (items.Any(x => x<=0) || items.Any(x => x > 106))
      {
        throw new Exception("Invalid input parameter: items");
      }
      if (items.Sum(x => x) >= 253)
      {
        throw new Exception("Sum of all items should be less than 253");
      }

      long output = 0;
      for (var counter1 = 0; counter1 < items.Length; counter1++)
      {
        for (var counter2 = 0; counter2 < items.Length; counter2++)
        {
          var stringBuilder = new System.Text.StringBuilder(); 
          stringBuilder.Append(items[counter1]);
          stringBuilder.Append(items[counter2]);
          output = output + int.Parse(stringBuilder.ToString(), System.Globalization.NumberStyles.Number);
        }
      }
      return output;
    }
  }
}
