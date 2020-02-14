using Core;
using DryIoc;

namespace ModKeybinding
{
    public static class EntryPoint
    {
        public static void Register(IRegistrator registrator)
        {
            registrator.Register<IKeybinding, Internal.ModKeybinding>(Reuse.Singleton);
        }
    }
}
