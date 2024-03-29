﻿namespace XUnitTestProject1
{
  public class Node<T>
  {
    public Node(T value)
    {
      Value = value;
    }
    public T Value { get; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }
  }
}
