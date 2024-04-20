using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
namespace HelloWorld
{
    [Serializable]
    public class Parte
    {
        public Dictionary<string, Cara> caras { get; } = new Dictionary<string, Cara>();
        public Vector3 Posicion { get; set; }
        public Parte(Vector3 posicion)
        {
            caras = new Dictionary<string, Cara>();
            Posicion = posicion;
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

        public void Dibujar(Vector3 posicion)
        {
            foreach (var cara in caras.Values)
            {
                cara.TrazarPuntos(posicion);
            }
        }
    }
}
