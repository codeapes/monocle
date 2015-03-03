// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System.Diagnostics;

namespace CodeApes.Monocle.Eventing
{
    public sealed class EventAggregator : IEventAggregator
    {
        private readonly SubscriptionHandler subscribers = new SubscriptionHandler();

        public void Publish<TEvent>(TEvent publishSubscribeEvent)
        {
            Trace.WriteLine("Aggregator received " + publishSubscribeEvent);

            subscribers.NotifySubscribers(publishSubscribeEvent);
        }

        public void SubscribeToEvent(IEventSubscriber subscriber)
        {
            foreach (var eventType in subscriber.EventTypes)
            {
                subscribers.AddSubscriber(eventType, subscriber);
            }
        }
    }
}
