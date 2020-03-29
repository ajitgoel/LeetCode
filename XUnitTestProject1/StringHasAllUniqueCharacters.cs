using Xunit;

namespace XUnitTestProject1
{  
  public class StringHasAllUniqueCharacters
  {
    [Fact]
    public void Test()
    {
      Assert.Equal(false, Get("aa"));
      Assert.Equal(false, Get("champa"));
      Assert.Equal(true, Get("abcdefghijklmnopqrstuvwxyz"));
    }
    public bool Get(string input)
    {
      if(string.IsNullOrWhiteSpace(input))
      {
        return true;
      }
      for(int outer=0;outer<input.Length-1;outer++)
      {
        for (int inner = outer+1; inner < input.Length; inner++)
        {
          if(input[outer] == input[inner])
          {
            return false;
          }
        }
      }
      return true;
    }
  }
}
