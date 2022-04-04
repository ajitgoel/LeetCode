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
      rotationalCipher("Zebra-493?", 3).Should().Be("Cheud-726?");//Does not work
      rotationalCipher("abcdefghijklmNOPQRSTUVWXYZ0123456789",39).Should().
        Be("nopqrstuvwxyzABCDEFGHIJKLM9012345678");//Does not work.
    }
    public string rotationalCipher(string input, int rotationFactor)
    {
      char[] buffer = input.ToCharArray();
      for (var counter = 0; counter < input.Length; counter++)
      {
        var letter = input[counter];
        if(char.IsNumber(letter))
        {
          //0=>3,7=>10=>0, 9=>12=>2
          letter = (char)(letter + rotationFactor);
          if (letter > '9')
          {
            letter = (char)(letter - 10);
          }
          buffer[counter] = letter;
        }
        else if(char.IsLetter(letter))
        {
          letter = (char)(letter + rotationFactor);
          if(char.IsUpper(letter)==false)
          {
            if (letter > 'z' )
            {
              letter = (char)(letter - 26);
            }
            else if (letter < 'a')
            {
              letter = (char)(letter + 26);
            }
          }
          else
          {
            if (letter > 'Z')
            {
              letter = (char)(letter - 26);
            }
            else if (letter < 'A')
            {
              letter = (char)(letter + 26);
            }
          }          
          buffer[counter] = letter;
        }
      }
      return new string(buffer);
    }
  }
}