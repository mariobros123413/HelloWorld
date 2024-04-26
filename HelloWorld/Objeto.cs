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
        public Vector3 Posicion { get; set; }
        public Objeto(Vector3 posicion)
        {
            Posicion = posicion;
            partes = new Dictionary<string, Parte>();

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

        public void Dibujar()
        {
            foreach (var parte in partes.Values)
            {
                parte.Dibujar(Posicion);
            }
        }
    }
}
