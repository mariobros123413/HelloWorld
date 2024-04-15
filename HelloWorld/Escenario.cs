using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Escenario
    {
        public List<Objeto> Objetos { get; } = new List<Objeto>();

        public void AgregarObjeto(Objeto objeto)
        {
            Objetos.Add(objeto);
        }

        public void Dibujar()
        {
            foreach (var objeto in Objetos)
            {
                objeto.Dibujar();
            }
        }
    }
}
