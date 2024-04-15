using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Objeto
    {
        public List<Cara> Caras { get; } = new List<Cara>();

        public void AgregarCara(Cara cara)
        {
            Caras.Add(cara ?? throw new ArgumentNullException(nameof(cara)));
        }

        public void Dibujar()
        {
            foreach (var cara in Caras)
            {
                cara.Dibujar();
            }
        }
    }
}
