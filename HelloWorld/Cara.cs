using System;
using System.Drawing;
using OpenTK;

namespace HelloWorld
{
    [Serializable]
    public class Cara
    {
        public Puntos puntos;
        public Matrix4 LocalTransform { get; private set; }

        public Cara(Color color)
        {
            LocalTransform = Matrix4.Identity; // Inicia como la matriz identidad
            puntos = new Puntos(color);
        }

        public void AgregarPunto(Vector3 punto)
        {
            puntos.AgregarPunto(punto);
        }

        public void ActualizarTransformacionLocal(float[] desplazamiento)
        {
            // Actualiza la transformación local de la cara
            Matrix4 translationMatrix = Matrix4.CreateTranslation(desplazamiento[0], desplazamiento[1], desplazamiento[2]);
            LocalTransform = translationMatrix * LocalTransform;
        }

        public void Dibujar(Matrix4 parentTransform)
        {
            // Combina la transformación del objeto padre con la transformación local de la cara
            Matrix4 combinedTransform = LocalTransform * parentTransform;

            // Dibuja la geometría de la cara aplicando la transformación combinada
            puntos.TrazarPuntos(combinedTransform);
        }
    }

}
