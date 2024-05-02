using OpenTK;
using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
namespace HelloWorld
{
    [Serializable]
    public class Objeto
    {
        public Dictionary<string, Parte> partes;
        private Matrix4 TransformacionInicial { get; set; }
        private Matrix4 Transformacion { get; set; }
private Quaternion rotacionTotal = Quaternion.Identity;

        public float[] Posicion { get; set; } // Cambio de Vector3 a float[]
        public float[] TransformacionSerializada
        {
            get
            {
                return new float[]
                {
                Transformacion.M11, Transformacion.M12, Transformacion.M13, Transformacion.M14,
                Transformacion.M21, Transformacion.M22, Transformacion.M23, Transformacion.M24,
                Transformacion.M31, Transformacion.M32, Transformacion.M33, Transformacion.M34,
                Transformacion.M41, Transformacion.M42, Transformacion.M43, Transformacion.M44
                };
            }
            set
            {
                if (value.Length == 16)
                {
                    Transformacion = new Matrix4(
                        value[0], value[1], value[2], value[3],
                        value[4], value[5], value[6], value[7],
                        value[8], value[9], value[10], value[11],
                        value[12], value[13], value[14], value[15]);
                }
                else
                {
                    throw new InvalidOperationException("Invalid matrix data");
                }
            }
        }
        public Objeto(float posX, float posY, float posZ)
        {
            Posicion = new float[] { posX, posY, posZ };
            partes = new Dictionary<string, Parte>();
            Transformacion = Matrix4.Identity; // La transformación inicial es la identidad
            TransformacionInicial = Matrix4.Identity; // Almacena la transformación inicial.

        }
        public void AgregarParte(string nombre, Parte parte)
        {
            if (parte == null)
                throw new ArgumentNullException(nameof(parte));
            partes.Add(nombre, parte);
        }

        public Dictionary<string, Parte> ObtenerPartes()
        {
            return new Dictionary<string, Parte>(partes);
        }
        public void AplicarTraslacion(Vector3 traslacion)
        {
            Transformacion = Matrix4.CreateTranslation(traslacion) * Transformacion;
            //Posicion = new float[] { Posicion[0]+traslacion.X, Posicion[1] + traslacion.Y , Posicion[2] + traslacion.Z };
        }

        public void AplicarRotacion(float incrementoAngulo, Vector3 eje)
        {
            // Recalcula la rotación desde el estado inicial con el ángulo acumulado actualizado.
            Matrix4 rotacionActual = Matrix4.CreateFromAxisAngle(eje, MathHelper.DegreesToRadians(incrementoAngulo));
            Transformacion = TransformacionInicial * rotacionActual; // Aplica la rotación a la matriz inicial.
        }

        public void AplicarEscalado(Vector3 escala)
        {
            Console.WriteLine("PREVIA \n" + Transformacion);

            // Paso 1: Traslación inversa para mover el objeto al origen
            Matrix4 traslacionInversa = Matrix4.CreateTranslation(-Posicion[0], -Posicion[1], -Posicion[2]);
            Transformacion = traslacionInversa * Transformacion; // Mueve centro al origen

            // Paso 2: Aplicar escalado en el origen
            Matrix4 escalaMatriz = Matrix4.CreateScale(escala);
            Transformacion = escalaMatriz * Transformacion; // Escala con centro en el origen

            // Paso 3: Trasladar de vuelta a la posición original
            Matrix4 traslacionOriginal = Matrix4.CreateTranslation(Posicion[0], Posicion[1], Posicion[2]);
            Transformacion = traslacionOriginal * Transformacion; // Mueve centro de vuelta
            TransformacionInicial = Transformacion;
            Console.WriteLine("DESPUÉS \n" + Transformacion);
        }




        public void Dibujar(Matrix4 transformacionPadre)
        {
            Matrix4 transformacionGlobal = Transformacion * transformacionPadre;

            foreach (var parte in partes.Values)
            {
                parte.Dibujar(transformacionGlobal);
            }
        }
    }
}
