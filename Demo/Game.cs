using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core;
using DryIoc;

namespace Demo
{
    public class QuitGameMessage
    {
    }

    internal interface IGame
    {
        void Run(string[] args);
    }

    internal class Game : IGame
    {
        private readonly MessageBus _messageBus;

        private readonly ILogger _logger;

        private bool _canClose;
        private MessageBus.SubscriptionToken _quitMessageToken;

        public Game(ILogger logger, MessageBus messageBus)
        {
            _logger = logger;
            _messageBus = messageBus;
            _quitMessageToken = _messageBus.Subscribe<QuitGameMessage>(async message => _canClose = await Task.FromResult(true));
        }

        private void Cleanup()
        {
            _messageBus.Unsubscribe(_quitMessageToken);
        }

        private void Initialize()
        {
        }

        public void Run(string[] args)
        {
            Initialize();

            while (!_canClose)
            {

            }

            Cleanup();
        }
    }
}
