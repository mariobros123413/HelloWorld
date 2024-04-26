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
            Posicion = Vector3.Zero;
        }

        public Vector3 Posicion { get; set; }
        public void AgregarObjeto(String nombre, Objeto objeto)
        {
            Objetos.Add(nombre, objeto);
            Console.WriteLine(nombre);
        }
        public Dictionary<string, Objeto> ObtenerObjetos()
        {
            return Objetos;
            //return new Dictionary<string, Objeto>(Objetos);
        }

        public Dictionary<string, Escenario> ObtenerEscenario()
        {
            return new Dictionary<string, Escenario>();
        }

        public void Dibujar()
        {
            GL.PushMatrix();
            GL.Translate(Posicion);

            foreach (var objeto in Objetos.Values)
            {
                objeto.Dibujar();
            }

            GL.PopMatrix();
        }

    }
}
