using OpenTK;
using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
namespace HelloWorld
{
    public class Objeto
    {
        public Dictionary<string, Cara> Caras { get; } = new Dictionary<string, Cara>();
        public Vector3 Posicion { get; set; }
        public Objeto(Vector3 posicion)
        {
            Posicion = posicion;
        }

        public void AgregarCara(string nombre, Cara cara)
        {
            if (cara == null)
                throw new ArgumentNullException(nameof(cara));
            Caras.Add(nombre, cara);
        }

        public void Dibujar()
        {
            GL.PushMatrix();
            GL.Translate(Posicion);
            foreach (var cara in Caras.Values)
            {
                cara.TrazarPuntos();

            }
            GL.PopMatrix();
        }
    }
}
