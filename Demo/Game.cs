using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Core;
using DryIoc;

namespace Demo
{
    internal class Game : Core.Game
    {
        protected Game(ILogger logger)
            : base(logger)
        {
        }

        protected override void Cleanup()
        {
        }

        protected override void Initialize()
        {
        }
    }
}
