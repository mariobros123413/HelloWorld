using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace HelloWorld
{
    public class Puntos
    {
        private Dictionary<Vector3, Color> puntos = new Dictionary<Vector3, Color>();

        public void AgregarPunto(Vector3 punto, Color color)
        {
            if (!puntos.ContainsKey(punto))
            {
                puntos.Add(punto, color);
            }
        }

        public void TrazarPuntos()
        {
            if (puntos.Count < 3)
            {
                throw new InvalidOperationException("Se necesitan al menos 3 puntos para formar una figura.");
            }

            GL.Begin(PrimitiveType.Polygon);
            foreach (var puntoColorPair in puntos)
            {
                GL.Color3(puntoColorPair.Value);
                GL.Vertex3(puntoColorPair.Key);
            }
            GL.End();
        }




    }
}
