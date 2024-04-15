using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class Escenario
    {
        private Dictionary<String, Objeto> Objetos;
        public Escenario()
        {
            Objetos = new Dictionary<String, Objeto>();
        }
        public void AgregarObjeto(String nombre, Objeto objeto)
        {
            Objetos.Add(nombre, objeto);
            Console.WriteLine(nombre);
        }

        public void Dibujar()
        {
            foreach (var objeto in Objetos.Values)
            {
                objeto.Dibujar();
            }
        }

    }
}
