using System.Collections.Generic;

namespace Core
{
    public class Game : IGame
    {
        private readonly IList<IGameMod> _gameMods;

        public ILogger Logger { get; }

        public Game(ILogger logger)
        {
            Logger = logger;

            _gameMods = new List<IGameMod>();
        }

        public void RegisterGameMod(IGameMod gameMod)
        {
            _gameMods.Add(gameMod);
        }

        public void Run(string[] args)
        {
            foreach (var arg in args)
            {
                Logger.Write(arg);
            }
        }
    }
}