using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Core
{
    public interface IMessageBus
    {
        MessageBus.SubscriptionToken Subscribe<TMessage>(Func<TMessage, Task> subscriber);

        MessageBus.SubscriptionToken Subscribe<TMessage>(Action<TMessage> subscriber);

        void Unsubscribe(MessageBus.SubscriptionToken subscriptionToken);

        void PublishWait<TMessage>(TMessage message);

        Task PublishWaitAllAsync<TMessage>(TMessage message);

        Task PublishWaitAsync<TMessage>(TMessage message);
    }
}
