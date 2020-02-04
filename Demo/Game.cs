using System;
using System.Threading.Tasks;
using Core;
using Demo.Messages;

namespace Demo
{
    public class Game : Core.Game
    {
        private readonly IMessageBus _messageBus;
        private MessageBus.SubscriptionToken _inputKeyMessageToken;

        protected override void Cleanup()
        {
            _messageBus.Unsubscribe(_inputKeyMessageToken);
            base.Cleanup();
        }

        public Game(ILogger logger, IMessageBus messageBus, IWindow window)
            : base(logger, messageBus, window)
        {
            _messageBus = messageBus;
        }

        protected override void Initialize()
        {
            base.Initialize();

            _inputKeyMessageToken = _messageBus.Subscribe<InputKeyMessage>(ReceivedInputKeyMessage);
        }

        private async Task ReceivedInputKeyMessage(InputKeyMessage inputKeyMessage)
        {
            Console.WriteLine($"{inputKeyMessage.Key} Down");

            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}