using System;

namespace Core
{
    public interface IWindow : IDisposable
    {
        void Close();

        void Run();
    }
}