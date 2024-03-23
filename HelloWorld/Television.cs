using System;
using System.ComponentModel;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace HelloWorld
{
    internal class Television
    {
        private GameWindow window;
        private float angle = 0.0f;

        public Television(GameWindow windowInput)
        {
            this.window = windowInput;
            window.Load += window_Load;
            window.RenderFrame += window_RenderFrame;
            window.UpdateFrame += window_UpdateFrame;
            window.Closing += window_Closing;
        }

        private void window_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.FromArgb(5, 5, 25));

            GL.Enable(EnableCap.DepthTest);
        }

        private void window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            SetupPerspective();
            
            SetupCamera();
            
            DrawTelevision();

            window.SwapBuffers();
        }

        private void DrawTelevision()
        {


            // Base de la televisión cara trasera
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.BlueViolet);
            GL.Vertex3(-0.4f, -0.9f, -1.0f);
            GL.Vertex3(0.4f, -0.9f, -1.0f);
            GL.Vertex3(0.4f, -0.6f, -1.0f);
            GL.Vertex3(-0.4f, -0.6f, -1.0f);
            GL.End();

            // Base de la televisión cara frontal
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.BlueViolet);
            GL.Vertex3(-0.4f, -0.9f, -0.8f);
            GL.Vertex3(0.4f, -0.9f, -0.8f);
            GL.Vertex3(0.4f, -0.6f, -0.8f);
            GL.Vertex3(-0.4f, -0.6f, -0.8f);
            GL.End();

            // Lado izquierdo de la base
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.BlueViolet);
            GL.Vertex3(-0.4f, -0.9f, -1.0f);
            GL.Vertex3(-0.4f, -0.9f, -0.8f); 
            GL.Vertex3(-0.4f, -0.6f, -0.8f); 
            GL.Vertex3(-0.4f, -0.6f, -1.0f);
            GL.End();

            // Lado derecho de la base
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.BlueViolet);
            GL.Vertex3(0.4f, -0.9f, -1.0f);
            GL.Vertex3(0.4f, -0.9f, -0.8f); 
            GL.Vertex3(0.4f, -0.6f, -0.8f); 
            GL.Vertex3(0.4f, -0.6f, -1.0f);
            GL.End();

            //Tapa Superior de la base
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.BlueViolet);
            GL.Vertex3(-0.4f, -0.7f, -1.0f);
            GL.Vertex3(0.4f, -0.7f, -1.0f);
            GL.Vertex3(0.4f, -0.7f, -0.8f);
            GL.Vertex3(-0.4f, -0.7f, -0.8f);

            //Tapa Inferior de la base
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.BlueViolet);
            GL.Vertex3(-0.4f, -0.9f, -1.0f);
            GL.Vertex3(0.4f, -0.9f, -1.0f);
            GL.Vertex3(0.4f, -0.9f, -0.8f);
            GL.Vertex3(-0.4f, -0.9f, -0.8f);

            ///////////////////////////////////////////////////
            // Marco de la televisión
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.CadetBlue);
            GL.Vertex3(-1.0f, -0.6f, -1.0f);
            GL.Vertex3(1.0f, -0.6f, -1.0f);
            GL.Vertex3(1.0f, 0.6f, -1.0f);
            GL.Vertex3(-1.0f, 0.6f, -1.0f);
            GL.End();

            // Lado izquierdo del Marco
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.CadetBlue);
            GL.Vertex3(-1.0f, -0.6f, -1.0f);
            GL.Vertex3(-1.0f, -0.6f, -0.8f); // Grosor
            GL.Vertex3(-1.0f, 0.6f, -0.8f); // Grosor
            GL.Vertex3(-1.0f, 0.6f, -1.0f);
            GL.End();

            // Lado derecho del Marco
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.CadetBlue);
            GL.Vertex3(1.0f, -0.6f, -1.0f);
            GL.Vertex3(1.0f, -0.6f, -0.8f); // Grosor
            GL.Vertex3(1.0f, 0.6f, -0.8f); // Grosor
            GL.Vertex3(1.0f, 0.6f, -1.0f);
            GL.End();

            //Tapa Superior del Marco
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.CadetBlue);
            GL.Vertex3(-1.0f, 0.6f, -1.0f);
            GL.Vertex3(-1.0f, 0.6f, -0.8f);
            GL.Vertex3(1.0f, 0.6f, -0.8f);
            GL.Vertex3(1.0f, 0.6f, -1.0f);
            GL.End();

            //Tapa Inferior del Marco
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.CadetBlue);
            GL.Vertex3(-1.0f, -0.6f, -1.0f);
            GL.Vertex3(-1.0f, -0.6f, -0.8f);
            GL.Vertex3(1.0f, -0.6f, -0.8f);
            GL.Vertex3(1.0f, -0.6f, -1.0f);
            GL.End();

            ////////////////////////////////////////
            // Pantalla frontal
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.DarkOrange);
            GL.Vertex3(-0.8f, -0.4f, -0.81f);
            GL.Vertex3(0.8f, -0.4f, -0.81f);
            GL.Vertex3(0.8f, 0.4f, -0.81f);
            GL.Vertex3(-0.8f, 0.4f, -0.81f);
            GL.End();
        }

        private void SetupPerspective()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // Configurar una proyección en perspectiva con un ángulo de visión más amplio
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60f), (float)window.Width / window.Height, 0.1f, 100f);
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
        private void SetupCamera()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Calcula la posición de la cámara en un círculo alrededor del objeto
            float camX = (float)Math.Sin(angle * Math.PI / 180.0) * 3.0f;
            float camZ = (float)Math.Cos(angle * Math.PI / 180.0) * 3.0f;

            Vector3 cameraPosition = new Vector3(camX, 1, camZ); // Ajusta la altura con el segundo parámetro si es necesario
            Vector3 cameraTarget = new Vector3(0, 0, 0); // El objeto está en el origen
            Vector3 cameraUp = new Vector3(0, 1, 0);

            Matrix4 lookAt = Matrix4.LookAt(cameraPosition, cameraTarget, cameraUp);
            GL.LoadMatrix(ref lookAt);
        }


        private void window_UpdateFrame(object sender, FrameEventArgs e)
        {
            // Incrementa el ángulo de rotación
            angle += (float)e.Time * 90.0f; // Velocidad

            // No desbordar el ángulo
            if (angle > 360.0f)
            {
                angle -= 360.0f;
            }

            // Aplica la rotación
            SetupCamera();
        }

        private void window_Closing(object sender, CancelEventArgs e)
        {
            
        }
    }
}
