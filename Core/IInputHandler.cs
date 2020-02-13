using System;
using OpenTK.Input;

namespace Core
{
    public interface IInputHandler
    {
        event Action<KeyboardState> OnInputDetected;

        void NotifyInput(KeyboardState state);
    }
}
