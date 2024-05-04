﻿using OpenTK;
using System;
using System.Collections.Generic;
namespace HelloWorld
{
    [Serializable]
    public class Parte
    {
        public Dictionary<string, Cara> caras { get; } = new Dictionary<string, Cara>();
        public float[] Posicion { get; set; }
        private Matrix4 MatrizTraslacion { get; set; }
        private Matrix4 MatrizEscalado { get; set; }
        private Matrix4 MatrizRotacionX { get; set; }
        private Matrix4 MatrizRotacionY { get; set; }
        private Matrix4 MatrizRotacionZ { get; set; }
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
        public Parte(float posX, float posY, float posZ)
        {
            caras = new Dictionary<string, Cara>();
            Posicion = new float[3];
            MatrizTraslacion = Matrix4.CreateTranslation(posX, posY, posZ);
            MatrizEscalado = Matrix4.Identity;
            MatrizRotacionX = Matrix4.Identity;
            MatrizRotacionY = Matrix4.Identity;
            MatrizRotacionZ = Matrix4.Identity;
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
            Matrix4 transformacionLocal = MatrizRotacionX * MatrizRotacionY * MatrizRotacionZ * MatrizEscalado * MatrizTraslacion;
            Matrix4 transformacionGlobal = transformacionLocal * transformacionPadre; foreach (var cara in caras.Values)
            {
                cara.Dibujar(transformacionGlobal);
            }
        }
    }
}
