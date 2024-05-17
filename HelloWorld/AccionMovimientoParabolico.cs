using HelloWorld;
using OpenTK;
using System;

public class AccionMovimientoParabolico : Accion
{
    private float angulo;
    private float velocidadInicial;
    private float gravedad;
    private float coeficienteRebote;
    private float alturaMinimaRebote = 0.5f;  // Altura mínima para considerar un rebote válido
    private float desplazamientoXAcumulado = 0.0f;
    private float desplazamientoY;
    private float tiempoRebote;
    private float tiempoTotal;

    public AccionMovimientoParabolico(Objeto objeto, float angulo, float velocidadInicial, float gravedad, float duracion, float coeficienteRebote)
    : base(objeto, duracion)
    {
        this.angulo = MathHelper.DegreesToRadians(angulo);  // Convertir ángulo a radianes
        this.velocidadInicial = velocidadInicial;
        this.gravedad = gravedad;
        this.coeficienteRebote = coeficienteRebote;
        this.tiempoRebote = 0.0f;
        this.tiempoTotal = 0.0f;
    }

    public override void Ejecutar(float deltaTime)
    {
        CalcularTrayectoria(deltaTime);
        MoverObjeto();
    }

    private void CalcularTrayectoria(float deltaTime)
    {
        tiempoRebote += deltaTime;
        tiempoTotal += deltaTime;

        // Cálculo del desplazamiento en X desde el último rebote
        float desplazamientoX = velocidadInicial * (float)Math.Cos(angulo) * tiempoRebote;

        // Cálculo del desplazamiento en Y
        desplazamientoY = velocidadInicial * (float)Math.Sin(angulo) * tiempoRebote - 0.5f * gravedad * tiempoRebote * tiempoRebote;

        // Si el objeto alcanza el suelo
        if (desplazamientoY <= 0)
        {
            desplazamientoY = 0;
            float velocidadYRebote = velocidadInicial * coeficienteRebote * (float)Math.Sin(angulo);

            if (velocidadYRebote * velocidadYRebote / (2 * gravedad) >= alturaMinimaRebote)
            {
                // Si la altura del próximo rebote es suficiente, ajustar los parámetros para el rebote
                velocidadInicial *= coeficienteRebote;
                tiempoRebote = 0.0f;  // Reiniciar el tiempo para un nuevo ciclo de rebote
                angulo = (float)Math.Atan2(velocidadYRebote, velocidadInicial * (float)Math.Cos(angulo));

                // Acumular el desplazamiento en X
                Console.WriteLine("desplazamientoXAcumulado" + desplazamientoXAcumulado);
                //desplazamientoXAcumulado += desplazamientoX;
            }
            else
            {
                // Detener la acción si el siguiente rebote no supera la altura mínima
                tiempoTranscurrido = duracion;
            }
        }
        else
        {
            // Actualizar el desplazamiento en X acumulado continuamente
            desplazamientoXAcumulado += velocidadInicial * (float)Math.Cos(angulo) * deltaTime;
        }
    }

    private float posicionXAnterior = 0.0f;

    private void MoverObjeto()
    {
        objeto.AplicarTraslacion(new Vector3(desplazamientoXAcumulado, desplazamientoY, 0));
        posicionXAnterior = desplazamientoXAcumulado;
    }
}