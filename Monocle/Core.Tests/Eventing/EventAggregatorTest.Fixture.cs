// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace CodeApes.Monocle.Eventing
{
    public sealed partial class EventAggregatorTest
    {
        private class Fixture
        {
            private readonly MockRepository mockRepository = new MockRepository(MockBehavior.Loose);
            private readonly Mock<IEventSubscriber<InitEvent>> initSubscriber;
            private int initCounter;
            private int numerOfExpectedInitEvents;

            public Fixture()
            {
                initSubscriber = mockRepository.Create<IEventSubscriber<InitEvent>>();
            }

            public bool Initialized
            {
                get { return initCounter == numerOfExpectedInitEvents; }
            }

            public IEventAggregator CreateTestObject(int initEventsToExpect)
            {
                numerOfExpectedInitEvents = initEventsToExpect;
                var aggregator = new EventAggregator();

                initSubscriber
                    .Setup(x => x.OnEvent(It.IsAny<InitEvent>()))
                    .Callback(IncreaseInitCount);

                initSubscriber
                    .SetupGet(x => x.EventTypes)
                    .Returns(new[] { typeof(InitEvent) });

                aggregator.SubscribeToEvent(initSubscriber.Object);

                return aggregator;
            }

            public static TestSubscriber CreateSubscriber(string id, IEventAggregator aggregator)
            {
                return new TestSubscriber(id, aggregator);
            }

            public void VerifySubscriberWasCalled(TestSubscriber subscriber)
            {
                Assert.That(subscriber.Event1Called(1), Is.True);
                Assert.That(subscriber.Event2Called(0), Is.True);
            }

            public Task StartSubscriber(string id, IEventAggregator aggregator)
            {
                var subscriberThread = new Task(agr =>
                {
                    var subscriber = new TestSubscriber(id, aggregator);
                    ((IEventAggregator)agr).SubscribeToEvent(subscriber);
                    ((IEventAggregator)agr).Publish(new InitEvent());

                    while (subscriber.Event1Called(0))
                    {
                    }

                }, aggregator);

                subscriberThread.Start();
                return subscriberThread;
            }

            public Task StartPublisher(string id, IEventAggregator aggregator, bool event1)
            {
                var publisherThread = new Task(agr =>
                {
                    var subscriber = new TestSubscriber(id, aggregator);
                    subscriber.Subscribe();
                    subscriber.WaitForEvent(event1);

                }, aggregator);

                publisherThread.Start();
                return publisherThread;
            }

            private void IncreaseInitCount()
            {
                initCounter++;
            }
        }
    }
}
