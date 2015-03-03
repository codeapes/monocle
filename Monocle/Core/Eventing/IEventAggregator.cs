// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

namespace CodeApes.Monocle.Eventing
{
    public interface IEventAggregator
    {
        void Publish<TEvent>(TEvent publishSubscribeEvent);

        void SubscribeToEvent(IEventSubscriber subscriber);
    }
}
