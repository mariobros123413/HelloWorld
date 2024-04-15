using System.Drawing;
using OpenTK;

namespace HelloWorld
{
    public class Television : Objeto
    {
        private Cara baseTrasera;
        private Cara baseFrontal;
        private Cara baseLadoIzquierdo;
        private Cara baseLadoDerecho;
        private Cara baseTapaSuperior;
        private Cara baseTapaInferior;
        private Cara marco;
        private Cara marcoLadoIzquierdo;
        private Cara marcoLadoDerecho;
        private Cara marcoTapaSuperior;
        private Cara marcoTapaInferior;
        private Cara pantalla;

        public Television(Vector3 posicion) : base(posicion)
        {
            CrearTelevision();
        }

        private void CrearTelevision()
        {
            // Creamos las caras para la base del televisor
            baseTrasera = new Cara();
            baseTrasera.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f), Color.BlueViolet);
            baseTrasera.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f), Color.BlueViolet);
            baseTrasera.AgregarPunto(new Vector3(0.4f, -0.6f, -1.0f), Color.BlueViolet);
            baseTrasera.AgregarPunto(new Vector3(-0.4f, -0.6f, -1.0f), Color.BlueViolet);

            baseFrontal = new Cara();
            baseFrontal.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f), Color.BlueViolet);
            baseFrontal.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f), Color.BlueViolet);
            baseFrontal.AgregarPunto(new Vector3(0.4f, -0.6f, -0.8f), Color.BlueViolet);
            baseFrontal.AgregarPunto(new Vector3(-0.4f, -0.6f, -0.8f), Color.BlueViolet);

            baseLadoIzquierdo = new Cara();
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f), Color.BlueViolet);
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f), Color.BlueViolet);
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.6f, -0.8f), Color.BlueViolet);
            baseLadoIzquierdo.AgregarPunto(new Vector3(-0.4f, -0.6f, -1.0f), Color.BlueViolet);

            baseLadoDerecho = new Cara();
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f), Color.BlueViolet);
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f), Color.BlueViolet);
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.6f, -0.8f), Color.BlueViolet);
            baseLadoDerecho.AgregarPunto(new Vector3(0.4f, -0.6f, -1.0f), Color.BlueViolet);

            baseTapaSuperior = new Cara();
            baseTapaSuperior.AgregarPunto(new Vector3(-0.4f, -0.7f, -1.0f), Color.BlueViolet);
            baseTapaSuperior.AgregarPunto(new Vector3(0.4f, -0.7f, -1.0f), Color.BlueViolet);
            baseTapaSuperior.AgregarPunto(new Vector3(0.4f, -0.7f, -0.8f), Color.BlueViolet);
            baseTapaSuperior.AgregarPunto(new Vector3(-0.4f, -0.7f, -0.8f), Color.BlueViolet);

            baseTapaInferior = new Cara();
            baseTapaInferior.AgregarPunto(new Vector3(-0.4f, -0.9f, -1.0f), Color.BlueViolet);
            baseTapaInferior.AgregarPunto(new Vector3(0.4f, -0.9f, -1.0f), Color.BlueViolet);
            baseTapaInferior.AgregarPunto(new Vector3(0.4f, -0.9f, -0.8f), Color.BlueViolet);
            baseTapaInferior.AgregarPunto(new Vector3(-0.4f, -0.9f, -0.8f), Color.BlueViolet);

            // Creamos las caras para el marco del televisor
            marco = new Cara();
            marco.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f), Color.CadetBlue);
            marco.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f), Color.CadetBlue);
            marco.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f), Color.CadetBlue);
            marco.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f), Color.CadetBlue);

            marcoLadoIzquierdo = new Cara();
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f), Color.CadetBlue);
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, -0.6f, -0.8f), Color.CadetBlue);
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, 0.6f, -0.8f), Color.CadetBlue);
            marcoLadoIzquierdo.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f), Color.CadetBlue);

            marcoLadoDerecho = new Cara();
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f), Color.CadetBlue);
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, -0.6f, -0.8f), Color.CadetBlue);
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, 0.6f, -0.8f), Color.CadetBlue);
            marcoLadoDerecho.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f), Color.CadetBlue);

            marcoTapaSuperior = new Cara();
            marcoTapaSuperior.AgregarPunto(new Vector3(-1.0f, 0.6f, -1.0f), Color.CadetBlue);
            marcoTapaSuperior.AgregarPunto(new Vector3(-1.0f, 0.6f, -0.8f), Color.CadetBlue);
            marcoTapaSuperior.AgregarPunto(new Vector3(1.0f, 0.6f, -0.8f), Color.CadetBlue);
            marcoTapaSuperior.AgregarPunto(new Vector3(1.0f, 0.6f, -1.0f), Color.CadetBlue);

            marcoTapaInferior = new Cara();
            marcoTapaInferior.AgregarPunto(new Vector3(-1.0f, -0.6f, -1.0f), Color.CadetBlue);
            marcoTapaInferior.AgregarPunto(new Vector3(-1.0f, -0.6f, -0.8f), Color.CadetBlue);
            marcoTapaInferior.AgregarPunto(new Vector3(1.0f, -0.6f, -0.8f), Color.CadetBlue);
            marcoTapaInferior.AgregarPunto(new Vector3(1.0f, -0.6f, -1.0f), Color.CadetBlue);

            // Creamos las caras para la pantalla del televisor
            pantalla = new Cara();
            pantalla.AgregarPunto(new Vector3(-0.8f, -0.4f, -0.81f), Color.DarkOrange);
            pantalla.AgregarPunto(new Vector3(0.8f, -0.4f, -0.81f), Color.DarkOrange);
            pantalla.AgregarPunto(new Vector3(0.8f, 0.4f, -0.81f), Color.DarkOrange);
            pantalla.AgregarPunto(new Vector3(-0.8f, 0.4f, -0.81f), Color.DarkOrange);

            // Agregar las caras al objeto Television
            AgregarCara("BaseTrasera", baseTrasera);
            AgregarCara("BaseFrontal", baseFrontal);
            AgregarCara("BaseLadoIzquierdo", baseLadoIzquierdo);
            AgregarCara("BaseLadoDerecho", baseLadoDerecho);
            AgregarCara("BaseTapaSuperior", baseTapaSuperior);
            AgregarCara("BaseTapaInferior", baseTapaInferior);
            AgregarCara("Marco", marco);
            AgregarCara("MarcoLadoIzquierdo", marcoLadoIzquierdo);
            AgregarCara("MarcoLadoDerecho", marcoLadoDerecho);
            AgregarCara("MarcoTapaSuperior", marcoTapaSuperior);
            AgregarCara("MarcoTapaInferior", marcoTapaInferior);
            AgregarCara("Pantalla", pantalla);
        }
    }

}