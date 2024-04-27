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
        private List<float[]> puntos = new List<float[]>();
        public List<float[]> PuntosSimples
        {
            get { return puntos; }
            set { puntos = value; }
        }
        public Color color;

        public Puntos(Color color)
        {
            this.color = color;
        }

        public void AgregarPunto(Vector3 punto)
        {
            puntos.Add(new float[] { punto.X, punto.Y, punto.Z });
        }

        public void TrazarPuntos(Matrix4 transformacion)
        {
            if (puntos.Count < 3)
            {
                throw new InvalidOperationException("Se necesitan al menos 3 puntos para formar una figura.");
            }

            // Aplicar la transformación acumulada a cada punto
            List<float[]> puntosTransformados = new List<float[]>();
            foreach (var punto in puntos)
            {
                Vector4 puntoTransformado = Vector4.Transform(new Vector4(punto[0], punto[1], punto[2], 1.0f), transformacion);
                puntosTransformados.Add(new float[] { puntoTransformado.X, puntoTransformado.Y, puntoTransformado.Z });
            }

            // Dibujar la figura
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(color);
            foreach (var punto in puntosTransformados)
            {
                GL.Vertex3(punto[0], punto[1], punto[2]);
            }
            GL.End();
        }
    }
}