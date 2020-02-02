using System;
using System.Collections.Generic;

namespace Core
{
    public class Game : IGame
    {
        private readonly IList<IGameMod> _gameMods;

        public Game()
        {
            _gameMods = new List<IGameMod>();
        }

        public void RegisterGameMod(IGameMod gameMod)
        {
            _gameMods.Add(gameMod);
        }
    }
}
