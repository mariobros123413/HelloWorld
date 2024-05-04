using System;
using System.Drawing;
using OpenTK;

namespace HelloWorld
{
    [Serializable]
    public class Cara
    {
        public Puntos puntos;
        public float[] Posicion { get; set; } // Cambio de Vector3 a float[]
        public Cara(Color color)
        {
            Posicion = new float[3];
            puntos = new Puntos(color);
        }

        public void AgregarPunto(Vector3 punto)
        {
            puntos.AgregarPunto(punto);
        }

        public void Dibujar(Matrix4 posicion)
        {
            puntos.TrazarPuntos(posicion);
        }
    }

}
