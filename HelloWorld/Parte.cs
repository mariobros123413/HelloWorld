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
        public Matrix4 Transformacion { get; private set; }
        public Parte(float posX, float posY, float posZ)
        {
            caras = new Dictionary<string, Cara>();
            Posicion = new float[3];
            Transformacion = Matrix4.CreateTranslation(posX, posY, posZ); // Aplicar traslación inicial
        }
        public void AgregarCara(string nombre, Cara cara)
        {
            if (caras.ContainsKey(nombre))
            {
                throw new ArgumentException($"Ya existe una cara con el nombre '{nombre}'.");
            }
            caras.Add(nombre, cara);
        }

        public Dictionary<string, Cara> ObtenerCaras()
        {
            return new Dictionary<string, Cara>(caras);
        }

        public void Dibujar(Matrix4 transformacionPadre)
        {
            Matrix4 transformacionGlobal = Transformacion * transformacionPadre;
            foreach (var cara in caras.Values)
            {
                cara.TrazarPuntos(transformacionGlobal);
            }
        }
    }
}
