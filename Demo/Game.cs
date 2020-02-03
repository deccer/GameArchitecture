using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Core;
using DryIoc;

namespace Demo
{
    internal class Game : IGame
    {
        protected Game(ILogger logger)
            : base(logger)
        {
        }

        private void Cleanup()
        {
        }

        private void Initialize()
        {
        }

        public void Run(string[] args)
        {
            Initialize();

            while (true)
            {

            }

            Cleanup();
        }
    }
}
