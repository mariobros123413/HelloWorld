using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace HelloWorld
{
    internal class Cara
    {
        public Puntos Puntos { get; }
        public Color Color { get; }

        public Cara(Puntos puntos, Color color)
        {
            Puntos = puntos ?? throw new ArgumentNullException(nameof(puntos));
            Color = color;
        }

        public void Dibujar()
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(Color);
            foreach (var punto in Puntos.Vertices)
            {
                GL.Vertex3(punto);
            }
            GL.End();
        }
    }
}
