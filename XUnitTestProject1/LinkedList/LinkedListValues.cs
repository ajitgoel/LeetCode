using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Structy
{
  public class LinkedListValues
  {
    public static void Recursive_Calculate(LinkedListNode<string> linkedListNode, List<string> result)
    {
      if (linkedListNode == null)
      {
        return;
      }
      result.Add(linkedListNode.Value);
      Recursive_Calculate(linkedListNode.Next, result);
    }
    public static string[] Recursive_Calculate(LinkedList<string> linkedList)
    {
      var result = new List<string>();
      Recursive_Calculate(linkedList.First, result);
      return result.ToArray();
    }
    public static string[] Iterative_Calculate(LinkedList<string> linkedList)
    {
      if(linkedList==null)
      {
        return Array.Empty<string>();
      }
      var result = new List<string>();
      var current = linkedList.First;
      while(current!=null)
      {
        result.Add(current.Value);
        current = current.Next;
      }
      return result.ToArray();
    }
    [Fact]
    public void Test1()
    {
      var linkedList = new LinkedList<string>();
      linkedList.AddLast(new LinkedListNode<string>("A"));
      linkedList.AddLast(new LinkedListNode<string>("B"));
      linkedList.AddLast(new LinkedListNode<string>("C"));
      linkedList.AddLast(new LinkedListNode<string>("D"));
      Iterative_Calculate(linkedList).Should().ContainInOrder(new string[] { "A", "B", "C", "D" });
      Recursive_Calculate(linkedList).Should().ContainInOrder(new string[] { "A", "B", "C", "D" });

    }
  }
}
