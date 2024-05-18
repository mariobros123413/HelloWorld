using HelloWorld;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class AccionMovimientoParabolico : Accion
{
    private float angulo;
    private float velocidadInicial;
    private float gravedad;
    private float coeficienteRebote;
    private float alturaMinimaRebote = 0.5f;  // Altura mínima para considerar un rebote válido
    private float desplazamientoXAcumulado;
    private float desplazamientoY;
    private float tiempoRebote;
    private float tiempoTotal;
    private List<Objeto> objetos;
    public AccionMovimientoParabolico(Objeto objeto, List<Objeto> objetos, float angulo, float velocidadInicial, float gravedad, float duracion, float coeficienteRebote)
    : base(objeto, duracion)
    {
        this.angulo = MathHelper.DegreesToRadians(angulo);  // Convertir ángulo a radianes
        this.velocidadInicial = velocidadInicial;
        this.gravedad = gravedad;
        this.coeficienteRebote = coeficienteRebote;
        this.tiempoRebote = 0.0f;
        this.tiempoTotal = 0.0f;
        this.objetos = objetos;
        this.desplazamientoXAcumulado = objeto.Posicion[0];
        this.desplazamientoY = objeto.Posicion[1];
    }

    public override void Ejecutar(float deltaTime)
    {
        if (ColisionConOtroObjeto())
        {
            tiempoTranscurrido = duracion; // Detener la acción

        }
        else
        {
            
            CalcularTrayectoria(deltaTime);
            MoverObjeto();
        }
    }

    private bool ColisionConOtroObjeto()
    {
        foreach (var otroObjeto in objetos)
        {
            Console.WriteLine($"Posición actual: {objeto.Posicion[0]}, {objeto.Posicion[1]}, {objeto.Posicion[2]} vs {otroObjeto.Posicion[0]}, {otroObjeto.Posicion[1]}, {otroObjeto.Posicion[2]}");

            if (otroObjeto != objeto && objeto.ColisionaCon(otroObjeto))
            {
                Console.WriteLine("Colisión detectada.");
                velocidadInicial = 0;
                coeficienteRebote = 0;
                return true;
            }
        }

        Console.WriteLine("No hay colisión.");
        return false;
    }


    private void CalcularTrayectoria(float deltaTime)
    {
        tiempoRebote += deltaTime;
        tiempoTotal += deltaTime;
        desplazamientoY = velocidadInicial * (float)Math.Sin(angulo) * tiempoRebote - 0.5f * gravedad * tiempoRebote * tiempoRebote;


        // Si el objeto alcanza el suelo
        if (desplazamientoY <= 0)
        {
            desplazamientoY = 0;
            float velocidadYRebote = velocidadInicial * coeficienteRebote * (float)Math.Sin(angulo);

            if (velocidadYRebote * velocidadYRebote / (2 * gravedad) >= alturaMinimaRebote)
            {
                // Si la altura del próximo rebote es suficiente, ajustar la velocidad para el nuevo rebote
                velocidadInicial *= coeficienteRebote;
                tiempoRebote = 0.0f;  // Reiniciar el tiempo para un nuevo ciclo de rebote
                angulo = (float)Math.Atan2(velocidadYRebote, velocidadInicial * (float)Math.Cos(angulo));
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

    private void MoverObjeto()
    {
        objeto.AplicarTraslacion(new Vector3(desplazamientoXAcumulado, desplazamientoY, 0));
    }
}