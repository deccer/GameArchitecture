using OpenTK.Input;

namespace Core
{
    public interface IInputHandler
    {
        void HandleInput(KeyboardState keyboardState);
    }
}
