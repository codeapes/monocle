// Copyright (c) 2015 All Right Reserved, http://CodeApes.de/

using System;
using System.Collections.Generic;

namespace CodeApes.Monocle.Eventing
{
    public interface IEventSubscriber
    {
        IEnumerable<Type> EventTypes { get; }
    }

    public interface IEventSubscriber<in TEvent> : IEventSubscriber
    {
        void OnEvent(TEvent publishSubscribeEvent);
    }
}
