using Core;
using DryIoc;

namespace ModRendererGameMod
{
    public static class EntryPoint
    {
        public static void Register(IRegistrator registrator)
        {
            registrator.Register<IRenderer, Internal.ModRenderer>(Reuse.Singleton);
        }
    }
}