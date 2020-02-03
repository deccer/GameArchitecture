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
        private readonly MessageBus _messageBus;

        private readonly ILogger _logger;

        public Game(ILogger logger, MessageBus messageBus)
        {
            _logger = logger;
            _messageBus = messageBus;
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
