using OpenTK;
using System;
using HelloWorld;

public class AccionMovimientoParabolico : Accion
{
    private float angulo;
    private float aceleracionInicial;
    private float gravedad;
    private float coeficienteRebote;
    private float alturaMinimaRebote = 0.5f;  // Altura mínima para considerar un rebote válido
    float desplazamientoX;
    float desplazamientoY;
    public AccionMovimientoParabolico(Objeto objeto, float angulo, float aceleracionInicial, float gravedad, float duracion, float coeficienteRebote)
        : base(objeto, duracion)
    {
        this.angulo = MathHelper.DegreesToRadians(angulo);  // Convertir ángulo a radianes
        this.aceleracionInicial = aceleracionInicial;
        this.gravedad = gravedad;
        this.coeficienteRebote = coeficienteRebote;
    }

    public override void Ejecutar(float deltaTime)
    {
        if (!esReboteFinalizado())
        {
            float tiempo = tiempoTranscurrido + deltaTime;
            desplazamientoX = aceleracionInicial * (float)Math.Cos(angulo) * tiempo;
            desplazamientoY = aceleracionInicial * (float)Math.Sin(angulo) * tiempo - 0.5f * gravedad * tiempo * tiempo;

            if (desplazamientoY < 0)
            {
                desplazamientoY = 0;
                float alturaProximoRebote = (aceleracionInicial * coeficienteRebote * (float)Math.Sin(angulo) * (duracion - tiempo) - 0.5f * gravedad * (duracion - tiempo) * (duracion - tiempo));

                Console.WriteLine("altura-----------------------------------------------------");
                Console.WriteLine(alturaProximoRebote);
                Console.WriteLine("altura min-----------------------------------------------------");
                Console.WriteLine(alturaMinimaRebote);

                if (alturaProximoRebote >= alturaMinimaRebote)
                {
                    // Si la altura del próximo rebote es suficiente, continuar con el rebote
                    aceleracionInicial *= coeficienteRebote;
                    tiempoTranscurrido = 0.0f;  // Reiniciar el tiempo para un nuevo ciclo de rebote
                    duracion *= coeficienteRebote;  // Ajustar duración del rebote
                    Console.WriteLine("itera 1-----------------------------------------------------");
                    Ejecutar(deltaTime);  // Llamar recursivamente con la nueva aceleración
                    return; // Salir para evitar que se ejecute el resto del código en esta iteración
                }
                else
                {
                    // Detener la acción si el siguiente rebote no supera la altura mínima
                    tiempoTranscurrido = duracion;
                }
            }

            // Almacenar la posición actual del objeto antes de aplicar el desplazamiento
            float[] posicionAnterior = new float[] { objeto.Posicion[0], objeto.Posicion[1], objeto.Posicion[2] };
            Console.WriteLine("objeto.Posicion[0]" + objeto.Posicion[0]);
            Console.WriteLine("desplazamientoX" + desplazamientoX);
            // Aplicar traslación relativa al desplazamiento calculado en esta iteración
//hacer restando -bjeto.Posicion[0] a desplazamientoX para que haya algo por lo menos de rebotes
            objeto.AplicarTraslacion(new Vector3(desplazamientoX, desplazamientoY, 0));
            tiempoTranscurrido += deltaTime; // Mover aquí la actualización del tiempo
        }
        Console.WriteLine("fuera");
    }
    private bool esReboteFinalizado()
    {
        Console.WriteLine("tiempo transcurrido : " + tiempoTranscurrido);
        Console.WriteLine("tiempo duracion: " + duracion);
        return tiempoTranscurrido >= duracion;
    }
}