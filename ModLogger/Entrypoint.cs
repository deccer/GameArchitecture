using Core;
using DryIoc;

namespace ModLoggerGameMod
{
    public static class EntryPoint
    {
        public static void Register(IRegistrator registrator)
        {
            registrator.Register<ILogger, Internal.ModLogger>(Reuse.Singleton);
        }
    }
}
