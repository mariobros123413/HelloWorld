using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Linq;

namespace HelloWorld
{
    public class Puntos
    {
        private List<Vector3> puntos = new List<Vector3>();
        public List<float[]> PuntosSimples
        {
            get
            {
                return puntos.Select(v => new float[] { v.X, v.Y, v.Z }).ToList();
            }
            set
            {
                puntos = value.Select(a => new Vector3(a[0], a[1], a[2])).ToList();
            }
        }
        public Color color;
        //public Dictionary<string, Vector3> puntos { get; } = new Dictionary<string, Vector3>();

        public Puntos(Color color)
        {
            this.color = color;
        }

        public void AgregarPunto(Vector3 punto)
        {
            puntos.Add(punto);
        }

        public void TrazarPuntos(Vector3 posicion)
        {
            if (puntos.Count < 3)
            {
                throw new InvalidOperationException("Se necesitan al menos 3 puntos para formar una figura.");
            }
            GL.PushMatrix();
            GL.Translate(posicion);
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(color);
            foreach (var punto in puntos)
            {
                GL.Vertex3(punto);
            }
            GL.End();
            GL.PopMatrix(); // Restaurar la matriz de modelo-vista

        }
    }

}
