using Xunit;

namespace XUnitTestProject1.CapitalOne
{  
  public class CreditCardMask
  {
    [Fact]
    public void Test()
    {
      var array = new[] { 1,2,3,4,5,6,7,8,9,0};
      var result= findSubArrayCloseToAValue(array, 0);
      Assert.Equal(result[0],1);
      Assert.Equal(result[1], 0);
    }
    public int[] findSubArrayCloseToAValue(int[] array, int k)
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
