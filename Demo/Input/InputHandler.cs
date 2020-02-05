using Core;
using Demo.Messages;
using OpenTK.Input;

namespace Demo.Input
{
    public class InputHandler : IInputHandler
    {
        private readonly IMessageBus _messageBus;

        public InputHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void HandleInput(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Key.W))
            {
                _messageBus.PublishWait(new InputKeyMessage(Key.W));
            }

            if (keyboardState.IsKeyDown(Key.S))
            {
                _messageBus.PublishWait(new InputKeyMessage(Key.S));
            }

            if (keyboardState.IsKeyDown(Key.A))
            {
                _messageBus.PublishWait(new InputKeyMessage(Key.A));
            }

            if (keyboardState.IsKeyDown(Key.D))
            {
                _messageBus.PublishWait(new InputKeyMessage(Key.D));
            }
        }
    }
}