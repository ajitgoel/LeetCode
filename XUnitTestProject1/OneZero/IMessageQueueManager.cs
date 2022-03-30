using System;
using System.Diagnostics;
using System.Linq;
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
	//		- System
	//		- System.Diagnostics
	//		- System.Linq
	//		- System.Collections.Generic
	// - Add code comments to explain your code where applicable.
	// - *Single threaded only*, all methods will be called from a single thread, so multi threaded support is *not* required.
	// - Over the lifetime of the class, the total number of subscriptions *and* messages processed will be smaller than the range of a int. So where
	//   int is used for handles/counters you do not need to worry about counter wrapping/overflow.
	//
	// PERFORMANCE NOTES
	// - PostMessage() and GetNextMessage() must be very fast operations.
	//
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	// Message Queue subscriptions are uniquely identified by a SubscriptionHandle, which must be constructed with an int value that uniquely identifies the subscription
	public struct SubscriptionHandle
	{
		public SubscriptionHandle(int in_value) { m_value = in_value; }
		public static bool operator ==(SubscriptionHandle in_a, SubscriptionHandle in_b) { return in_a.m_value == in_b.m_value; }
		public static bool operator !=(SubscriptionHandle in_a, SubscriptionHandle in_b) { return in_a.m_value != in_b.m_value; }
		public override bool Equals(object in_object) { return base.Equals(in_object); }
		public override int GetHashCode() { return m_value.GetHashCode(); }

		readonly int m_value;
	}
	// Interface for a message queue manager
	interface IMessageQueueManager
	{
		// Create a Message Queue with the given name.
		// Returns false on failure, or if the given queue already exists
		bool CreateMessageQueue(string in_queueName);
		// Post a message to a message queue.
		// - Posting an empty message is considered a failure case.
		// - Messages should be stored internally until all subscribers have received them via a GetNextMessage call.
		// Returns false on failure, or if the given queue does not exist.
		bool PostMessage(string in_queueName, string in_message);
		// Create a unique subscription to a given message queue.
		// - Returns a handle to the subscription in out_handle
		// - The subscription must only receive *new* messages created by PostMessage calls that occur *after* the CreateSubscription call
		// Returns false on failure, or if the given queue does not exist
		bool CreateSubscription(string in_queueName, out SubscriptionHandle out_handle);
		// Query for the number of subscribers for the specified queue.
		// - Returns the count of subscribers in out_queueSubscriberCount
		// Returns false if the given queue does not exist
		bool GetSubscriptionCount(string in_queueName, out int out_queueSubscriberCount);
		// Get the next message from the message queue for a given subscription
		// - Returns the message in out_message, and advances the subscription to the following message
		// - If there are no more messages for the subscription, returns true and out_message is set to an empty string
		// Returns false on failure 
		bool GetNextMessage(SubscriptionHandle in_handle, out string out_message);
	};
	public class MessageQueueManager : IMessageQueueManager
	{
		private readonly object queuesSubscribersLock = new object();
		private readonly object queueMessagesLock = new object();
		Dictionary<string, HashSet<Tuple<int, long>>> queuesSubscribers;
		Dictionary<string, HashSet<Tuple<string, long>>> queueMessages;
		public MessageQueueManager()
		{
			queuesSubscribers = new Dictionary<string, HashSet<Tuple<int, long>>>();
			queueMessages = new Dictionary<string, HashSet<Tuple<string, long>>>();
		}
		private bool DoesQueueExist(string in_queueName)
		{
			if (queuesSubscribers.Where(x => x.Key == in_queueName).Count()>0)
			{
				return true;
			}
			return false;
		}		
		public bool CreateMessageQueue(string in_queueName)
		{
			try
			{
				//Returns false if the given queue already exists
				if (DoesQueueExist(in_queueName))
				{
					return false;
				}
				lock (queuesSubscribersLock)
				{
					queuesSubscribers.Add(in_queueName, new HashSet<Tuple<int, long>>());
					return true;
				}
			}
			catch (Exception exception)
			{
				return false;
			}
		}
		public bool PostMessage(string in_queueName, string in_message)
		{
			try
			{
				//Returns false if the given queue does not exist
				if (!DoesQueueExist(in_queueName))
				{
					return false;
				}
				if (string.IsNullOrWhiteSpace(in_message?.Trim()))
				{
					return false;
				}
				//If a message is posted to a queue that has no subscribers, that message is discarded.
				var queue = queuesSubscribers.Where(y => y.Key== in_queueName).FirstOrDefault();
				if (queue.Value.Count()==0)
				{
					//I am assuming that we would like to return false if there are no subscribers
					return false;
				}

				// - Messages should be stored internally until all subscribers have received them via a GetNextMessage call.
				lock (queueMessagesLock)
				{
					var messageCreateDateTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeMilliseconds();
					var tuple = new Tuple<string, long>(in_message, messageCreateDateTime);
					if (queueMessages.ContainsKey(in_queueName) == false)
					{
						var hashset = new HashSet<Tuple<string, long>>
					{
						tuple
					};
						queueMessages.Add(in_queueName, hashset);
					}
					else
					{
						queueMessages[in_queueName].Add(tuple);
					}
					return true;
				}
			}
			catch (Exception exception)
			{
				return false;
			}
		}
		public bool CreateSubscription(string in_queueName, out SubscriptionHandle out_handle)
		{
			try
			{
				// Returns false if the given queue does not exist
				if (!DoesQueueExist(in_queueName))
				{
					out_handle = default;
					return false;
				}
				lock (queuesSubscribersLock)
				{
					var subscriptionHandleId = new Random().Next(int.MinValue, int.MaxValue);
					out_handle = new SubscriptionHandle(subscriptionHandleId);
					var subscriptionCreateDateTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeMilliseconds();
					var tuple = new Tuple<int, long>(out_handle.GetHashCode(), subscriptionCreateDateTime);
					queuesSubscribers[in_queueName].Add(tuple);
					return true;
				}
			}
			catch (Exception exception)
			{
				out_handle = default;
				return false;
			}
		}
		public bool GetSubscriptionCount(string in_queueName, out int out_queueSubscriberCount)
		{
			try
			{
				if (!DoesQueueExist(in_queueName))
				{
					out_queueSubscriberCount = default;
					return false;
				}
				out_queueSubscriberCount = queuesSubscribers.Where(x => x.Key == in_queueName).Select(x => x.Value).Count();
				return true;
			}
			catch (Exception exception)
			{
				out_queueSubscriberCount = default;
				return false;
			}
		}
		// Get the next message from the message queue for a given subscription
		// - Returns the message in out_message, and advances the subscription to the following message
		// - If there are no more messages for the subscription, returns true and out_message is set to an empty string
		// Returns false on failure 
		public bool GetNextMessage(SubscriptionHandle in_handle, out string out_message)
		{
			try
			{
				var subscriptionHandleKey=in_handle.GetHashCode();
				//Get queueName from queuesSubscribers
				var queue = queuesSubscribers.Where(y => y.Value.Select(x=>x.Item1).Contains(subscriptionHandleKey)).FirstOrDefault();
				var queueName = queue.Key;
				var subscriptionHandle = queue.Value.FirstOrDefault();
				if (subscriptionHandle != null)
				{
					var queueSubscriberDateCreated = subscriptionHandle.Item2;
					var queueMessageForSubscriber = queueMessages.Where(x => x.Key == queueName).SelectMany(x => x.Value).Where(x=>x.Item2> queueSubscriberDateCreated).
						OrderBy(x=>x).FirstOrDefault();
					if (queueMessageForSubscriber!=null)
          {
						out_message = queueMessageForSubscriber.Item1;
						lock (queuesSubscribersLock)
						{
							//update queuesSubscribers to the next datetime
							var nextMessageDateTime = queueMessageForSubscriber.Item2;
							var tuple = new Tuple<int, long>(subscriptionHandleKey, nextMessageDateTime);
							queuesSubscribers[queueName].RemoveWhere(x=>x.Item1== subscriptionHandleKey);
							queuesSubscribers[queueName].Add(tuple);
							return true;
						}
					}
					else
          {
						out_message = "";
						return true;
					}					
				}
				else
        {
					out_message = "";
					return false;
				}
			}
			catch (Exception exception)
			{
				out_message = "";
				return false;
			}
}
	}
}
