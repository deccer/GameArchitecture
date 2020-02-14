using System;
using Core;

namespace ModKeybinding.Internal
{
    internal class ModKeybinding : IKeybinding
    {
        private readonly IInputHandler _inputHandlers;

        public ModKeybinding(IInputHandler inputHandlers)
        {
            _inputHandlers = inputHandlers;
            
        }

    }
}