using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Structy
{
  public class ReverseLinkedList
  {
    //public static void Recursive_Calculate(LinkedListNode<string> linkedListNode, List<string> result)
    //{
    //  if (linkedListNode == null)
    //  {
    //    return;
    //  }
    //  result.Add(linkedListNode.Value);
    //  Recursive_Calculate(linkedListNode.Next, result);
    //}
    //public static string[] Recursive_Calculate(LinkedList<string> linkedList)
    //{
    //  var result = new List<string>();
    //  Recursive_Calculate(linkedList.First, result);
    //  return result.ToArray();
    //}
    public static LinkedList<string> Iterative_Calculate(LinkedList<string> linkedList)
    {
      //A=>B=>C=>D :: D=>C=>B=>A
      //set next node to
      if (linkedList==null)
      {
        return null;
      }
      LinkedListNode<string> previous = null;
      var current = linkedList.First;
      while(previous == null)
      {
        //var next=current.Next;
        //current.Next = previous;
        //previous = current.Next;
        //linkedList.
      }
      return linkedList;
    }
    [Fact]
    public void Test1()
    {
      var linkedList = new LinkedList<string>();
      linkedList.AddLast(new LinkedListNode<string>("A"));
      linkedList.AddLast(new LinkedListNode<string>("B"));
      linkedList.AddLast(new LinkedListNode<string>("C"));
      linkedList.AddLast(new LinkedListNode<string>("D"));
      var result=Iterative_Calculate(linkedList);
      //Should().ContainInOrder(new string[] { "D", "C", "B", "A" });
      //Recursive_Calculate(linkedList).Should().ContainInOrder(new string[] { "A", "B", "C", "D" });

    }
  }
}
