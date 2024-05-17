using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public abstract class Accion
    {
        protected Objeto objeto;
        protected float duracion; // Duración en segundos
        protected float tiempoTranscurrido; // Tiempo transcurrido en segundos
        public Accion(Objeto objeto, float duracion)
        {
            this.objeto = objeto;
            this.duracion = duracion;
            this.tiempoTranscurrido = 0.0f;
        }

        public abstract void Ejecutar(float deltaTime);

        public bool Finalizada()
        {
            return tiempoTranscurrido >= duracion;
        }

        public void Actualizar(float deltaTime)
        {
            if (!Finalizada())
            {
                Ejecutar(deltaTime);
                tiempoTranscurrido += deltaTime;
                //Console.WriteLine("tiempoTranscurrido : " + tiempoTranscurrido);
            }
        }
    }
}