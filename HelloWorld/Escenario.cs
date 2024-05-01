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
        public Vector3 Traslacion { get; set; }
        public Vector3 Rotacion { get; set; }
        public Vector3 Escala { get; set; }
        public float[] Posicion { get; set; }
        public Escenario(String nombre, float posX, float posY, float posZ)
        {
            Objetos = new Dictionary<string, Objeto>();
            Posicion = new float[] { posX, posY, posZ };
            this.Nombre = nombre;
            Traslacion = new Vector3(posX, posY, posZ);
            Rotacion = Vector3.Zero;
            Escala = Vector3.One;
        }
        public Matrix4 ObtenerTransformacion()
        {
            // Crear una matriz de traslación, rotación y escalado
            Matrix4 matrizTraslacion = Matrix4.CreateTranslation(Traslacion);
            Matrix4 matrizRotacion = Matrix4.CreateFromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(Rotacion.X)) *
                                     Matrix4.CreateFromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(Rotacion.Y)) *
                                     Matrix4.CreateFromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(Rotacion.Z));
            Matrix4 matrizEscala = Matrix4.CreateScale(Escala);

            // Combinar las matrices
            return matrizEscala * matrizRotacion * matrizTraslacion;
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
            // Actualizar la traslación
            Traslacion += traslacion;
        }

        public void AplicarRotacion(float angulo, Vector3 eje)
        {
            // Actualizar la rotación
            Rotacion += eje * angulo;
        }

        public void AplicarEscalado(Vector3 escala)
        {
            // Actualizar el escalado
            Escala *= escala;
        }

        public void Dibujar()  // Supongamos que es llamado por el renderizador en algún momento
        {
            foreach (Objeto objeto in Objetos.Values)
            {
                objeto.Dibujar(ObtenerTransformacion());
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
