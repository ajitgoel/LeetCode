using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace Array_Oracle
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
      var array3 = Generate(3);//does not work for 3 by 3 array.
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
      var colors = new char[] { 'R', 'B', 'G' };
      var initialvalue = new Random().Next(colors.Length);
      var colorelement = initialvalue;
      for (int outer = 0; outer < arraylength; outer++)
      {
        for (int inner = 0; inner < arraylength; inner++)
        {
          if ((inner - 1 > 0 && result[outer, inner] != null && result[outer, inner - 1] != null &&
            result[outer, inner] == result[outer, inner - 1]) ||
            (inner + 1 < arraylength && result[outer, inner] != null && result[outer, inner + 1] != null &&
              result[outer, inner] == result[outer, inner + 1]) ||
            (outer + 1 < arraylength && result[outer, inner] != null && result[outer + 1, inner] != null &&
              result[outer, inner] == result[outer + 1, inner] ||
            (outer - 1 > 0 && result[outer, inner] != null && result[outer - 1, inner] != null &&
              result[outer, inner] == result[outer - 1, inner]))
          )
          {
            colorelement++;
            if (colorelement >= colors.Length)
            {
              colorelement = 0;
            }
            result[outer, inner] = colors[colorelement].ToString();
          }
          else
          {
            result[outer, inner] = colors[colorelement].ToString();
            colorelement++;
            if (colorelement >= colors.Length)
            {
              colorelement = 0;
            }
          }
        }
      }
      return result;
    }
  }
}
