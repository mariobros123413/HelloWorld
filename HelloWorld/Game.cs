using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;

namespace HelloWorld
{
    internal class Game : GameWindow
    {
        private float angle = 0.0f;
        private List<Television> televisores = new List<Television>();


        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Multiple TVs")
        {
            Load += Game_Load;
            RenderFrame += Game_RenderFrame;
            UpdateFrame += Game_UpdateFrame;
            Closing += Game_Closing;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.FromArgb(5, 5, 25));
            GL.Enable(EnableCap.DepthTest);

            televisores.Add(new Television(0,0,0));
            televisores.Add(new Television(1,1,1));
            televisores.Add(new Television(-1,-1,-1));
        }

        private void Game_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SetupPerspective();
            SetupCamera();

            // Dibujar los televisores en la lista
            foreach (var televisor in televisores)
            {
                televisor.Dibujar();
            }

            SwapBuffers();
        }

        private void SetupPerspective()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // amplitud
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60f), (float)Width / Height, 0.1f, 100f);
            GL.LoadMatrix(ref perspective);

            GL.MatrixMode(MatrixMode.Modelview);
        }
        //private void SetupCamera() //Sin rotación
        //{
        //    GL.MatrixMode(MatrixMode.Modelview);
        //    GL.LoadIdentity();

        //    // Configurar la vista de la cámara
        //    Vector3 cameraPosition = new Vector3(3, -2, 3); // Posición de la cámara
        //    Vector3 cameraTarget = new Vector3(0, 0, 0);   // Punto hacia el que mira la cámara
        //    Vector3 cameraUp = new Vector3(0, 1, 0);       // Dirección "arriba" de la cámara

        //    Matrix4 lookAt = Matrix4.LookAt(cameraPosition, cameraTarget, cameraUp);
        //    GL.LoadMatrix(ref lookAt);
        //}
        private void SetupCamera() //con rotacion
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Calcula la posición de la cámara en un círculo alrededor del objeto
            float camX = (float)Math.Sin(angle * Math.PI / 180.0) * 3.0f;
            float camZ = (float)Math.Cos(angle * Math.PI / 180.0) * 3.0f;

            Vector3 cameraPosition = new Vector3(camX, 2, camZ); // 
            Vector3 cameraTarget = new Vector3(0, 0, 0); // El objeto está en el origen
            Vector3 cameraUp = new Vector3(0, 1, 0);

            Matrix4 lookAt = Matrix4.LookAt(cameraPosition, cameraTarget, cameraUp);
            GL.LoadMatrix(ref lookAt);
        }


        private void Game_UpdateFrame(object sender, FrameEventArgs e)
        {
            // Incrementa el ángulo de rotación
            angle += (float)e.Time * 90.0f; // Velocidad

            // No desbordar el ángulo
            if (angle > 360.0f)
            {
                angle -= 360.0f;
            }

            // Actualizar camara
            SetupCamera();
        }
        private void Game_Closing(object sender, CancelEventArgs e)
        {

        }
    }
}
