using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ConsoleApp1
{
  public class Program
  {
    static void Main(string[] args)
    {
      var input=args[0];
      Console.WriteLine();
    }

    public static int minSum(List<int> num, int k)
    {
      for (int counter= 0; counter < k; counter++)
      {
        int maxNo = num.Max();
        int maxNoIndex = num.IndexOf(maxNo);
        decimal divideByTwo = maxNo / 2;
        decimal maxNoCeiling = Math.Ceiling(divideByTwo);
        num[maxNoIndex] = Convert.ToInt32(maxNoCeiling);
      }
      return num.Sum();
    }
  }
}
