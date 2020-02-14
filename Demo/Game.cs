using System;
using Core;
using OpenTK.Input;

namespace Demo
{
    public class Game : Core.Game
    {
        private readonly IMessageBus _messageBus;

        protected override void Cleanup()
        {
            base.Cleanup();
        }

        public Game(ILogger logger, IMessageBus messageBus, IWindow window, IInputHandler inputHandler)
            : base(logger, messageBus, window)
        {
            _messageBus = messageBus;
            inputHandler.OnInputDetected += InputDetected;
        }

        private void InputDetected(KeyboardState state)
        {
            if (state.IsKeyDown(Key.W))
            {
                Console.WriteLine("You just pressed W.");
            }
            if (state.IsKeyDown(Key.S))
            {
            }
            if (state.IsKeyDown(Key.A))
            {
            }
            if (state.IsKeyDown(Key.D))
            {
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}