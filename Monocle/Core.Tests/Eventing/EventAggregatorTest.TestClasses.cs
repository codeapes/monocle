// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System;
using System.Collections.Generic;

namespace CodeApes.Monocle.Eventing
{
    public sealed partial class EventAggregatorTest
    {
        private class TestSubscriber : IEventSubscriber<TestEvent>, IEventSubscriber<TestEvent2>
        {
            private int event1Calls;
            private int event2Calls;
            private readonly IEventAggregator aggregator;
            private readonly string id;

            public TestSubscriber(string id, IEventAggregator aggregator)
            {
                this.id = id;
                this.aggregator = aggregator;
            }

            private void PublishEvent(bool sendEvent1)
            {
                if (sendEvent1)
                {
                    aggregator.Publish(new TestEvent());
                }
                else
                {
                    aggregator.Publish(new TestEvent2());
                }
            }

            public override string ToString()
            {
                return id;
            }

            public void OnEvent(TestEvent publishSubscribeEvent)
            {
                event1Calls++;
            }

            public bool Event1Called(int times)
            {
                return times.Equals(event1Calls);
            }

            public bool Event2Called(int times)
            {
                return times.Equals(event2Calls);
            }

            public void OnEvent(TestEvent2 publishSubscribeEvent)
            {
                event2Calls++;
            }

            public IEnumerable<Type> EventTypes
            {
                get
                {
                    yield return typeof(TestEvent);
                    yield return typeof(TestEvent2);
                }
            }

            public void WaitForEvent(bool waitForEvent1)
            {
                if (waitForEvent1)
                {
                    WaitForEvent1();
                }
                else
                {
                    WaitForEvent2();
                }
            }

            private void WaitForEvent2()
            {
                while (event2Calls == 0)
                {
                }

                PublishEvent(true);
            }

            private void WaitForEvent1()
            {
                while (event1Calls == 0)
                {
                }

                PublishEvent(false);
            }

            public void Subscribe()
            {
                aggregator.SubscribeToEvent(this);
                aggregator.Publish(new InitEvent());
            }
        }

        private class TestEvent : PublishSubscribeEvent
        {
        }

        private class TestEvent2 : PublishSubscribeEvent
        {
        }

        public class InitEvent : PublishSubscribeEvent
        { }
    }
}
