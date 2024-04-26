using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace HelloWorld
{
    internal class Game : GameWindow
    {
        private float angle = 0.0f;
        //private List<Escenario> list = new List<Escenario>();   
        private List<Escenario> listaEscenarios = new List<Escenario>();

        public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Multiple TVs")
        {
            Escenario escenario = new Escenario();
            escenario.Posicion = new Vector3(1, 1, 1);

            Objeto Television1 = CrearTelevision(new Vector3(0, 0, 0));
            escenario.AgregarObjeto("Television", Television1);
            Objeto Television2 = CrearTelevision(new Vector3(3, 0, 0));
            escenario.AgregarObjeto("Television2", Television2);
            Objeto Television3 = CrearTelevision(new Vector3(3, 2, 3));
            escenario.AgregarObjeto("Television3", Television3);
            Objeto Bocina1 = CrearEquipoSonido(new Vector3(0, 0, 0));
            escenario.AgregarObjeto("Bocina1", Bocina1);
            Objeto CrearFlorero1 = CrearFlorero(new Vector3(0, 0, 0));
            escenario.AgregarObjeto("CrearFlorero1", CrearFlorero1);
            listaEscenarios.Add(escenario);

            // Serializar el escenario a un archivo JSON
//
            Escenario escenario2 = new Escenario();
            escenario2.Posicion = new Vector3(-3, 0, 0);

            Objeto Television4 = CrearTelevision2(new Vector3(0, 0, 0));
            escenario2.AgregarObjeto("Television4", Television4);
            Objeto Television5 = CrearTelevision2(new Vector3(3, 3, 0));
            escenario2.AgregarObjeto("Television5", Television5);
            Objeto Television6 = CrearTelevision2(new Vector3(3, 2, 3));
            escenario2.AgregarObjeto("Television6", Television6);
            Objeto CrearFlorero2 = CrearFlorero(new Vector3(3, 2, 3));
            escenario2.AgregarObjeto("CrearFlorero2", CrearFlorero2);
            listaEscenarios.Add(escenario2);
            SerializarEscenario(@".\..\..\..\..\escenario.json", listaEscenarios);
            //listaEscenarios = DeserializarEscenario(@".\..\..\..\..\escenario.json");

            Load += Game_Load;
            RenderFrame += Game_RenderFrame;
            UpdateFrame += Game_UpdateFrame;
            Closing += Game_Closing;
        }
        private List<Escenario>DeserializarEscenario(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Escenario>>(json);
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
        private void SerializarEscenario(string nombreArchivo, List<Escenario> escenarios)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None // Cambio aquí
            };

            string json = JsonConvert.SerializeObject(escenarios, settings);
            File.WriteAllText(nombreArchivo, json);
        }




        private Objeto CrearTelevision(Vector3 posicion)
        {
            Objeto television = new Objeto(posicion);

            // Creamos las partes de la televisión
            Parte baseTelevision = new Parte(posicion);
            Parte marcoTelevision = new Parte(posicion);
            Parte pantallaTelevision = new Parte(posicion);

            // Creamos las caras para la base del televisor
            Cara baseTrasera = new Cara(television.Posicion, Color.BlueViolet);
            baseTrasera.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f));
            baseTrasera.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f));
            baseTrasera.AgregarPunto(new Vector3(0.4f, -0.6f, -1.0f));
            baseTrasera.AgregarPunto(new Vector3(-0.4f, -0.6f, -1.0f));
            Cara baseFrontal = new Cara(television.Posicion, Color.BlueViolet);
            baseFrontal.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f));
            baseFrontal.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f));
            baseFrontal.AgregarPunto(new Vector3(0.4f, -0.6f, -0.8f));
            baseFrontal.AgregarPunto(new Vector3(-0.4f, -0.6f, -0.8f));

            Cara baseLadoIzquierdo = new Cara(television.Posicion, Color.BlueViolet);
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f));
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f));
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.6f, -0.8f));
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.6f, -1.0f));

            Cara baseLadoDerecho = new Cara(television.Posicion, Color.BlueViolet);

            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f));
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f));
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.6f, -0.8f));
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.6f, -1.0f));

            Cara baseTapaSuperior = new Cara(television.Posicion, Color.BlueViolet);
            baseTapaSuperior.AgregarPunto(new Vector3(-0.4f, -0.7f, -1.0f));
            baseTapaSuperior.AgregarPunto(new Vector3(0.4f, -0.7f, -1.0f));
            baseTapaSuperior.AgregarPunto(new Vector3(0.4f, -0.7f, -0.8f));
            baseTapaSuperior.AgregarPunto(new Vector3(-0.4f, -0.7f, -0.8f));

            Cara baseTapaInferior = new Cara(television.Posicion, Color.BlueViolet);
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
            Cara marco = new Cara(television.Posicion, Color.CadetBlue);
            marco.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f));
            marco.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f));
            marco.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f));
            marco.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f));

            Cara marcoLadoIzquierdo = new Cara(television.Posicion, Color.CadetBlue);
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f));
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, -0.6f, -0.8f));
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, 0.6f, -0.8f));
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f));

            Cara marcoLadoDerecho = new Cara(television.Posicion, Color.CadetBlue);
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f));
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, -0.6f, -0.8f));
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, 0.6f, -0.8f));
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f));

            Cara marcoTapaSuperior = new Cara(television.Posicion, Color.CadetBlue);
            marcoTapaSuperior.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f));
            marcoTapaSuperior.AgregarPunto(new Vector3(-1.0f, 0.6f, -0.8f));
            marcoTapaSuperior.AgregarPunto(new Vector3(1.0f, 0.6f, -0.8f));
            marcoTapaSuperior.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f));

            Cara marcoTapaInferior = new Cara(television.Posicion, Color.CadetBlue);
            marcoTapaInferior.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f));
            marcoTapaInferior.AgregarPunto(new Vector3(-1.0f, -0.6f, -0.8f));
            marcoTapaInferior.AgregarPunto(new Vector3(1.0f, -0.6f, -0.8f));
            marcoTapaInferior.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f));

            baseTelevision.AgregarCara("Marco", marco);
            baseTelevision.AgregarCara("MarcoLadoIzquierdo", marcoLadoIzquierdo);
            baseTelevision.AgregarCara("MarcoLadoDerecho", marcoLadoDerecho);
            baseTelevision.AgregarCara("MarcoTapaSuperior", marcoTapaSuperior);
            baseTelevision.AgregarCara("MarcoTapaInferior", marcoTapaInferior);

            Cara pantalla = new Cara(television.Posicion, Color.DarkOrange);
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

        private Objeto CrearTelevision2(Vector3 posicion)
        {
            Objeto television = new Objeto(posicion);

            // Creamos las partes de la televisión
            Parte baseTelevision = new Parte(posicion);
            Parte marcoTelevision = new Parte(posicion);
            Parte pantallaTelevision = new Parte(posicion);

            // Creamos las caras para la base del televisor
            Cara baseTrasera = new Cara(television.Posicion, Color.Magenta);
            baseTrasera.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f));
            baseTrasera.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f));
            baseTrasera.AgregarPunto(new Vector3(0.4f, -0.6f, -1.0f));
            baseTrasera.AgregarPunto(new Vector3(-0.4f, -0.6f, -1.0f));
            Cara baseFrontal = new Cara(television.Posicion, Color.Magenta);
            baseFrontal.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f));
            baseFrontal.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f));
            baseFrontal.AgregarPunto(new Vector3(0.4f, -0.6f, -0.8f));
            baseFrontal.AgregarPunto(new Vector3(-0.4f, -0.6f, -0.8f));

            Cara baseLadoIzquierdo = new Cara(television.Posicion, Color.Magenta);
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f));
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f));
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.6f, -0.8f));
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.6f, -1.0f));

            Cara baseLadoDerecho = new Cara(television.Posicion, Color.Magenta);

            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f));
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f));
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.6f, -0.8f));
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.6f, -1.0f));

            Cara baseTapaSuperior = new Cara(television.Posicion, Color.Magenta);
            baseTapaSuperior.AgregarPunto(new Vector3(-0.4f, -0.7f, -1.0f));
            baseTapaSuperior.AgregarPunto(new Vector3(0.4f, -0.7f, -1.0f));
            baseTapaSuperior.AgregarPunto(new Vector3(0.4f, -0.7f, -0.8f));
            baseTapaSuperior.AgregarPunto(new Vector3(-0.4f, -0.7f, -0.8f));

            Cara baseTapaInferior = new Cara(television.Posicion, Color.Magenta);
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
            Cara marco = new Cara(television.Posicion, Color.LightYellow);
            marco.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f));
            marco.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f));
            marco.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f));
            marco.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f));

            Cara marcoLadoIzquierdo = new Cara(television.Posicion, Color.LightYellow);
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f));
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, -0.6f, -0.8f));
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, 0.6f, -0.8f));
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f));

            Cara marcoLadoDerecho = new Cara(television.Posicion, Color.LightYellow);
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f));
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, -0.6f, -0.8f));
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, 0.6f, -0.8f));
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f));

            Cara marcoTapaSuperior = new Cara(television.Posicion, Color.LightYellow);
            marcoTapaSuperior.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f));
            marcoTapaSuperior.AgregarPunto(new Vector3(-1.0f, 0.6f, -0.8f));
            marcoTapaSuperior.AgregarPunto(new Vector3(1.0f, 0.6f, -0.8f));
            marcoTapaSuperior.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f));

            Cara marcoTapaInferior = new Cara(television.Posicion, Color.LightYellow);
            marcoTapaInferior.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f));
            marcoTapaInferior.AgregarPunto(new Vector3(-1.0f, -0.6f, -0.8f));
            marcoTapaInferior.AgregarPunto(new Vector3(1.0f, -0.6f, -0.8f));
            marcoTapaInferior.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f));

            baseTelevision.AgregarCara("Marco", marco);
            baseTelevision.AgregarCara("MarcoLadoIzquierdo", marcoLadoIzquierdo);
            baseTelevision.AgregarCara("MarcoLadoDerecho", marcoLadoDerecho);
            baseTelevision.AgregarCara("MarcoTapaSuperior", marcoTapaSuperior);
            baseTelevision.AgregarCara("MarcoTapaInferior", marcoTapaInferior);

            Cara pantalla = new Cara(television.Posicion, Color.DarkOrange);
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

        private Objeto CrearEquipoSonido(Vector3 posicion)
        {
            Objeto equipoSonido = new Objeto(posicion);

            // Creamos las partes del Equipor de Sonido
            Parte altavoz = new Parte(posicion);
            Parte bocina = new Parte(posicion);

            // Creamos las caras para el altavoz
            Cara altavozCaraTrasera = new Cara(equipoSonido.Posicion, Color.Black);
            altavozCaraTrasera.AgregarPunto(new Vector3(-1.6f + 0.6f, -0.9f, -0.7f));
            altavozCaraTrasera.AgregarPunto(new Vector3(-1.6f + 1.0f, -0.9f, -0.7f));
            altavozCaraTrasera.AgregarPunto(new Vector3(-1.6f + 1.0f, 0.1f, -0.7f));
            altavozCaraTrasera.AgregarPunto(new Vector3(-1.6f + 0.6f, 0.1f, -0.7f));

            Cara altavozCaraDelantera = new Cara(equipoSonido.Posicion, Color.Black);
            altavozCaraDelantera.AgregarPunto(new Vector3(-1.6f + 0.6f, -0.9f, -0.5f));
            altavozCaraDelantera.AgregarPunto(new Vector3(-1.6f + 1.0f, -0.9f, -0.5f));
            altavozCaraDelantera.AgregarPunto(new Vector3(-1.6f + 1.0f, 0.1f, -0.5f));
            altavozCaraDelantera.AgregarPunto(new Vector3(-1.6f + 0.6f, 0.1f, -0.5f));

            Cara altavozCaraLateralIzq = new Cara(equipoSonido.Posicion, Color.Black);
            altavozCaraLateralIzq.AgregarPunto(new Vector3(0.6f - 1.6f, -0.9f, -0.7f));
            altavozCaraLateralIzq.AgregarPunto(new Vector3(0.6f - 1.6f, -0.9f, -0.5f));
            altavozCaraLateralIzq.AgregarPunto(new Vector3(0.6f - 1.6f, 0.1f, -0.5f));
            altavozCaraLateralIzq.AgregarPunto(new Vector3(0.6f - 1.6f, 0.1f, -0.7f));

            Cara altavozCaraLateralDer = new Cara(equipoSonido.Posicion, Color.Black);
            altavozCaraLateralDer.AgregarPunto(new Vector3(1.0f - 1.6f, -0.9f, -0.7f));
            altavozCaraLateralDer.AgregarPunto(new Vector3(1.0f - 1.6f, -0.9f, -0.5f));
            altavozCaraLateralDer.AgregarPunto(new Vector3(1.0f - 1.6f, 0.1f, -0.5f));
            altavozCaraLateralDer.AgregarPunto(new Vector3(1.0f - 1.6f, 0.1f, -0.7f));

            //Bocina es una sola Cara
            Cara bocinaTodo = new Cara(equipoSonido.Posicion, Color.DarkGray);
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
            bocina.AgregarCara("BocinaTodo", bocinaTodo);


            // Agregamos las partes al objeto Television
            equipoSonido.AgregarParte("Altavoz", altavoz);
            equipoSonido.AgregarParte("Bocina", bocina);

            return equipoSonido;
        }

        private Objeto CrearFlorero(Vector3 posicion)
        {
            Objeto florero = new Objeto(posicion);

            // Creamos las partes de la televisión
            Parte baseFlorero = new Parte(posicion);
            Parte talloFlorero = new Parte(posicion);
            Parte petalosFlorero = new Parte(posicion);

            Cara baseFloreroDelantera = new Cara(florero.Posicion, Color.Green);
            baseFloreroDelantera.AgregarPunto(new Vector3(-0.3f, 0.9f, -0.9f));
            baseFloreroDelantera.AgregarPunto(new Vector3(0.3f, 0.9f, -0.9f));
            baseFloreroDelantera.AgregarPunto(new Vector3(0.3f, 0.6f, -0.9f));
            baseFloreroDelantera.AgregarPunto(new Vector3(-0.3f, 0.6f, -0.9f));

            // Creamos las caras para el tallo del florero
            Cara talloFrontal = new Cara(florero.Posicion, Color.Green);
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

                var petalo = new Cara(florero.Posicion, Color.Yellow);
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
    }
}
