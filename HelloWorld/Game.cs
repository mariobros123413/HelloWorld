using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.Drawing;

namespace HelloWorld
{
    internal class Game : GameWindow
    {
        private float angle = 0.0f;
        private Escenario escenario;


        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Multiple TVs")
        {
            escenario = new Escenario();
            Television television = new Television(new Vector3(0, 0, 0));
            escenario.AgregarObjeto("Television", television);

            Television television2 = new Television(new Vector3(3, 0, 0)); // Por ejemplo, en (2, 0, 0)
            escenario.AgregarObjeto("Television2", television2);

            Television television3 = new Television(new Vector3(-3, 0, 0)); // Por ejemplo, en (2, 0, 0)
            escenario.AgregarObjeto("Television3", television3);

            Florero florero = new Florero(new Vector3(0, 0, 0));
            escenario.AgregarObjeto("Florero", florero);

            Florero florero2 = new Florero(new Vector3(3, 0, 0));
            escenario.AgregarObjeto("Florero2", florero2);

            Florero florero3 = new Florero(new Vector3(-3, 0, 0));
            escenario.AgregarObjeto("Florero3", florero3);

            EquipoSonido equipoSonido = new EquipoSonido(new Vector3(0, 0, 0));
            escenario.AgregarObjeto("EquipoSonido", equipoSonido);

            Load += Game_Load;
            RenderFrame += Game_RenderFrame;
            UpdateFrame += Game_UpdateFrame;
            Closing += Game_Closing;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.FromArgb(5, 5, 25));
            GL.Enable(EnableCap.DepthTest);
        }

        private void Game_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            SetupPerspective();
            SetupCamera();
            escenario.Dibujar();
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

            float distance = 6.0f; // Distancia 

            float camX = (float)Math.Sin(angle * Math.PI / 180.0) * distance;
            float camZ = (float)Math.Cos(angle * Math.PI / 180.0) * distance;

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
