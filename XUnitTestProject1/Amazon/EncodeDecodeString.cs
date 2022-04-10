using Xunit;
using System;
using FluentAssertions;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace Amazon
{
  /*https://www.youtube.com/watch?v=B1k_sxOSgv8
   */
  public class EncodeDecodeString
  {
    [Fact]
    public void Test()
    {
      Encode(new[] {"She", "is","a", "bitch"}).Should().Be("She3#is2#a1#bitch5#");
      Decode("She3#is2#a1#bitch5#").Should().ContainInOrder(new[] { "She", "is", "a", "bitch" });
    }
    public string Encode(string[] inputs)
    {
      var stringBuilder = new StringBuilder();
      foreach (var input in inputs)
      {
        stringBuilder.Append($"{input}{input.Length}#");
      }
      return stringBuilder.ToString();
    }
    public string[] Decode(string input)
    {
      var results = new List<string>();
      var start= 0;
      var counter = 0;
      while (counter < input.Length)
      {
        if(input[counter] =='#')
        {
          //She3#is2#a1#bitch5#
          int.TryParse(input[counter - 1].ToString(), out int length);
          results.Add(input.Substring(start, length));
          start = start + length + 2;
        }
        counter++;
      }
      return results.ToArray();
    }
  }
}
