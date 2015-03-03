// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System.Threading;
using NUnit.Framework;

namespace CodeApes.Monocle.Eventing
{
    [TestFixture]
    public sealed partial class EventAggregatorTest
    {
        private Fixture fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
        }

        [Test]
        public void Publish_EventGiven_ShouldNotfiySubscriber()
        {
            var testObject = fixture.CreateTestObject(0);
            var subscriber = Fixture.CreateSubscriber("subscriber1", testObject);
            testObject.SubscribeToEvent(subscriber);

            testObject.Publish(new TestEvent());

            fixture.VerifySubscriberWasCalled(subscriber);
        }

        [Test]
        public void Publish_SubscriberInDifferentThreadEventPublishedFromMainThread_ShouldNotifySubscriber()
        {
            var testObject = fixture.CreateTestObject(1);

            var subscriber = fixture.StartSubscriber("subscriber1", testObject);

            while (!fixture.Initialized)
            {
                Thread.Sleep(10);
            }

            testObject.Publish(new TestEvent());
            subscriber.Wait();
        }

        [Test]
        public void Publish_SubscribersInDifferentThreadsEventsPublishedFromAllThreads_ShouldNotifySubscribers()
        {
            var testObject = fixture.CreateTestObject(2);

            var subscriber = fixture.StartPublisher("subscriber1", testObject, true);
            var subscriber2 = fixture.StartPublisher("subscriber2", testObject, false);

            while (!fixture.Initialized)
            {
                Thread.Sleep(10);                
            }

            testObject.Publish(new TestEvent());

            subscriber.Wait();
            subscriber2.Wait();
        }
    }
}
