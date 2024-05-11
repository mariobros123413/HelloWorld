using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class AccionTraslacion : Accion
    {
        private Vector3 inicio;
        private Vector3 fin;

        public AccionTraslacion(Objeto objeto, Vector3 inicio, Vector3 fin, int duracion) : base(objeto, duracion)
        {
            this.inicio = inicio;
            this.fin = fin;
        }

        public override void Ejecutar(float deltaTime)
        {
            float progress = tiempoTranscurrido / duracion;
            Vector3 posicionActual = Vector3.Lerp(inicio, fin, progress);
            objeto.AplicarTraslacion(posicionActual);
        }
    }
}
