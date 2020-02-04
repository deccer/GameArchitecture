using System;
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

        public async void HandleInput(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Key.W))
            {
                await _messageBus.PublishWaitAsync(new InputKeyMessage(Key.W)).ConfigureAwait(false);
            }
            if (keyboardState.IsKeyDown(Key.S))
            {
                await _messageBus.PublishWaitAsync(new InputKeyMessage(Key.S)).ConfigureAwait(false);
            }
            if (keyboardState.IsKeyDown(Key.A))
            {
                await _messageBus.PublishWaitAsync(new InputKeyMessage(Key.A)).ConfigureAwait(false);
            }
            if (keyboardState.IsKeyDown(Key.D))
            {
                await _messageBus.PublishWaitAsync(new InputKeyMessage(Key.D)).ConfigureAwait(false);
            }
        }
    }
}