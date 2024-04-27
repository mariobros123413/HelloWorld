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
        public Matrix4 LocalTransform { get; private set; }

        public Dictionary<string, Cara> Caras { get; } = new Dictionary<string, Cara>();
        public float AnguloRotacion { get; set; } // Nuevo atributo para el ángulo de rotación
        public float VelocidadRotacion { get; set; } // Atributo para la velocidad de rotación

        public Parte(float[] posicionInicial)
        {
            LocalTransform = Matrix4.CreateTranslation(posicionInicial[0], posicionInicial[1], posicionInicial[2]);
        }

        public void AgregarCara(string nombre, Cara cara)
        {
            if (Caras.ContainsKey(nombre))
            {
                throw new ArgumentException($"Ya existe una cara con el nombre '{nombre}'.");
            }
            Caras.Add(nombre, cara);
        }

        public void ActualizarTransformacionLocal(float[] desplazamiento)
        {
            // Actualiza la transformación local de la parte
            Matrix4 translationMatrix = Matrix4.CreateTranslation(desplazamiento[0], desplazamiento[1], desplazamiento[2]);
            LocalTransform *= translationMatrix; // *= para combinar las transformaciones
        }

        public void Dibujar(Matrix4 parentTransform)
        {
            Matrix4 rotationMatrix = Matrix4.CreateRotationY(AnguloRotacion); // Crea la matriz de rotación
            Matrix4 finalTransform = LocalTransform * rotationMatrix * parentTransform; // Combina todas las transformaciones

            foreach (var cara in Caras.Values)
            {
                cara.Dibujar(finalTransform);
            }
        }
    }
}
