using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Messages;

namespace Core
{
    public abstract class Game : IGame
    {
        private readonly IList<IGameMod> _gameMods;

        private readonly MessageBus _messageBus;

        private readonly ILogger _logger;

        private bool _canClose;

        private MessageBus.SubscriptionToken _quitMessageToken;

        protected Game(ILogger logger, MessageBus messageBus)
        {
            _logger = logger;
            _messageBus = messageBus;

            _gameMods = new List<IGameMod>();
        }

        protected virtual void Cleanup()
        {
            _messageBus.Unsubscribe(_quitMessageToken);
        }

        protected virtual void Initialize()
        {
            _quitMessageToken = _messageBus.Subscribe<QuitGameMessage>(async _ => _canClose = await Task.FromResult(true).ConfigureAwait(false));
        }

        public void RegisterGameMod(IGameMod gameMod)
        {
            _gameMods.Add(gameMod);
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