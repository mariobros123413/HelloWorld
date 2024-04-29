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
        public Matrix4 Transformacion { get; private set; }
        public float[] Posicion { get; set; } // Cambio de Vector3 a float[]
        public Objeto(float posX, float posY, float posZ )
        {
            Posicion = new float[3];
            partes = new Dictionary<string, Parte>();
            Transformacion = Matrix4.CreateTranslation(posX, posY, posZ); // Aplicar traslación inicial

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
        }

        public void AplicarRotacion(float angulo, Vector3 eje)
        {
            Transformacion = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angulo)) * Transformacion;
        }

        public void AplicarEscalado(Vector3 escala)
        {
            Transformacion = Matrix4.CreateScale(escala) * Transformacion;
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
