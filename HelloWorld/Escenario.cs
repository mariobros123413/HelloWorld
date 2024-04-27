using OpenTK;
using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace HelloWorld
{
    [Serializable]
    public class Escenario
    {
        public Dictionary<String, Objeto> Objetos;
        public Escenario()
        {
            Objetos = new Dictionary<string, Objeto>();
            Posicion = new float[3];
        }

        public float[] Posicion { get; set; }
        public void AgregarObjeto(String nombre, Objeto objeto)
        {
            Objetos.Add(nombre, objeto);
            Console.WriteLine(nombre);
        }
        public Dictionary<string, Objeto> ObtenerObjetos()
        {
            return Objetos;
        }

        public Dictionary<string, Escenario> ObtenerEscenario()
        {
            return new Dictionary<string, Escenario>();
        }

        public void Dibujar()
        {
            GL.PushMatrix();
            GL.Translate(Posicion[0], Posicion[1], Posicion[2]);

            foreach (var objeto in Objetos.Values)
            {
                objeto.Dibujar();
            }

            GL.PopMatrix();
        }

    }
}
