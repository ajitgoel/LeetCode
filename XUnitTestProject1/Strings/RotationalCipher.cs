using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace Strings.FaceBook
{
  /*One simple way to encrypt a string is to "rotate" every alphanumeric character by a certain amount. 
Rotating a character means replacing it with another character that is a certain number 
of steps away in normal alphabetic or numerical order.
For example, if the string "Zebra-493?" is rotated 3 places, the resulting string is "Cheud-726?". 
Every alphabetic character is replaced with the character 3 letters higher 
(wrapping around from Z to A), and every numeric character replaced with the character 
3 digits higher (wrapping around from 9 to 0). 
Note that the non-alphanumeric characters remain unchanged.
Given a string and a rotation factor, return an encrypted string.*/
  public class RotationalCipher
  {
    [Fact]
    public void Test1()
    {
      rotationalCipher("a9?", 3).Should().Be("d2?");
      rotationalCipher("Zebra-493?", 3).Should().Be("Cheud-726?");
      rotationalCipher("abcdefghijklmNOPQRSTUVWXYZ0123456789",39).Should().
        Be("nopqrstuvwxyzABCDEFGHIJKLM9012345678");
    }
    public string rotationalCipher(string input, int rotationFactor)
    {
      var result = string.Empty;
      for (var counter = 0; counter < input.Length; counter++)
      {
        var inputatcounter=input[counter];
        if(char.IsNumber(inputatcounter))
        {
          //0=>3,7=>10=>0, 9=>12=>2
          var valueafterrotation = Convert.ToInt32(inputatcounter) + rotationFactor;
          if(valueafterrotation>=10)
          {
            valueafterrotation -= 10;
          }
          result += valueafterrotation;
        }
        else if(char.IsLetter(inputatcounter))
        {
          char d=char.IsUpper(inputatcounter) ? 'A' : 'a';
          char temp=(char)((((inputatcounter + rotationFactor)-d)%26)+d);
          result += temp;
        }
        else
        {
          result += inputatcounter;
        }
      }
      return result;
    }
  }
}