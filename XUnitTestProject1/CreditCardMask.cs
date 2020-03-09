using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{  
  public class CreditCardMask
  {
    [Fact]
    public void Test()
    {
      Assert.True(Maskify("4556364607935616") == "############5616");
      Assert.True(Maskify("64607935616") == "#######5616");
      Assert.True(Maskify("1") == "1");
      Assert.True(Maskify("") == "");
      Assert.True(Maskify("Skippy") == "##ippy");
      Assert.True(Maskify("Nananananananananananananananana Batman!") == "####################################man!");
    }
    public string Maskify(string text)
    {
      if (string.IsNullOrWhiteSpace(text) || text.Length<=4)
      {
        return text;
      }
      var length=text.Length;
      return new string('#', text.Length-4) + text.Substring(length - 4, 4);
    }
  }
}
