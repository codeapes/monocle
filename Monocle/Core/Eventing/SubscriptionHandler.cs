using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace CodeApes.Monocle.Eventing
{
    public sealed class SubscriptionHandler
    {
        private readonly IDictionary<Type, IList<WeakReference<IEventSubscriber>>> subscribers = new Dictionary<Type, IList<WeakReference<IEventSubscriber>>>();
        private readonly ReaderWriterLock rwLock = new ReaderWriterLock();

        public void AddSubscriber(Type eventType, IEventSubscriber subscriber)
        {
            var reference = CreateReferencesForSubscriber(subscriber);

            rwLock.ExecuteWithWriteLock(() =>
            {
                AddSubscriber(eventType, reference);
            });

            Trace.WriteLine(subscriber + " subscribed to " + eventType.Name, "Eventing");
        }

        private void AddSubscriber(Type eventType, WeakReference<IEventSubscriber> reference)
        {
            if (subscribers.ContainsKey(eventType))
            {
                subscribers[eventType].Add(reference);
                return;
            }

            subscribers.Add(eventType, new List<WeakReference<IEventSubscriber>> {reference});
        }

        private static WeakReference<IEventSubscriber> CreateReferencesForSubscriber(IEventSubscriber subscriber)
        {
            return new WeakReference<IEventSubscriber>(subscriber);
        }

        public void NotifySubscribers<TEvent>(TEvent publishSubscribeEvent)
        {
            var subscribersToNotify = RetrieveSubscribersToNotifyForEvent(publishSubscribeEvent);

            foreach (var subscriberToNotify in subscribersToNotify)
            {
                NotifySubscriber(publishSubscribeEvent, subscriberToNotify);
            }
        }

        private static void NotifySubscriber<TEvent>(TEvent publishSubscribeEvent, WeakReference<IEventSubscriber> subscriberToNotify)
        {
            IEventSubscriber subscriber;

            if (subscriberToNotify.TryGetTarget(out subscriber))
            {
                ((IEventSubscriber<TEvent>) subscriber).OnEvent(publishSubscribeEvent);
            }
        }

        private IEnumerable<WeakReference<IEventSubscriber>> RetrieveSubscribersToNotifyForEvent<TEvent>(TEvent publishSubscribeEvent)
        {
            var subscribersToNotify = Enumerable.Empty<WeakReference<IEventSubscriber>>();

            rwLock.ExecuteWithReadLock(() =>
            {
                subscribersToNotify = subscribers.Where(x => x.Key == publishSubscribeEvent.GetType()).SelectMany(y => y.Value).ToList();
            });

            return subscribersToNotify;
        }
    }
}