using System;
using System.Drawing;
using OpenTK;

namespace Core
{
    public interface IRenderer : IDisposable
    {
        void DrawRectangle(Vector2 position, Vector2 size, Color color);

        void Initialize();
    }
}
