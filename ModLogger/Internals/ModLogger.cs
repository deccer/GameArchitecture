using System;
using Core;

namespace ModLoggerGameMod.Internals
{
    internal class ModLogger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
