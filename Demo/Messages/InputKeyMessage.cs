using OpenTK.Input;

namespace Demo.Messages
{
    public sealed class InputKeyMessage
    {
        public Key Key { get; }

        public InputKeyMessage(Key key)
        {
            Key = key;
        }
    }
}