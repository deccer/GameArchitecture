using System;

namespace Core
{
    public interface IGameMod
    {
        string Author { get; }

        string Name { get; }

        string Description { get; }

        Version Version { get; }
    }
}
