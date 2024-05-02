using OpenTK;
using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Graphics;

namespace HelloWorld
{
    [Serializable]
    public class Escenario
    {
        public String Nombre;
        public Dictionary<String, Objeto> Objetos;
        private Matrix4 Transformacion { get; set; }
        private Matrix4 TransformacionInicial { get; set; }
        public float[] Posicion { get; set; }
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
        public Escenario(String nombre, float posX, float posY, float posZ)
        {
            Objetos = new Dictionary<string, Objeto>();
            Posicion = new float[] { posX, posY, posZ };
            this.Nombre = nombre;
            Transformacion = Matrix4.CreateTranslation(posX, posY, posZ);
        }
        public event EventHandler EscaladoCambiado;
        protected virtual void OnEscaladoCambiado(EventArgs e)
        {
            EscaladoCambiado?.Invoke(this, e);
        }

        public Matrix4 getTransformacion()
        {
            return this.Transformacion;
        }
        public void AgregarObjeto(String nombre, Objeto objeto)
        {
            Objetos.Add(nombre, objeto);
            Console.WriteLine(nombre);
        }
        public Dictionary<string, Objeto> ObtenerObjetos()
        {
            return Objetos;
        }

        public Dictionary<string, Escenario> ObtenerEscenario()
        {
            return new Dictionary<string, Escenario>();
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
        public void Dibujar()  // Supongamos que es llamado por el renderizador en algún momento
        {
            foreach (var objeto in Objetos.Values)
            {
                objeto.Dibujar(Transformacion);
            }
        }
        public void Dibujar2(Matrix4 transf)
        {
            GL.PushMatrix();
            GL.MultMatrix(ref transf);

            // Dibujar el eje X en rojo
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(5.0f, 0.0f, 0.0f);
            GL.End();

            // Dibujar el eje X en rojo
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(-5.0f, 0.0f, 0.0f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-1.0f, 0.0f, -0.5f);
            GL.Vertex3(-1.0f, 0.0f, 0.5f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(1.0f, 0.0f, -0.5f);
            GL.Vertex3(1.0f, 0.0f, 0.5f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-2.0f, 0.0f, -0.5f);
            GL.Vertex3(-2.0f, 0.0f, 0.5f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(2.0f, 0.0f, -0.5f);
            GL.Vertex3(2.0f, 0.0f, 0.5f);
            GL.End();
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-3.0f, 0.0f, -0.5f);
            GL.Vertex3(-3.0f, 0.0f, 0.5f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(3.0f, 0.0f, -0.5f);
            GL.Vertex3(3.0f, 0.0f, 0.5f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-4.0f, 0.0f, -0.5f);
            GL.Vertex3(-4.0f, 0.0f, 0.5f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(4.0f, 0.0f, -0.5f);
            GL.Vertex3(4.0f, 0.0f, 0.5f);
            GL.End();
            // Dibujar el eje Y en verde
            GL.Color3(Color.Green);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 2.0f, 0.0f);
            GL.End();

            // Dibujar el eje Y en verde
            GL.Color3(Color.Green);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, -2.0f, 0.0f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0f, 1.0f, -0.5f);
            GL.Vertex3(0.0f, 1.0f, 0.5f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0f, -1.0f, -0.5f);
            GL.Vertex3(0.0f, -1.0f, 0.5f);
            GL.End();

            // Dibujar el eje Z en azul
            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 2.0f);
            GL.End();

            // Dibujar el eje Z en azul
            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, -2.0f);
            GL.End();
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-0.5f, 0.0f, 1.0f);
            GL.Vertex3(0.5f, 0.0f, 1.0f);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-0.5f, 0.0f, -1.0f);
            GL.Vertex3(0.5f, 0.0f, -1.0f);
            GL.End();
            GL.PopMatrix();

        }



    }
}
