using System;
using System.Drawing;
using OpenTK;

namespace Core
{
    public interface IRenderer
    {
        void DrawRectangle(Vector2 position, Vector2 size, Color color);
    }
}
