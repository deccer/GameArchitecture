using Core.Messages;

namespace Core
{
    public abstract class Game : IGame
    {
        private readonly ILogger _logger;
        
        private readonly IMessageBus _messageBus;

        private readonly IWindow _window;

        private MessageBus.SubscriptionToken _quitMessageToken;

        protected Game(ILogger logger, IMessageBus messageBus, IWindow window)
        {
            _logger = logger;
            _messageBus = messageBus;
            _window = window;
        }

        protected virtual void Cleanup()
        {
            _logger.Write("Cleanup - Game");
            _window.Dispose();
            _messageBus.Unsubscribe(_quitMessageToken);
        }

        protected virtual void Initialize()
        {
            _logger.Write("Initializing - Game");
            _quitMessageToken = _messageBus.Subscribe<QuitGameMessage>(_ => _window.Close());
        }

        public void Run(string[] args)
        {
            Initialize();

            _window.Run();

            Cleanup();
        }
    }
}