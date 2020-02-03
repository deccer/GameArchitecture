using System.Collections.Generic;

namespace Core
{
    public abstract class Game : IGame
    {
        private readonly IList<IGameMod> _gameMods;

        protected ILogger Logger { get; }

        protected Game(ILogger logger)
        {
            Logger = logger;

            _gameMods = new List<IGameMod>();
        }

        protected virtual void Cleanup()
        {
        }

        protected virtual void Initialize()
        {
        }

        public void RegisterGameMod(IGameMod gameMod)
        {
            _gameMods.Add(gameMod);
        }

        public void Run(string[] args)
        {
            Initialize();
            foreach (var arg in args)
            {
                Logger.Write(arg);
            }
            Cleanup();
        }
    }
}