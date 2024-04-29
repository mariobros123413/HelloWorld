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
        public Matrix4 Transformacion { get; set; }
        public float[] Posicion { get; set; }
        public Escenario(String nombre, float posX, float posY, float posZ)
        {
            Objetos = new Dictionary<string, Objeto>();
            Posicion = new float[] { posX, posY, posZ };
            this.Nombre = nombre;
            Transformacion = Matrix4.CreateTranslation(posX, posY, posZ); // Aplicar traslación inicial
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

        public void AplicarRotacion(float angulo, Vector3 eje)
        {
            Transformacion = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angulo)) * Transformacion;
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
            GL.Vertex3(2.0f, 0.0f, 0.0f);
            GL.End();

            // Dibujar el eje X en rojo
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(-2.0f, 0.0f, 0.0f);
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
