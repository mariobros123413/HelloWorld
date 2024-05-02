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
        private Matrix4 Transformacion { get; set; }
        private Matrix4 TransformacionInicial { get; set; }

        public float[] TransformacionSerializada
        {
            get
            {
                return new float[]
                {
                Transformacion.M11, Transformacion.M12, Transformacion.M13, Transformacion.M14,
                Transformacion.M21, Transformacion.M22, Transformacion.M23, Transformacion.M24,
                Transformacion.M31, Transformacion.M32, Transformacion.M33, Transformacion.M34,
                Transformacion.M41, Transformacion.M42, Transformacion.M43, Transformacion.M44
                };
            }
            set
            {
                if (value.Length == 16)
                {
                    Transformacion = new Matrix4(
                        value[0], value[1], value[2], value[3],
                        value[4], value[5], value[6], value[7],
                        value[8], value[9], value[10], value[11],
                        value[12], value[13], value[14], value[15]);
                }
                else
                {
                    throw new InvalidOperationException("Invalid matrix data");
                }
            }
        }
        public Parte(float posX, float posY, float posZ)
        {
            caras = new Dictionary<string, Cara>();
            Posicion = new float[3];
            Transformacion = Matrix4.CreateTranslation(posX, posY, posZ); // Aplicar traslación inicial
        }
        public event EventHandler EscaladoCambiado;
        protected virtual void OnEscaladoCambiado(EventArgs e)
        {
            EscaladoCambiado?.Invoke(this, e);
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
            Transformacion = Matrix4.CreateTranslation(traslacion) * Transformacion;
        }

        public void AplicarRotacion(float incrementoAngulo, Vector3 eje)
        {
            // Recalcula la rotación desde el estado inicial con el ángulo acumulado actualizado.
            Matrix4 rotacionActual = Matrix4.CreateFromAxisAngle(eje, MathHelper.DegreesToRadians(incrementoAngulo));
            Transformacion = TransformacionInicial * rotacionActual; // Aplica la rotación a la matriz inicial.
        }

        public void AplicarEscalado(Vector3 escala)
        {
            Transformacion = Matrix4.CreateScale(escala) * Transformacion;

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
