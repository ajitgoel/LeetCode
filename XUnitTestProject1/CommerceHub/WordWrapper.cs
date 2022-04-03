using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace CommerceHub
{
  public sealed class WordWrapper
  {
    public static List<string> WrapWords(string sourceString, int maximumCharactersPerLine)
    {
      var result = new List<string>();
      if (string.IsNullOrWhiteSpace(sourceString))
      {
        return result;
      }
      sourceString = sourceString?.Trim();
      var character = ' ';
      var words = sourceString.Split(character);
      var maxLengthOfWord = words.Max(x => x.Length);
      if (maxLengthOfWord > maximumCharactersPerLine)
      {
        throw new InvalidOperationException("The maximum character width should never be less than the longest word");
      }
      var line = words.First();
      var remainingWords = words.Skip(1);
      foreach (var word in remainingWords)
      {
        var temp = $"{line}{character}{word}";
        if (maximumCharactersPerLine < temp.Length)
        {
          result.Add(line);
          line = word;
        }
        else
        {
          line = temp;
        }
      }
      if (line.Length > 0)
      {
        result.Add(line);
      }
      return result;
    }
  }
  public class Runner
  {
    public sealed class WordWrapperTests
    {
      [Fact]
      public void IfMaximumCharacterWidthIsSmallerThanLongestWordThenAnExceptionShouldBeThrown()
      {
        var result = ()=> WordWrapper.WrapWords("Git ", 1);
        result.Should().Throw<InvalidOperationException>().WithMessage("The maximum character width should never be less than the longest word");        
      }
      [Fact]
      public void NonEmptySouceStringShouldReturnCorrectList_Test2()
      {
        List<string> expected1 = new List<string>() { "Git" };
        List<string> result1 = WordWrapper.WrapWords("Git ", 20);
        foreach (var counter in expected1)
        {
          result1.Should().Contain(counter);
        }
        List<string> expected2 = new List<string>() { "Git" };
        List<string> result2 = WordWrapper.WrapWords("Git ", 3);
        foreach (var counter in expected2)
        {
          result2.Should().Contain(counter);
        }
      }
      [Fact]
      public void EmptySouceStringShouldReturnEmptyList()
      {
        List<string> result1 = WordWrapper.WrapWords("", 20);
        result1.Should().BeEmpty();
        List<string> result2 = WordWrapper.WrapWords(" ", 20);
        result2.Should().BeEmpty();
      }

      [Fact]
      public void NonEmptySouceStringShouldReturnCorrectList_Test1()
      {
        var sourceString = "Git is best thought of as a tool for storing the history of a collection of files. It stores the history as a compressed collection of interrelated snapshots of the project’s contents. In Git each such version is called a commit.";
        var maximumCharactersPerLine = 20;
        var expected = new List<string>(){ "Git is best thought","of as a tool for","storing the history","of a collection of","files. It stores the","history as a",
          "compressed","collection of","interrelated","snapshots of the","project’s contents.","In Git each such","version is called a","commit."};
        var result = WordWrapper.WrapWords(sourceString, maximumCharactersPerLine);
        result.Count.Should().Be(expected.Count);
        foreach (var counter in expected)
        {
          result.Should().Contain(counter);
        }
      }
    }
  }
}
