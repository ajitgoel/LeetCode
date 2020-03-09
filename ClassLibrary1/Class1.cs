using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
  public class Class1
  {
    public static int minSum(List<int> num, int k)
    {
      num.Sort();
      int returnSum = 0;

      bool hasBeenSorted = true;
      var i = 0;
      for (int counter = 0; counter < k; counter++)
      {
        if (num.Count() >k)
        {
          var maxNo = num[i];
          float divideByTwo = maxNo / 2.0f;
          decimal maxNoCeiling = Math.Ceiling(Convert.ToDecimal(divideByTwo));
          num[i] = Convert.ToInt32(maxNoCeiling);
          hasBeenSorted = false;
          i++;
        }
        else
        {
          if (hasBeenSorted == false)
          {
            num.Sort();

            hasBeenSorted = true;
          }
            var maxNo = num[counter];
            float divideByTwo = maxNo / 2.0f;
            decimal maxNoCeiling = Math.Ceiling(Convert.ToDecimal(divideByTwo));
            num[counter] = Convert.ToInt32(maxNoCeiling);
            i++;
          
        }
      }
      return num.Sum();
    }

    public static int minSum2(List<int> num, int k)
    {
      if(num.Count>=1 && num.Count<=100000 && k>=1 && k<=10000000)
      {
        var maxNo = num.Max();
        if(maxNo>=1 && maxNo<=10000)
        {
          var distinctNumbers = num.Distinct();
          if(distinctNumbers.Count() ==1)
          {
            var firstNumber = distinctNumbers.First();
            return (firstNumber* k)/2;
          }

          for (int counter = 0; counter < k; counter++)
          {
            maxNo = num.Max();
            var maxNoIndex = num.IndexOf(maxNo);
            float divideByTwo = maxNo / 2.0f;
            decimal maxNoCeiling = Math.Ceiling(Convert.ToDecimal(divideByTwo));
            num[maxNoIndex] = Convert.ToInt32(maxNoCeiling);
          }
          return num.Sum();
        }
      }
      return 0;
    }
  }
}
