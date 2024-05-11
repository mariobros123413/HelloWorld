using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class AccionEscalado : Accion
    {
        private Vector3 escalaInicial;
        private Vector3 escalaFinal;

        public AccionEscalado(Objeto objeto, Vector3 escalaInicial, Vector3 escalaFinal, float duracion) : base(objeto, duracion)
        {
            this.escalaInicial = escalaInicial;
            this.escalaFinal = escalaFinal;
        }

        public override void Ejecutar(float deltaTime)
        {
            float t = tiempoTranscurrido / duracion;
            t = SmoothStep(t); // Interpolación cúbica
            Vector3 escalaInterpolada = Vector3.Lerp(escalaInicial, escalaFinal, t);
            objeto.AplicarEscalado(escalaInterpolada);
        }

        private float SmoothStep(float t)
        {
            return t * t * (3f - 2f * t);
        }
    }
}
