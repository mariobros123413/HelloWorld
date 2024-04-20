using System;
using System.Drawing;
using OpenTK;

namespace HelloWorld
{
    [Serializable]
    public class Cara
    {
        private Puntos puntos;
        public Vector3 Posicion { get; set; }

        public Cara(Vector3 posicion, Color color)
        {
            Posicion = posicion;
            puntos = new Puntos(color);
        }

        public void AgregarPunto(Vector3 punto)
        {
            puntos.AgregarPunto(punto);
        }

        public void TrazarPuntos(Vector3 posicion)
        {
            puntos.TrazarPuntos(posicion);
        }
    }

}
