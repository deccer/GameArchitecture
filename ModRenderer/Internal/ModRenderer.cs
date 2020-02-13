using System.Drawing;
using Core;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ModRendererGameMod.Internal
{
    internal class ModRenderer : IRenderer
    {

        public ModRenderer()
        {
            
        }

        public void DrawRectangle(Vector2 position, Vector2 size, Color color)
        {
            GL.Begin(BeginMode.Quads);
            GL.Color3(color);
            GL.Vertex2(position.X, position.Y);
            GL.Vertex2(position.X + size.X, position.Y);
            GL.Vertex2(position.X + size.X, position.Y + size.Y);
            GL.Vertex2(position.X, position.Y + size.Y);
            GL.End();
        }
    }
}
