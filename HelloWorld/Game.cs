using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using OpenTK.Input;
using static HelloWorld.FormMenu;

namespace HelloWorld
{
    public class Game : GameWindow
    {
        private float angle = 0.0f;
        public List<Escenario> listaEscenarios = new List<Escenario>();
        public FormMenu menu;
        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Multiple TVs")
        {
            FormMenu menuForm = new FormMenu(this);

            Escenario escenario = new Escenario("Escenario 1", 1.0f, 1.0f, 1.0f);
            escenario.AplicarRotacion(45, new Vector4(1, 0, 0, 1));

            Objeto Television1 = CrearTelevision(new float[] { 0.0f, 0.0f, 0.0f }, Color.CadetBlue, Color.BlueViolet, Color.DarkOrange);
            Television1.AplicarRotacion(45, new Vector4(1, 0, 0, 1));
            escenario.AgregarObjeto("Television", Television1);
            Objeto Television2 = CrearTelevision(new float[] { 3.0f, 0.0f, 0.0f }, Color.CadetBlue, Color.BlueViolet, Color.DarkOrange);
            escenario.AgregarObjeto("Television2", Television2);
            Objeto Television3 = CrearTelevision(new float[] { 3.0f, 2.0f, 3.0f }, Color.CadetBlue, Color.BlueViolet, Color.DarkOrange);
            escenario.AgregarObjeto("Television3", Television3);
            Objeto Bocina1 = CrearEquipoSonido(new float[] { 0.0f, 0.0f, 0.0f });
            escenario.AgregarObjeto("Bocina1", Bocina1);
            Objeto CrearFlorero1 = CrearFlorero(new float[] { 0.0f, 0.0f, 0.0f });
            escenario.AgregarObjeto("CrearFlorero1", CrearFlorero1);
            listaEscenarios.Add(escenario);

            // Serializar el escenario a un archivo JSON
            //
            Escenario escenario2 = new Escenario("Escenario 2", -1.0f, -1.0f, -1.0f);


            Objeto Television4 = CrearTelevision(new float[] { 0.0f, 0.0f, 0.0f }, Color.LightYellow, Color.Magenta, Color.DarkOrange);
            Television4.AplicarTraslacion(new Vector3(-3, 0, 0));
            //Television4.partes["Base"].AplicarTraslacion(new Vector3(-2, 0, 0));
            //Television4.partes["Base"].AplicarRotacion(17,new Vector3(-2, 0, 0));
            //Television4.partes["Base"].AplicarEscalado(new Vector3(5, 5, 5));
            Television4.AplicarEscalado(new Vector3(5, 5, 5));
            //Television4.AplicarRotacion(90, new Vector3(0, 1, 0));
            escenario2.AgregarObjeto("Television4", Television4);
            Objeto Television5 = CrearTelevision(new float[] { 3f, 0.0f, 0.0f }, Color.LightYellow, Color.Magenta, Color.DarkOrange);
            escenario2.AgregarObjeto("Television5", Television5);
            Objeto Television6 = CrearTelevision(new float[] { 3.0f, 2.0f, 3.0f }, Color.LightYellow, Color.Magenta, Color.DarkOrange);
            escenario2.AgregarObjeto("Television6", Television6);
            Objeto Bocina2 = CrearEquipoSonido(new float[] { 0.0f, 0.0f, 0.0f });
            escenario2.AgregarObjeto("Bocina2", Bocina2);
            Objeto CrearFlorero2 = CrearFlorero(new float[] { 0.0f, 0.0f, 0.0f });
            //CrearFlorero2.AplicarEscalado(new Vector3(5, 5, 5));
            escenario2.AgregarObjeto("CrearFlorero2", CrearFlorero2);
            //Objeto esfera = CrearEsfera();
            //esfera.AplicarEscalado(new Vector3(2, 2, 2));
            //escenario2.AgregarObjeto("esfera1", esfera);
            listaEscenarios.Add(escenario2);
            Load += Game_Load;
            RenderFrame += Game_RenderFrame;
            UpdateFrame += Game_UpdateFrame;
            Closing += Game_Closing;
            menuForm.Show();
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
            foreach (var escenario in listaEscenarios)
            {
                escenario.Dibujar();
                escenario.Dibujar2(escenario.getTransformacion());
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
        //    Vector3 cameraPosition = new Vector3(-2, 2, 8); // Posición de la cámara
        //    Vector3 cameraTarget = new Vector3(0, 0, 0);   // Punto hacia el que mira la cámara
        //    Vector3 cameraUp = new Vector3(0, 1, 0);       // Dirección "arriba" de la cámara

        //    Matrix4 lookAt = Matrix4.LookAt(cameraPosition, cameraTarget, cameraUp);
        //    GL.LoadMatrix(ref lookAt);
        //}
        private void SetupCamera() //con rotacion
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            float distance = 15.0f; // Distancia 

            float camX = (float)Math.Sin(angle * Math.PI / 180.0) * distance;
            float camZ = (float)Math.Cos(angle * Math.PI / 180.0) * distance;

            Vector3 cameraPosition = new Vector3(camX, 2, camZ);
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
            foreach (var escenario in listaEscenarios)
            {
                escenario.Dibujar();
            }
            SetupCamera();
        }
        private void Game_Closing(object sender, CancelEventArgs e)
        {

        }
        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.F1)
            {
                menu.Show();
            }
        }
        private Objeto CrearTelevision(float[] posicion, Color marcoc, Color Base, Color pantallac)
        {
            Objeto television = new Objeto(posicion[0], posicion[1], posicion[2]);
            television.Posicion = posicion;
            // Creamos las partes de la televisión
            Parte baseTelevision = new Parte(posicion[0], posicion[1], posicion[2]);
            Parte marcoTelevision = new Parte(posicion[0], posicion[1], posicion[2]);
            Parte pantallaTelevision = new Parte(posicion[0], posicion[1], posicion[2]);

            // Creamos las caras para la base del televisor
            Cara baseTrasera = new Cara(Base);
            baseTrasera.Posicion = posicion;
            baseTrasera.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f));
            baseTrasera.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f));
            baseTrasera.AgregarPunto(new Vector3(0.4f, -0.6f, -1.0f));
            baseTrasera.AgregarPunto(new Vector3(-0.4f, -0.6f, -1.0f));
            Cara baseFrontal = new Cara(Base);
            baseFrontal.Posicion = posicion;

            baseFrontal.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f));
            baseFrontal.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f));
            baseFrontal.AgregarPunto(new Vector3(0.4f, -0.6f, -0.8f));
            baseFrontal.AgregarPunto(new Vector3(-0.4f, -0.6f, -0.8f));

            Cara baseLadoIzquierdo = new Cara(Base);
            baseLadoIzquierdo.Posicion = posicion;
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f));
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f));
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.6f, -0.8f));
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.6f, -1.0f));

            Cara baseLadoDerecho = new Cara(Base);
            baseLadoDerecho.Posicion = posicion;

            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f));
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f));
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.6f, -0.8f));
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.6f, -1.0f));

            Cara baseTapaSuperior = new Cara(Base);
            baseTapaSuperior.Posicion = posicion;

            baseTapaSuperior.AgregarPunto(new Vector3(-0.4f, -0.7f, -1.0f));
            baseTapaSuperior.AgregarPunto(new Vector3(0.4f, -0.7f, -1.0f));
            baseTapaSuperior.AgregarPunto(new Vector3(0.4f, -0.7f, -0.8f));
            baseTapaSuperior.AgregarPunto(new Vector3(-0.4f, -0.7f, -0.8f));

            Cara baseTapaInferior = new Cara(Base);
            baseTapaInferior.Posicion = posicion;

            baseTapaInferior.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f));
            baseTapaInferior.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f));
            baseTapaInferior.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f));
            baseTapaInferior.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f));
            // Agregamos las caras a la parte de la base
            baseTelevision.AgregarCara("BaseTrasera", baseTrasera);
            baseTelevision.AgregarCara("BaseFrontal", baseFrontal);
            baseTelevision.AgregarCara("BaseLadoIzquierdo", baseLadoIzquierdo);
            baseTelevision.AgregarCara("BaseLadoDerecho", baseLadoDerecho);
            baseTelevision.AgregarCara("BaseTapaSuperior", baseTapaSuperior);
            baseTelevision.AgregarCara("BaseTapaInferior", baseTapaInferior);


            // Creamos las caras para el marco del televisor
            Cara marco = new Cara(marcoc);
            marco.Posicion = posicion;

            marco.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f));
            marco.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f));
            marco.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f));
            marco.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f));

            Cara marcoLadoIzquierdo = new Cara(marcoc);
            marcoLadoIzquierdo.Posicion = posicion;

            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f));
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, -0.6f, -0.8f));
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, 0.6f, -0.8f));
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f));

            Cara marcoLadoDerecho = new Cara(marcoc);
            marcoLadoDerecho.Posicion = posicion;
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f));
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, -0.6f, -0.8f));
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, 0.6f, -0.8f));
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f));

            Cara marcoTapaSuperior = new Cara(marcoc);
            marcoTapaSuperior.Posicion = posicion;

            marcoTapaSuperior.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f));
            marcoTapaSuperior.AgregarPunto(new Vector3(-1.0f, 0.6f, -0.8f));
            marcoTapaSuperior.AgregarPunto(new Vector3(1.0f, 0.6f, -0.8f));
            marcoTapaSuperior.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f));

            Cara marcoTapaInferior = new Cara(marcoc);
            marcoTapaInferior.Posicion = posicion;
            marcoTapaInferior.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f));
            marcoTapaInferior.AgregarPunto(new Vector3(-1.0f, -0.6f, -0.8f));
            marcoTapaInferior.AgregarPunto(new Vector3(1.0f, -0.6f, -0.8f));
            marcoTapaInferior.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f));

            marcoTelevision.AgregarCara("Marco", marco);
            marcoTelevision.AgregarCara("MarcoLadoIzquierdo", marcoLadoIzquierdo);
            marcoTelevision.AgregarCara("MarcoLadoDerecho", marcoLadoDerecho);
            marcoTelevision.AgregarCara("MarcoTapaSuperior", marcoTapaSuperior);
            marcoTelevision.AgregarCara("MarcoTapaInferior", marcoTapaInferior);

            Cara pantalla = new Cara(pantallac);
            pantalla.Posicion = posicion;
            pantalla.AgregarPunto(new Vector3(-0.8f, -0.4f, -0.81f));
            pantalla.AgregarPunto(new Vector3(0.8f, -0.4f, -0.81f));
            pantalla.AgregarPunto(new Vector3(0.8f, 0.4f, -0.81f));
            pantalla.AgregarPunto(new Vector3(-0.8f, 0.4f, -0.81f));
            // Agregamos la cara a la parte de la pantalla
            pantallaTelevision.AgregarCara("Pantalla", pantalla);

            // Agregamos las partes al objeto Television
            television.AgregarParte("PantallaTelevisor", pantallaTelevision);
            television.AgregarParte("Base", baseTelevision);
            television.AgregarParte("Marco", marcoTelevision);

            return television;
        }
        private Objeto CrearEquipoSonido(float[] posicion)
        {
            Objeto equipoSonido = new Objeto(posicion[0], posicion[1], posicion[2]);
            equipoSonido.Posicion = posicion;
            // Creamos las partes del Equipor de Sonido
            Parte altavoz = new Parte(posicion[0], posicion[1], posicion[2]);
            //altavoz.Posicion = posicion;
            Parte bocina = new Parte(posicion[0], posicion[1], posicion[2]);
            // Creamos las caras para el altavoz
            Cara altavozCaraTrasera = new Cara(Color.Black);
            altavozCaraTrasera.Posicion = posicion;
            altavozCaraTrasera.AgregarPunto(new Vector3(-1.6f + 0.6f, -0.9f, -0.7f));
            altavozCaraTrasera.AgregarPunto(new Vector3(-1.6f + 1.0f, -0.9f, -0.7f));
            altavozCaraTrasera.AgregarPunto(new Vector3(-1.6f + 1.0f, 0.1f, -0.7f));
            altavozCaraTrasera.AgregarPunto(new Vector3(-1.6f + 0.6f, 0.1f, -0.7f));

            Cara altavozCaraDelantera = new Cara(Color.Black);
            altavozCaraDelantera.Posicion = posicion;
            altavozCaraDelantera.AgregarPunto(new Vector3(-1.6f + 0.6f, -0.9f, -0.5f));
            altavozCaraDelantera.AgregarPunto(new Vector3(-1.6f + 1.0f, -0.9f, -0.5f));
            altavozCaraDelantera.AgregarPunto(new Vector3(-1.6f + 1.0f, 0.1f, -0.5f));
            altavozCaraDelantera.AgregarPunto(new Vector3(-1.6f + 0.6f, 0.1f, -0.5f));

            Cara altavozCaraLateralIzq = new Cara(Color.Black);
            altavozCaraLateralIzq.Posicion = posicion;
            altavozCaraLateralIzq.AgregarPunto(new Vector3(0.6f - 1.6f, -0.9f, -0.7f));
            altavozCaraLateralIzq.AgregarPunto(new Vector3(0.6f - 1.6f, -0.9f, -0.5f));
            altavozCaraLateralIzq.AgregarPunto(new Vector3(0.6f - 1.6f, 0.1f, -0.5f));
            altavozCaraLateralIzq.AgregarPunto(new Vector3(0.6f - 1.6f, 0.1f, -0.7f));

            Cara altavozCaraLateralDer = new Cara(Color.Black);
            altavozCaraLateralDer.Posicion = posicion;
            altavozCaraLateralDer.AgregarPunto(new Vector3(1.0f - 1.6f, -0.9f, -0.7f));
            altavozCaraLateralDer.AgregarPunto(new Vector3(1.0f - 1.6f, -0.9f, -0.5f));
            altavozCaraLateralDer.AgregarPunto(new Vector3(1.0f - 1.6f, 0.1f, -0.5f));
            altavozCaraLateralDer.AgregarPunto(new Vector3(1.0f - 1.6f, 0.1f, -0.7f));

            //Bocina es una sola Cara
            Cara bocinaTodo = new Cara(Color.DarkGray);
            bocinaTodo.Posicion = posicion;
            float radio = 0.16f;
            Vector3 centro = new Vector3(-1.6f + 0.8f, -0.3f, -0.49f);
            int numPuntos = 20;
            for (int i = 0; i < numPuntos; i++)
            {
                float angulo = (float)(i * 2 * Math.PI / numPuntos);
                float x = centro.X + radio * (float)Math.Cos(angulo);
                float y = centro.Y + radio * (float)Math.Sin(angulo);
                bocinaTodo.AgregarPunto(new Vector3(x, y, centro.Z));
            }

            bocina.AgregarCara("AltavozCaraTrasera", altavozCaraTrasera);
            bocina.AgregarCara("AltavozCaraDelantera", altavozCaraDelantera);
            bocina.AgregarCara("AltavozCaraLateralIzq", altavozCaraLateralIzq);
            bocina.AgregarCara("AltavozCaraLateralDer", altavozCaraLateralDer);

            altavoz.AgregarCara("Gris ", bocinaTodo);

            // Agregamos las partes al objeto Television
            equipoSonido.AgregarParte("Altavoz", altavoz);
            equipoSonido.AgregarParte("Bocina", bocina);

            return equipoSonido;
        }

        private Objeto CrearFlorero(float[] posicion)
        {
            Objeto florero = new Objeto(posicion[0], posicion[1], posicion[2]);
            florero.Posicion = posicion;
            // Creamos las partes de la televisión
            Parte baseFlorero = new Parte(posicion[0], posicion[1], posicion[2]);
            baseFlorero.Posicion = posicion;
            Parte talloFlorero = new Parte(posicion[0], posicion[1], posicion[2]);
            talloFlorero.Posicion = posicion;
            Parte petalosFlorero = new Parte(posicion[0], posicion[1], posicion[2]);
            petalosFlorero.Posicion = posicion;

            Cara baseFloreroDelantera = new Cara(Color.Green);
            baseFloreroDelantera.Posicion = posicion;
            baseFloreroDelantera.AgregarPunto(new Vector3(-0.3f, 0.9f, -0.9f));
            baseFloreroDelantera.AgregarPunto(new Vector3(0.3f, 0.9f, -0.9f));
            baseFloreroDelantera.AgregarPunto(new Vector3(0.3f, 0.6f, -0.9f));
            baseFloreroDelantera.AgregarPunto(new Vector3(-0.3f, 0.6f, -0.9f));

            // Creamos las caras para el tallo del florero
            Cara talloFrontal = new Cara(Color.Green);
            talloFrontal.Posicion = posicion;
            talloFrontal.AgregarPunto(new Vector3(-0.05f, 0.9f, -0.9f));
            talloFrontal.AgregarPunto(new Vector3(0.05f, 0.9f, -0.9f));
            talloFrontal.AgregarPunto(new Vector3(0.05f, 1.5f, -0.9f));
            talloFrontal.AgregarPunto(new Vector3(-0.05f, 1.5f, -0.9f));

            // Creamos los pétalos de la flor
            List<Cara> petalosFloreroHojas = new List<Cara>();

            for (int i = 0; i < 10; i++)
            {
                float angle = i * (float)Math.PI * 2 / 10;
                float x = (float)Math.Sin(angle) * 0.4f;
                float z = (float)Math.Cos(angle) * 0.4f;

                var petalo = new Cara(Color.Yellow);
                petalo.Posicion = posicion;
                petalo.AgregarPunto(new Vector3(0, 1.5f, -0.9f));
                petalo.AgregarPunto(new Vector3(x, 1.53f, -0.9f + z));
                petalo.AgregarPunto(new Vector3(0, 1.56f, -0.9f));
                petalosFloreroHojas.Add(petalo);
            }


            for (int i = 0; i < petalosFloreroHojas.Count; i++)
            {
                petalosFlorero.AgregarCara($"Petalo{i}", petalosFloreroHojas[i]);

            }
            baseFlorero.AgregarCara("BaseFlorero", baseFloreroDelantera);
            talloFlorero.AgregarCara("TalloFrontal", talloFrontal);

            florero.AgregarParte("BaseFlorero", baseFlorero);
            florero.AgregarParte("TalloFlorero", talloFlorero);
            florero.AgregarParte("PetalosFlorero", petalosFlorero);

            return florero;
        }
        private Objeto CrearEsfera()
        {
            Objeto esfera = new Objeto(1, 1, 1);

            // Creamos la esfera
            Parte cuerpoEsfera = new Parte(1, 1, 1);
            Cara caraEsfera = new Cara(Color.Blue); // Supongamos que queremos una esfera azul

            // Parámetros de la esfera
            int latitud = 20; // Cantidad de divisiones verticales
            int longitud = 20; // Cantidad de divisiones horizontales
            float radio = 1.0f; // Radio de la esfera

            // Generar puntos de la esfera
            for (int i = 0; i <= latitud; i++)
            {
                double phi = Math.PI / latitud * i;
                double cosPhi = Math.Cos(phi);
                double sinPhi = Math.Sin(phi);

                for (int j = 0; j <= longitud; j++)
                {
                    double theta = Math.PI * 2 / longitud * j;

                    float x = (float)(radio * Math.Cos(theta) * sinPhi);
                    float y = (float)(radio * cosPhi);
                    float z = (float)(radio * Math.Sin(theta) * sinPhi);

                    caraEsfera.AgregarPunto(new Vector3(x, y, z));
                }
            }

            cuerpoEsfera.AgregarCara("CaraEsfera", caraEsfera);

            esfera.AgregarParte("CuerpoEsfera", cuerpoEsfera);

            return esfera;
        }

    }
}
