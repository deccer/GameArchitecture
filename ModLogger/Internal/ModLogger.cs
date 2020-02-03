using System;
using Core;

namespace ModLoggerGameMod.Internal
{
    internal class ModLogger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
