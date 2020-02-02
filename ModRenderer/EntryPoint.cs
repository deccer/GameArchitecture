using Core;
using DryIoc;

namespace ModRendererGameMod
{
    public static class EntryPoint
    {
        public static void Register(IRegistrator registrator)
        {
            registrator.Register<IRenderer, Internals.ModRenderer>(Reuse.Singleton);
            registrator.Register<IGameMod, Internals.ModRendererGameMod>(Reuse.Singleton);
        }
    }
}