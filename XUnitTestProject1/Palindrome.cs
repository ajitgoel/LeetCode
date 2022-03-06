using Xunit;

namespace XUnitTestProject1
{  
  public class Palindrome
  {
    [Fact]
    public void Test()
    {
      Assert.True(Get(636));
      Assert.True(GetUsingPointers("abcba"));
      Assert.False(GetUsingPointers("abcde"));
      Assert.True(GetUsingRecursion("abcba"));
      Assert.False(GetUsingRecursion("abcde"));
      Assert.True(GetUsingRecursion("abccba"));
    }
    //O(N): time complexity, O(N): space complexity
    public static bool GetUsingRecursion(string input, int pointer=0)
    {
      if (string.IsNullOrEmpty(input) == true)
      {
        return false;
      }
      var left = pointer;
      var right = input.Length - pointer-1;
      if(left<right)
      {
        if (input[left] != input[right])
          return false;
        else
          return GetUsingRecursion(input, left + 1);
      }
      return true;
    }
    //O(N): time complexity, O(1): space complexity
    public static bool GetUsingPointers(string input)
    {
      if(string.IsNullOrEmpty(input)==true)
      {
        return false;
      }
      var left = 0;
      var right = input.Length - 1;
      while (left<right)
      {
        if(input[left]!=input[right])
        {
          return false;
        }
        left++;
        right--;
      }
      return true;
    }
    public static bool Get(int input)
    {
      int invertedInput=0;
      int remainder;
      int tempInput = input;
      while (tempInput > 0)
      {
        remainder = tempInput % 10;
        invertedInput = (invertedInput * 10) + remainder;
        tempInput /= 10;
      }
      return (input == invertedInput);
      /*
      636/10=63, 6
      63/10=6, 3
      6/10=0  6
      */
    }
  }
}
