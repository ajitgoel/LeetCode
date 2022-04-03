using MessageQueue;
using System.Diagnostics;
using Xunit;

public class MessageQueueUnitTest
{
	[Fact]
	public void Test1()
	{
		// Instantiate your message queue manager here
		var messageQueueManager = new MessageQueueManager_Dzmitry();
		var queueName = "queueName1";
		var queueNameThatDoesNotExist = "queueNameThatDoesNotExist";
		var message1 = "Message1";
		var message2 = "Message2";
		var message3 = "Message3";

		#region CreateMessageQueue
		var createMessageQueueReturn1 = messageQueueManager.CreateMessageQueue(queueName);
		Debug.Assert(createMessageQueueReturn1 == true);
		var createMessageQueueReturn2 = messageQueueManager.CreateMessageQueue(queueName);
		Debug.Assert(createMessageQueueReturn2 == false);
		#endregion CreateMessageQueue

		#region PostMessage
		var postMessageReturn1 = messageQueueManager.PostMessage(queueNameThatDoesNotExist, message1);
		Debug.Assert(postMessageReturn1 == false);
		var postMessageReturn2 = messageQueueManager.PostMessage(queueName, "");
		Debug.Assert(postMessageReturn2 == false);
		//no subscribers for the queue so return false.
		var postMessageReturn3 = messageQueueManager.PostMessage(queueName, message1);
		Debug.Assert(postMessageReturn3== false);

		#endregion PostMessage

		#region CreateSubscription
		var createSubscriptionReturn1 = messageQueueManager.CreateSubscription(queueNameThatDoesNotExist, out SubscriptionHandle subscriptionHandle1);
		Debug.Assert(createSubscriptionReturn1 == false);
		Debug.Assert(subscriptionHandle1 == default);
		var createSubscriptionReturn2 = messageQueueManager.CreateSubscription(queueName, out SubscriptionHandle subscriptionHandle2);
		Debug.Assert(createSubscriptionReturn2 == true);
		Debug.Assert(subscriptionHandle2 != default);
		#endregion CreateSubscription

		#region GetSubscriptionCount
		var getSubscriptionCountReturn1 = messageQueueManager.GetSubscriptionCount(queueNameThatDoesNotExist, out int queueSubscriberCount1);
		Debug.Assert(getSubscriptionCountReturn1 == false);
		Debug.Assert(queueSubscriberCount1 == default);
		var getSubscriptionCountReturn2 = messageQueueManager.GetSubscriptionCount(queueName, out int queueSubscriberCount2);
		Debug.Assert(getSubscriptionCountReturn2 == true);
		Debug.Assert(queueSubscriberCount2 == 1);
		#endregion GetSubscriptionCount

		#region GetNextMessage
		//subscriber created after the messages were posted
		var getNextMessageReturn1 = messageQueueManager.GetNextMessage(subscriptionHandle2, out string out_message1);
		Debug.Assert(getNextMessageReturn1 == true);
		Debug.Assert(out_message1 == "");

		//message posted after the subscriber created
		messageQueueManager.PostMessage(queueName, message3);
		var getNextMessageReturn2 = messageQueueManager.GetNextMessage(subscriptionHandle2, out string out_message2);
		Debug.Assert(getNextMessageReturn2 == true);
		Debug.Assert(out_message2 == message3);

		//no more messages in queue to be send to the subscriber
		var getNextMessageReturn3 = messageQueueManager.GetNextMessage(subscriptionHandle2, out string out_message3);
		Debug.Assert(getNextMessageReturn3 == true);
		Debug.Assert(out_message3 == "");
		#endregion GetNextMessage

		#region PostMessage
		var postMessageReturn4 = messageQueueManager.PostMessage(queueName, message2);
		Debug.Assert(postMessageReturn4 == true);

		var queueNameThatDoesNotHaveSubscribers = "QueueName3";
		messageQueueManager.CreateMessageQueue(queueNameThatDoesNotHaveSubscribers);
		var postMessageReturn5 = messageQueueManager.PostMessage(queueNameThatDoesNotHaveSubscribers, message1);
		Debug.Assert(postMessageReturn5 == false);
		#endregion PostMessage
	}
}
