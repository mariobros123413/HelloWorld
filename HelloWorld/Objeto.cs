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

        private Matrix4 Transformacion { get; set; }
        private Matrix4 TransformacionInicial { get; set; }
        private Matrix4 MatrizTraslacion { get; set; }
        private Matrix4 MatrizEscalado { get; set; }
        private Matrix4 MatrizRotacionX { get; set; }
        private Matrix4 MatrizRotacionY { get; set; }
        private Matrix4 MatrizRotacionZ { get; set; }
        public float[] Posicion { get; set; } // Cambio de Vector3 a float[]
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
                    TransformacionInicial = Transformacion;
                }
                else
                {
                    throw new InvalidOperationException("Invalid matrix data");
                }
            }
        }
        public float[] PosicionSerializada
        {
            get { return Posicion; }
            set { Posicion = value; }
        }
        public float[] TraslacionSerializada
        {
            get { return MatrizToArray(MatrizTraslacion); }
            set { MatrizTraslacion = ArrayToMatrix(value); }
        }

        public float[] EscaladoSerializado
        {
            get { return MatrizToArray(MatrizEscalado); }
            set { MatrizEscalado = ArrayToMatrix(value); }
        }

        public float[] RotacionXSerializada
        {
            get { return MatrizToArray(MatrizRotacionX); }
            set { MatrizRotacionX = ArrayToMatrix(value); }
        }

        public float[] RotacionYSerializada
        {
            get { return MatrizToArray(MatrizRotacionY); }
            set { MatrizRotacionY = ArrayToMatrix(value); }
        }

        public float[] RotacionZSerializada
        {
            get { return MatrizToArray(MatrizRotacionZ); }
            set { MatrizRotacionZ = ArrayToMatrix(value); }
        }
        private float[] MatrizToArray(Matrix4 m)
        {
            return new float[]
            {
        m.M11, m.M12, m.M13, m.M14,
        m.M21, m.M22, m.M23, m.M24,
        m.M31, m.M32, m.M33, m.M34,
        m.M41, m.M42, m.M43, m.M44
            };
        }
        private Matrix4 ArrayToMatrix(float[] values)
        {
            if (values.Length == 16)
            {
                return new Matrix4(
                    values[0], values[1], values[2], values[3],
                    values[4], values[5], values[6], values[7],
                    values[8], values[9], values[10], values[11],
                    values[12], values[13], values[14], values[15]);
            }
            else
            {
                throw new InvalidOperationException("Invalid matrix data");
            }
        }
        public Objeto(float posX, float posY, float posZ)
        {
            Posicion = new float[] { posX, posY, posZ };
            partes = new Dictionary<string, Parte>();
            //Transformacion = Matrix4.Identity; // La transformación inicial es la identidad //ojo
            TransformacionInicial = Matrix4.Identity;
            MatrizTraslacion = Matrix4.Identity;
            MatrizEscalado = Matrix4.Identity;
            MatrizRotacionX = Matrix4.Identity;
            MatrizRotacionY = Matrix4.Identity;
            MatrizRotacionZ = Matrix4.Identity;
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
            MatrizTraslacion = Matrix4.CreateTranslation(traslacion) * Matrix4.Identity;
            Posicion = new float[] { traslacion.X, traslacion.Y, traslacion.Z };
        }
        public void AplicarRotacion(float incrementoAngulo, Vector4 eje)
        {
            if (eje.X != 0)
                MatrizRotacionX = Matrix4.CreateFromAxisAngle(new Vector3(eje.X, eje.Y, eje.Z), MathHelper.DegreesToRadians(incrementoAngulo));
            else if (eje.Y != 0)
                MatrizRotacionY = Matrix4.CreateFromAxisAngle(new Vector3(eje.X, eje.Y, eje.Z), MathHelper.DegreesToRadians(incrementoAngulo));
            else if (eje.Z != 0)
                MatrizRotacionZ = Matrix4.CreateFromAxisAngle(new Vector3(eje.X, eje.Y, eje.Z), MathHelper.DegreesToRadians(incrementoAngulo));
        }
        public void AplicarEscalado(Vector3 escala)
        {
            MatrizEscalado = Matrix4.CreateScale(escala) * Matrix4.Identity;
        }

        public void Dibujar(Matrix4 transformacionPadre)
        {
            // Combinar todas las transformaciones
            Matrix4 transformacionLocal = MatrizTraslacion * MatrizRotacionX * MatrizRotacionY * MatrizRotacionZ * MatrizEscalado;
            Matrix4 transformacionGlobal = transformacionLocal * transformacionPadre;

            foreach (var parte in partes.Values)
            {
                parte.Dibujar(transformacionGlobal);
            }
        }
    }
}