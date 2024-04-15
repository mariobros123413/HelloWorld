using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace HelloWorld
{
    public class Florero : Objeto
    {
        private Cara baseFlorero;
        private Cara tallo;
        private List<Cara> petalos;

        public Florero(Vector3 posicion) : base(posicion)
        {
            CrearFlorero();
        }

        private void CrearFlorero()
        {
            // Creamos las caras para la base del florero
            baseFlorero = new Cara();
            baseFlorero.AgregarPunto(new Vector3(-0.3f, 0.9f, -0.9f), Color.Green);
            baseFlorero.AgregarPunto(new Vector3(0.3f, 0.9f, -0.9f), Color.Green);
            baseFlorero.AgregarPunto(new Vector3(0.3f, 0.6f, -0.9f), Color.Green);
            baseFlorero.AgregarPunto(new Vector3(-0.3f, 0.6f, -0.9f), Color.Green);

            // Creamos las caras para el tallo del florero
            tallo = new Cara();
            tallo.AgregarPunto(new Vector3(-0.05f,0.9f, -0.9f), Color.Brown);
            tallo.AgregarPunto(new Vector3(0.05f, 0.9f, -0.9f), Color.Brown);
            tallo.AgregarPunto(new Vector3(0.05f, 1.5f, -0.9f), Color.Brown);
            tallo.AgregarPunto(new Vector3(-0.05f, 1.5f, -0.9f), Color.Brown);

            // Creamos los pétalos de la flor
            petalos = new List<Cara>();
            for (int i = 0; i < 10; i++)
            {
                float angle = i * (float)Math.PI * 2 / 10;
                float x = (float)Math.Sin(angle) * 0.4f;
                float z = (float)Math.Cos(angle) * 0.4f;

                var petalo = new Cara();
                petalo.AgregarPunto(new Vector3(0, 1.5f, -0.9f), Color.Yellow);
                petalo.AgregarPunto(new Vector3(x, 1.53f, -0.9f + z), Color.Yellow);
                petalo.AgregarPunto(new Vector3(0, 1.56f, -0.9f), Color.Yellow);
                petalos.Add(petalo);
            }


            for (int i = 0; i < petalos.Count; i++)
            {
                AgregarCara($"Petalo{i}", petalos[i]);
            }
            AgregarCara("BaseFlorero", baseFlorero);
            AgregarCara("Tallo", tallo);
        }
    }

}
