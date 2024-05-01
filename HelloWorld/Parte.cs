using OpenTK;
using System;
using System.Collections.Generic;
namespace HelloWorld
{
    [Serializable]
    public class Parte
    {
        public Dictionary<string, Cara> caras { get; } = new Dictionary<string, Cara>();
        public float[] Posicion { get; set; } // Cambio de Vector3 a float[]
        public Vector3 Traslacion { get; set; }
        public Vector3 Rotacion { get; set; }
        public Vector3 Escala { get; set; }
        public Parte(float posX, float posY, float posZ)
        {
            caras = new Dictionary<string, Cara>();
            Posicion = new float[3];
            Traslacion = new Vector3(posX, posY, posZ);
            Rotacion = Vector3.Zero;
            Escala = Vector3.One;
        }
        public Matrix4 ObtenerTransformacion()
        {
            // Crear una matriz de traslación, rotación y escalado
            Matrix4 matrizTraslacion = Matrix4.CreateTranslation(Traslacion);
            Matrix4 matrizRotacion = Matrix4.CreateFromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(Rotacion.X)) *
                                     Matrix4.CreateFromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(Rotacion.Y)) *
                                     Matrix4.CreateFromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(Rotacion.Z));
            Matrix4 matrizEscala = Matrix4.CreateScale(Escala);

            // Combinar las matrices
            return matrizEscala * matrizRotacion * matrizTraslacion;
        }
        public void AgregarCara(string nombre, Cara cara)
        {
            if (caras.ContainsKey(nombre))
            {
                throw new ArgumentException($"Ya existe una cara con el nombre '{nombre}'.");
            }
            caras.Add(nombre, cara);
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
            // Actualizar el escalado
            Escala *= escala;
        }

        public Dictionary<string, Cara> ObtenerCaras()
        {
            return new Dictionary<string, Cara>(caras);
        }

        public void Dibujar(Matrix4 transformacionPadre)
        {
            Matrix4 transformacionGlobal = ObtenerTransformacion() * transformacionPadre;
            foreach (var cara in caras.Values)
            {
                cara.TrazarPuntos(transformacionGlobal);
            }
        }
    }
}
