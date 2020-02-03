using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Messages;

namespace Core
{
    public abstract class Game : IGame
    {
        private readonly IList<IGameMod> _gameMods;

        private readonly ILogger _logger;

        private readonly MessageBus _messageBus;

        private readonly IWindow _window;

        private MessageBus.SubscriptionToken _quitMessageToken;

        protected Game(ILogger logger, MessageBus messageBus, IWindow window)
        {
            _logger = logger;
            _messageBus = messageBus;
            _window = window;

            _gameMods = new List<IGameMod>();
        }

        protected virtual void Cleanup()
        {
            _logger.Write("Game: Cleanup");
            _messageBus.Unsubscribe(_quitMessageToken);
        }

        protected virtual void Initialize()
        {
            _logger.Write("Game: Initializing");
            _quitMessageToken = _messageBus.Subscribe<QuitGameMessage>(_ => _window.Close());
        }

        public void RegisterGameMod(IGameMod gameMod)
        {
            _logger.Write($"Mod: Registering {gameMod.Name} {gameMod.Version}");
            _gameMods.Add(gameMod);
        }

        public void Run(string[] args)
        {
            Initialize();

            _window.Run();

            Cleanup();
        }
    }
}