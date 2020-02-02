using System;
using Core;

namespace ModRendererGameMod.Internals
{
    internal class ModRendererGameMod : IGameMod
    {
        public string Author => "deccer";

        public string Name => "ModRenderer";

        public string Description => "It renders things";

        public Version Version => new Version(1, 0, 0);

        private readonly IGame _game;

        public ModRendererGameMod(IGame game)
        {
            _game = game;
            _game.RegisterGameMod(this);
        }
    }
}