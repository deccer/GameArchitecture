using Core;

namespace Demo
{
    internal class Game : Core.Game
    {
        protected Game(ILogger logger, MessageBus messageBus)
            : base(logger, messageBus)
        {
        }
    }
}