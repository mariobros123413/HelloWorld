using System.Drawing;
using OpenTK;

namespace HelloWorld
{
    internal class Television : Objeto
    {

        public Television(float x, float y, float z)
        {
            // Base de la televisión cara trasera
            var baseTrasera = new Puntos(new[]
            {
                new Vector3(-0.4f+x, -0.9f+ y, -1.0f+z),
                new Vector3(0.4f+x, -0.9f+ y, -1.0f+z),
                new Vector3(0.4f+x, -0.6f+ y, -1.0f+z),
                new Vector3(-0.4f+x, -0.6f+ y, -1.0f+z)
                });
            var caraBaseTrasera = new Cara(baseTrasera, Color.BlueViolet);
            AgregarCara(caraBaseTrasera);

            // Base de la televisión cara frontal
            var baseFrontal = new Puntos(new[]
            {
                new Vector3(-0.4f+x, -0.9f+ y, -0.8f+z),
                new Vector3(0.4f+x, -0.9f+y, -0.8f+z),
                new Vector3(0.4f+x, -0.6f+y, -0.8f+z),
                new Vector3(-0.4f+x, -0.6f+ y, -0.8f+z)
                });
            var caraBaseFrontal = new Cara(baseFrontal, Color.BlueViolet);
            AgregarCara(caraBaseFrontal);

            // Lado izquierdo de la base
            var baseLadoIzquierdo = new Puntos(new[]
                        {
                new Vector3(-0.4f+x, -0.9f+y, -1.0f+z),
                new Vector3(-0.4f+x, -0.9f+y, -0.8f+z),
                new Vector3(-0.4f+x, -0.6f+y, -0.8f+z),
                new Vector3(-0.4f+x, -0.6f+y , -1.0f+z)
                });
            var caraBaseLadoIzquierdo = new Cara(baseLadoIzquierdo, Color.BlueViolet);
            AgregarCara(caraBaseLadoIzquierdo);

            // Lado derecho de la base
            var baseLadoDerecho = new Puntos(new[]
                                    {
                new Vector3(0.4f+x, -0.9f+y, -1.0f+z),
                new Vector3(0.4f+x, -0.9f+y, -0.8f+z),
                new Vector3(0.4f+x, -0.6f+y, -0.8f+z),
                new Vector3(0.4f+x, -0.6f+y , -1.0f+z)
                });
            var caraBaseLadoDerecho = new Cara(baseLadoDerecho, Color.BlueViolet);
            AgregarCara(caraBaseLadoDerecho);

            //Tapa Superior de la base
            var baseTapaSuperior = new Puntos(new[]
                                    {
                new Vector3(-0.4f+x, -0.7f+y, -1.0f+z),
                new Vector3(0.4f+x, -0.7f+y, -1.0f+z),
                new Vector3(0.4f+x, -0.7f+y, -0.8f+z),
                new Vector3(-0.4f+x, -0.7f+y, -0.8f+z)
                });
            var caraBaseTapaSuperior = new Cara(baseTapaSuperior, Color.BlueViolet);
            AgregarCara(caraBaseTapaSuperior);

            //Tapa Inferior de la base
            var baseTapaInferior = new Puntos(new[]
                                    {
                new Vector3(-0.4f+x, -0.9f+y, -1.0f+z),
                new Vector3(0.4f+x, -0.9f+y, -1.0f+z),
                new Vector3(0.4f+x, -0.9f+ y, -0.8f+z),
                new Vector3(-0.4f+x, -0.9f+y, -0.8f+z)
                });
            var caraBaseTapaInferior = new Cara(baseTapaInferior, Color.BlueViolet);
            AgregarCara(caraBaseTapaInferior);

            //////////////////

            // Marco de la televisión
            var marco = new Puntos(new[]
            {
                new Vector3(-1.0f+x, -0.6f+y, -1.0f+z),
                new Vector3(1.0f+x, -0.6f+y, -1.0f+z),
                new Vector3(1.0f+x, 0.6f+y, -1.0f+z),
                new Vector3(-1.0f+x, 0.6f+y, -1.0f+z)
            });
            var caraMarco = new Cara(marco, Color.CadetBlue);
            AgregarCara(caraMarco);

            // Lado izquierdo del Marco
            var marcoLadoIzquierdo = new Puntos(new[]
            {
                new Vector3(-1.0f+x, -0.6f+ y, -1.0f+z),
                new Vector3(-1.0f+x, -0.6f+y, -0.8f+z),
                new Vector3(-1.0f+x, 0.6f+y, -0.8f+z),
                new Vector3(-1.0f+x, 0.6f+y, -1.0f+z)
            });
            var caraMarcoLadoIzquierdo = new Cara(marcoLadoIzquierdo, Color.CadetBlue);
            AgregarCara(caraMarcoLadoIzquierdo);

            // Lado derecho del Marco
            var marcoLadoDerecho = new Puntos(new[]
            {
                new Vector3(1.0f+x, -0.6f+y, -1.0f+z),
                new Vector3(1.0f+x, -0.6f+y, -0.8f+z),
                new Vector3(1.0f+x, 0.6f+y, -0.8f+z),
                new Vector3(1.0f+x, 0.6f+y, -1.0f+z)
            });
            var caraMarcoLadoDerecho = new Cara(marcoLadoDerecho, Color.CadetBlue);
            AgregarCara(caraMarcoLadoDerecho);

            //Tapa Superior del Marco
            var marcoTapaSuperior = new Puntos(new[]
            {
                new Vector3(-1.0f+x, 0.6f+y, -1.0f+z),
                new Vector3(-1.0f+x, 0.6f+y, -0.8f+z),
                new Vector3(1.0f+x, 0.6f+y, -0.8f+z),
                new Vector3(1.0f+x, 0.6f+y, -1.0f+z)
            });
            var caraMarcoTapaSuperior = new Cara(marcoTapaSuperior, Color.CadetBlue);
            AgregarCara(caraMarcoTapaSuperior);

            //Tapa Inferior del Marco
            var marcoTapaInferior = new Puntos(new[]
            {
                new Vector3(-1.0f+x, -0.6f+y, -1.0f+z),
                new Vector3(-1.0f+x, -0.6f+y, -0.8f+z),
                new Vector3(1.0f+x, -0.6f+y, -0.8f+z),
                new Vector3(1.0f+x, -0.6f+y, -1.0f+z)
            });
            var caraMarcoTapaInferior = new Cara(marcoTapaInferior, Color.CadetBlue);
            AgregarCara(caraMarcoTapaInferior);

            // Pantalla frontal
            var pantalla = new Puntos(new[]
            {
                new Vector3(-0.8f+x, -0.4f+y, -0.81f+z),
                new Vector3(0.8f+x, -0.4f+y, -0.81f+z),
                new Vector3(0.8f+x, 0.4f+y, -0.81f+z),
                new Vector3(-0.8f+x, 0.4f+y, -0.81f+z)
            });
            var caraPantalla = new Cara(pantalla, Color.DarkOrange);
            AgregarCara(caraPantalla);
        }
    }
}