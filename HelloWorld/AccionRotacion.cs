using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class AccionRotacion : Accion
    {
        private float anguloInicial;
        private float anguloFinal;
        private Vector4 eje;

        public AccionRotacion(Objeto objeto, float anguloInicial, float anguloFinal, Vector4 eje, float duracion) : base(objeto, duracion)
        {
            this.anguloInicial = anguloInicial;
            this.anguloFinal = anguloFinal;
            this.eje = eje;
        }

        public override void Ejecutar(float deltaTime)
        {
            float t = tiempoTranscurrido / duracion;
            t = SmoothStep(t); // Interpolación cúbica
            float anguloInterpolado = Lerp(anguloInicial, anguloFinal*2, t);
            objeto.AplicarRotacion(anguloInterpolado - objeto.UltimoAnguloAplicado, eje);
        }

        private float SmoothStep(float t)
        {
            return t * t * (3f - 2f * t);
        }

        private float Lerp(float start, float end, float t)
        {
            return (1 - t) * start + t * end;
        }
    }
}
