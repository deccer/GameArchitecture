using Core;

namespace Demo
{
    public class Game : Core.Game
    {
        public Game(ILogger logger, MessageBus messageBus, IWindow window)
            : base(logger, messageBus, window)
        {
        }
    }
}