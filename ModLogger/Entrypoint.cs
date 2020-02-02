using System;
using Core;
using DryIoc;

namespace ModLoggerGameMod
{
    public static class EntryPoint
    {
        public static void Register(IRegistrator registrator)
        {
            registrator.Register<IGameMod, Internals.ModLoggerGameMod>(Reuse.Singleton);
            registrator.Register<ILogger, Internals.ModLogger>(Reuse.Singleton);
        }
    }
}
