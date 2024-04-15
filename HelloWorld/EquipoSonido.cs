using OpenTK;
using System;
using System.Drawing;

namespace HelloWorld
{
    public class EquipoSonido : Objeto
    {
        public EquipoSonido(Vector3 posicion) : base(posicion)
        {
            CrearEquipoSonido(-1.6f);
            CrearEquipoSonido(0f);

        }

        private void CrearEquipoSonido(float x)
        {

            //Frontales de la caja
            CrearCaraFrontal(x, -0.7f, $"CajaTrasera{x}");
            CrearCaraFrontal(x, -0.5f, $"CajaFrontal{x}");

            // Lados de la caja
            CrearCaraLateral(x + 0.6f, $"LadoIzquierdo{x}");
            CrearCaraLateral(x + 1.0f, $"LadoDerecho{x}");

            // Bocina
            CrearBocina(x);
        }

        private void CrearCaraFrontal(float x, float z, string nombre)
        {
            var cara = new Cara();
            cara.AgregarPunto(new Vector3(x + 0.6f, -0.9f, z), Color.Black);
            cara.AgregarPunto(new Vector3(x + 1.0f, -0.9f, z), Color.Black);
            cara.AgregarPunto(new Vector3(x + 1.0f, 0.1f, z), Color.Black);
            cara.AgregarPunto(new Vector3(x + 0.6f, 0.1f, z), Color.Black);
            AgregarCara(nombre, cara);
        }

        private void CrearCaraLateral(float x, string nombre)
        {
            var caraLateral = new Cara();
            caraLateral.AgregarPunto(new Vector3(x, -0.9f, -0.7f), Color.Black);
            caraLateral.AgregarPunto(new Vector3(x, -0.9f, -0.5f), Color.Black);
            caraLateral.AgregarPunto(new Vector3(x, 0.1f, -0.5f), Color.Black);
            caraLateral.AgregarPunto(new Vector3(x, 0.1f, -0.7f), Color.Black);
            AgregarCara(nombre, caraLateral);
        }


        private void CrearBocina(float x2)
        {
            var bocina = new Cara();
            float radio = 0.16f;
            Vector3 centro = new Vector3(x2 + 0.8f, -0.3f, -0.49f);
            int numPuntos = 20;
            for (int i = 0; i < numPuntos; i++)
            {
                float angulo = (float)(i * 2 * Math.PI / numPuntos);
                float x = centro.X + radio * (float)Math.Cos(angulo);
                float y = centro.Y + radio * (float)Math.Sin(angulo);
                bocina.AgregarPunto(new Vector3(x, y, centro.Z), Color.DarkGray);
            }
            AgregarCara($"Bocina{x2}", bocina);
        }
    }
}