using System;
using Core;
using OpenTK.Input;

namespace ModWindow.Internal
{
    public class WindowInputHandler : IInputHandler
    {
        public event Action<KeyboardState> OnInputDetected;

        public void NotifyInput(KeyboardState state)
        {
            OnInputDetected?.Invoke(state);
        }

    }
}