using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace XUnitTestProject1
{
  public class GenerateArray
  {
    /*  A   B
     *  B   A
     */
    [Fact]
    public void Test1()
    {
      var array2 = Generate(2);
      var array3 = Generate(3);
      var array4 = Generate(4);
      var array5 = Generate(5);

      System.Diagnostics.Debug.Print(JsonConvert.SerializeObject(array2));
      System.Diagnostics.Debug.Print(JsonConvert.SerializeObject(array3));
      System.Diagnostics.Debug.Print(JsonConvert.SerializeObject(array4));
      System.Diagnostics.Debug.Print(JsonConvert.SerializeObject(array5));

    }
    public string[,] Generate(int arraylength)
    {
      var result = new string[arraylength, arraylength];
      var colors = new char[3] { 'R', 'B', 'G' };
      var initialvalue = new Random().Next(colors.Length);
      var colorelement = initialvalue;
      for (int outer = 0; outer < arraylength; outer++)
      {
        for (int inner = 0; inner < arraylength; inner++)
        {
          result[outer, inner] = colors[colorelement].ToString();
          colorelement++;
          if (arraylength == colors.Length)
          {
            colorelement++;
          }
          if (colorelement>=colors.Length)
          {
            colorelement = initialvalue;
          }
        }
      }
      return result;
    }
  }
}
