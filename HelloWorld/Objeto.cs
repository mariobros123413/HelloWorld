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
        // Propiedades para almacenar los componentes de transformación
        public Vector3 Traslacion { get; set; }
        public Vector3 Rotacion { get; set; }
        public Vector3 Escala { get; set; }
        public float[] Posicion { get; set; } // Cambio de Vector3 a float[]
        public Objeto(float posX, float posY, float posZ)
        {
            Posicion = new float[3];
            partes = new Dictionary<string, Parte>();
            // Inicializar los componentes de transformación
            Traslacion = Vector3.Zero;
            Rotacion = Vector3.Zero;
            Escala = Vector3.One;
        }
        public Matrix4 ObtenerTransformacion()
        {
            // Crear una matriz de escalado
            Matrix4 matrizEscala = Matrix4.CreateScale(Escala);

            // Crear una matriz de rotación
            Matrix4 matrizRotacion = Matrix4.CreateFromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(Rotacion.X)) *
                                     Matrix4.CreateFromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(Rotacion.Y)) *
                                     Matrix4.CreateFromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(Rotacion.Z));

            // Crear una matriz de traslación
            Matrix4 matrizTraslacion = Matrix4.CreateTranslation(Traslacion);

            // Combinar las matrices en el orden correcto: primero escalado, luego rotación, y finalmente traslación
            return matrizEscala * matrizRotacion * matrizTraslacion;
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
            // Actualizar la traslación
            Traslacion += traslacion;
        }

        public void AplicarRotacion(float angulo, Vector3 eje)
        {
            // Actualizar la rotación
            Rotacion += eje * angulo;
        }

        public void AplicarEscalado(Vector3 escala)
        {
            Escala *= escala;
        }

        public void Dibujar(Matrix4 transformacionPadre)
        {
            Matrix4 transformacionGlobal = ObtenerTransformacion() * transformacionPadre;

            foreach (Parte parte in partes.Values)
            {
                parte.Dibujar(transformacionGlobal);
            }
        }
    }
}
