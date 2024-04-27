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
        public float[] Posicion { get; set; } // Cambio de Vector3 a float[]
        public Matrix4 TransformMatrix { get;  set; }  // Matriz de transformación del objeto

        public Objeto()
        {
            Posicion = new float[3];
            partes = new Dictionary<string, Parte>();
            TransformMatrix = Matrix4.Identity;  // Inicia como la matriz identidad

        }

        public void AgregarParte(string nombre, Parte parte)
        {
            if (parte == null)
                throw new ArgumentNullException(nameof(parte));
            partes.Add(nombre, parte);
        }
        public void ActualizarTransformacion()
        {
            // Crea una matriz de traslación y la acumula en TransformMatrix
            TransformMatrix = Matrix4.CreateTranslation(Posicion[0], Posicion[1], Posicion[2]) * TransformMatrix;
        }
        public Dictionary<string, Parte> ObtenerPartes()
        {
            return new Dictionary<string, Parte>(partes);
        }
        public void Dibujar()
        {
            foreach (var parte in partes.Values)
            {
                parte.Dibujar(TransformMatrix);
            }
        }
    }
}
