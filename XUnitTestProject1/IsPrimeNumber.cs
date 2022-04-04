using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace XUnitTestProject1
{
  public class IsPrimeNumber
  {
    [Fact]
    public void Test1()
    {
      Calculate(9).Should().Be(false);
      Calculate(64).Should().Be(false);
      Calculate(11).Should().Be(true);
    }
    public bool Calculate(int input)
    {
      if (input < 2) return false;
      for (var counter = 2; counter <= Math.Sqrt(input); counter++)
      {
        if (input % counter == 0) return false;
      }
      return true;
    }
  }
}