using OpenTK;
using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace HelloWorld
{
    [Serializable]
    public class Escenario
    {
        private Dictionary<String, Objeto> Objetos;
        public Escenario()
        {
            Objetos = new Dictionary<string, Objeto>();
            Posicion = Vector3.Zero; // Esto asegura que la posición se inicialice correctamente
        }

        // Propiedad para la posición del escenario
        public Vector3 Posicion { get; set; }
        public void AgregarObjeto(String nombre, Objeto objeto)
        {
            Objetos.Add(nombre, objeto);
            Console.WriteLine(nombre);
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
