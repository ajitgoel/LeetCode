using Xunit;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace Namely
{
  /*https://leetcode.com/problems/evaluate-reverse-polish-notation/
  Evaluate the value of an arithmetic expression in Reverse Polish Notation.
  Valid operators are +, -, *, and /. Each operand may be an integer or another expression.
  Note that division between two integers should truncate toward zero.
  It is guaranteed that the given RPN expression is always valid. That means the expression would always evaluate to a result, and there will not be any division by zero operation.
  Constraints:
  1 <= tokens.length <= 104
  tokens[i] is either an operator: "+", "-", "*", or "/", or an integer in the range [-200, 200].
1. If a value appears next in the expression, push this value on to the stack.
2. If an operator appears next, pop two items from the top of the stack and 
  push the result of the operation on to the stack.
   */
  public class EvaluateReversePolishNotation
  {
    [Fact]
    public void Test()
    {
      Get(new string[] {"2", "1", "+", "3", "*"}).Should().Be(9);
      Get(new string[] {"4", "13", "5", "/", "+" }).Should().Be(6);
      Get(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }).
        Should().Be(22); 
    }
    public int Get(string[] inputs)
    {
      var stack = new Stack<int>();
      var runningSum=default(int);
      foreach (var input in inputs)
      {
        if(int.TryParse(input, out int inputAsInt))
        {
          stack.Push(inputAsInt);
        }
        else
        {
          //if input is "4", "13", "5", "/", "+" then we need to do 13/5
          //therefore 13 is number2, 5 is number1
          var number1 =stack.Pop();
          var number2=stack.Pop();
          runningSum=input.Operator(number2,number1);
          stack.Push(runningSum);
        }
      }
      return runningSum;
    }    
  }
  public static class Extension
  {
    public static int Operator(this string logic, int x, int y)
    {
      switch (logic)
      {
        case "+": return x + y;
        case "-": return x - y;
        case "/": return x /y;
        case "*": return x * y;
        default: throw new Exception("invalid logic");
      }
    }
  }
}
