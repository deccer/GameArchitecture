using System;
using Core;

namespace ModLoggerGameMod.Internals
{
    internal class ModLoggerGameMod : IGameMod
    {
        public string Author => "deccer";

        public string Name => "ModLogger";

        public string Description => "It logs stuff";

        public Version Version => new Version(1, 0, 0);

        private readonly IGame _game;

        public ModLoggerGameMod(IGame game)
        {
            _game = game;
            _game.RegisterGameMod(this);
        }
    }
}
