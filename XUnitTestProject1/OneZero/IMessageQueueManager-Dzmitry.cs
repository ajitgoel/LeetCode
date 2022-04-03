using System;
using System.Collections.Generic;
namespace MessageQueue
{
  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  // IMessageQueueManager
  //
  // WHAT WE ARE LOOKING FOR:
  // - We will be evaluating your solution in 2 main areas:
  //     1. Code clarity and design - Your code should be easy to read and understand.
  //     2. Algorithmic efficiency - Optimal solutions will eliminate linear iteration and redundant map lookups.
  // - You have 6 hours to complete this test.
  //
  // TASK NOTES:
  // - Your task is to implement a MessageQueue management system that conforms to the exact interface defined below
  // - A message queue is a FIFO container for string messages. Messages are posted to the queue and then read in FIFO order by an arbitrary number of subscribers.
  // - Each subscriber can independently subscribe/get a message from the queue, hence each subscriber effectively maintains its own position in the
  //   primary message queue. 
  // - The state for a single subscriber is referred to as a "subscription" and represented by a SubscriptionHandle in the IMessageQueueManager class.
  //
  // AN IMPORTANT FEATURE OF MESSAGE QUEUES is that they only store the subset of messages that are yet to be read by subscribers. Thus:
  // - Subscribers only see messages that were added to the queue after they have subscribed.
  // - If a message is posted to a queue that has no subscribers, that message is discarded.
  // - Once all subscribers have read a particular message, it is discarded.
  //
  // IMPLEMENTATION NOTES
  // - YOU MAY ONLY USE THE FOLLOWING .NET NAMESPACES
  //      - System
  //      - System.Diagnostics
  //      - System.Linq
  //      - System.Collections.Generic
  // - Add code comments to explain your code where applicable.
  // - *Single threaded only*, all methods will be called from a single thread, so multi threaded support is *not* required.
  // - Over the lifetime of the class, the total number of subscriptions *and* messages processed will be smaller than the range of a int. So where
  //   int is used for handles/counters you do not need to worry about counter wrapping/overflow.
  //
  // PERFORMANCE NOTES
  // - PostMessage() and GetNextMessage() must be very fast operations.
  //
  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  public class Message
  {
    public Message(string value)
    {
      Value = value;
    }
    public string Value { get; set; }
    public Message NextMessage { get; set; }
  }
  public class QueueState
  {
    public int SubscribersCount { get; set; }
    public Message LastMessage { get; set; }
    public HashSet<SubscriberState> Subscribers = new();
  }
  public class SubscriberState
  {
    public string QueueName { get; set; }
    public Message LastMessage { get; set; }
  }
  public class MessageQueueManager_Dzmitry : IMessageQueueManager
  {
    private static int _subscriberId = int.MinValue;
    private readonly Dictionary<string, QueueState> _queues = new();
    private readonly Dictionary<SubscriptionHandle, SubscriberState> _subscribers = new();
    public bool CreateMessageQueue(string in_queueName)
    {
      try
      {
        return _queues.TryAdd(in_queueName, new QueueState());
      }
      catch (Exception)
      {
        return false;
      }
    }
    public bool PostMessage(string in_queueName, string in_message)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(in_message?.Trim()))
        {
          return false;
        }
        //Returns false if the given queue does not exist
        if (!_queues.TryGetValue(in_queueName, out var queuestate))
        {
          return false;
        }
        if (queuestate.SubscribersCount == 0)
        {
          return false;
        }
        var lastMessage = queuestate.LastMessage;
        var newMessage = queuestate.LastMessage = new Message(in_message);
        if (lastMessage != null)
          lastMessage.NextMessage = newMessage;
        foreach (var subscriber in queuestate.Subscribers)
        {
          subscriber.LastMessage = newMessage;
        }
        queuestate.Subscribers.Clear();
        return true;
      }
      catch
      {
        return false;
      }
    }
    public bool CreateSubscription(string in_queueName, out SubscriptionHandle out_handle)
    {
      out_handle = default;
      try
      {
        // Returns false if the given queue does not exist
        if (!_queues.TryGetValue(in_queueName, out var queuestate))
        {
          return false;
        }
        _subscriberId++;
        out_handle = new SubscriptionHandle(_subscriberId);
        var subscriberState = new SubscriberState
        {
          QueueName = in_queueName
        };
        _subscribers[out_handle] = subscriberState;
        queuestate.Subscribers.Add(subscriberState);
        queuestate.SubscribersCount++;
        return true;
      }
      catch
      {
        out_handle = default;
        return false;
      }
    }
    public bool GetSubscriptionCount(string in_queueName, out int out_queueSubscriberCount)
    {
      out_queueSubscriberCount = default;
      try
      {
        if (!_queues.TryGetValue(in_queueName, out var queuestate))
        {
          return false;
        }
        out_queueSubscriberCount = queuestate.SubscribersCount;
        return true;
      }
      catch
      {
        return false;
      }
    }
    // Get the next message from the message queue for a given subscription
    // - Returns the message in out_message, and advances the subscription to the following message
    // - If there are no more messages for the subscription, returns true and out_message is set to an empty string
    // Returns false on failure 
    public bool GetNextMessage(SubscriptionHandle in_handle, out string out_message)
    {
      out_message = "";
      try
      {
        if (!_subscribers.TryGetValue(in_handle, out var subscriberState))
        {
          return false;
        }
        if (subscriberState.LastMessage != null)
        {
          out_message = subscriberState.LastMessage.Value;
          subscriberState.LastMessage = subscriberState.LastMessage.NextMessage;
        }
        if (subscriberState.LastMessage == null)
        {
          var queuestate = _queues[subscriberState.QueueName];
          queuestate.Subscribers.Add(subscriberState);
        }
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}