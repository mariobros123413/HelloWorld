using System;
using System.Collections.Generic;
namespace HelloWorld
{
    [Serializable]
    public class Parte
    {
        public Dictionary<string, Cara> caras { get; } = new Dictionary<string, Cara>();
        public float[] Posicion { get; set; } // Cambio de Vector3 a float[]
        public Parte()
        {
            caras = new Dictionary<string, Cara>();
            Posicion = new float[3];
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

        public void Dibujar(float[] posicion)
        {
            foreach (var cara in caras.Values)
            {
                cara.TrazarPuntos(posicion);
            }
        }
    }
}
