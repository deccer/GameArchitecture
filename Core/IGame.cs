namespace Core
{
    public interface IGame
    {
        void RegisterGameMod(IGameMod gameMod);

        void Run(string[] args);
    }
}
