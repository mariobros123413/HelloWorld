using System.Drawing;
using OpenTK;

namespace HelloWorld
{
    public class Cara
    {
        private Puntos puntos = new Puntos();

        public void AgregarPunto(Vector3 punto, Color color)
        {
            puntos.AgregarPunto(punto, color);
        }

        public void TrazarPuntos()
        {
            puntos.TrazarPuntos();
        }
    }
}
