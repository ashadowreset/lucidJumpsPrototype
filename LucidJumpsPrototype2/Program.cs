using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using EngineGDI;

namespace LucidJumpsPrototype2
{
    class Program
    {
        //mostrar debug

        //Por que las variables y las funciones son static? no se si es importante y en IDE me saltan varios errores por eso
        //Los puse como comentarios para que no afecten al codigo, cualquier cosa se saca el comentario

        public static bool showDebug = true;
        public static string currentMsg = "";

        
        //Posicion Jugador
        /*
         * Cambio: En lugar de una variable polloX y otra polloY
         * lo cambio a vector y de ahi se puede tomar
         */
        public static Vector2 playerPosition = new Vector2(0,0);

        //Mecanica de Salto
        /*
         * Cambio: lo mismo para el salto utilizo una variable salto
         * que multiplica da igual el eje
         */

        public static float jumpForce = 20;
        public static float gravity = 10;

        //DeltaTime
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        public static int screenWidth = 1024;
        public static int screenHeight = 780;

        /*
         * Cambio: primero pongo las funciones que llama main y luego
         * al final del todo coloco la funcion main. Para que, cuando
         * llame a las otras funciones, estas ya estan definidas arriba
         * mi profe de programacion dice que es una buena practica.
         */

        
        static void draw()
        {            
            Engine.Draw("Fondo.png", 0, 0);
            Engine.Draw("Pollo.png", playerPosition.X, playerPosition.Y, 0.1f, 0.1f);
        }
        
        static void PlayerColision()
        {
            playerPosition.Y += gravity;

            /*
            Aca cambie un poco la logica
            En lugar de que "Cuando colisione la gravedad se vuelve 0"
            Lo cambie a "Si colisiona de mantiene en esa posicion y la gravedad la mantengo
            */

            //Colision Eje Y
            if (playerPosition.Y >= 630)
            {
                playerPosition.Y = 630;
            }            

            //Colision Eje X
            if (playerPosition.X < 0)
            {
                playerPosition.X = 0;
            }
            else if (playerPosition.X > 1000)
            {
                playerPosition.X = 1000;
            }
        }
        static void update()
        {
            PlayerColision();
        }

        
        static void input()
        {
            /*No entiendo este If, supuestamente la unica forma de subir es saltando no?
            
            if (Engine.IsKeyDown(Keys.W))
            {
                playerPosition.Y -= 5;
            }

            No seria asi?
            */

            if(Engine.IsKeyDown(Keys.Space))
            {
                playerPosition.Y += jumpForce * (-1); //Pongo "*(-1)" para que el salto vaya hacia arriba
            }

            //Movimiento Horizonal
            if (Engine.IsKeyDown(Keys.D))
            {
                playerPosition.X += 0.8f;

            }
            if ((Engine.IsKeyDown(Keys.A)))
            {
                playerPosition.X -= 0.8f;
            }            
            
        }        

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }

        
        [STAThread]
        static void Main()
        {
            //En lugar de utilizar variables 
            Engine.Initialize("IERVA ENGINE", screenWidth, screenHeight, false);



            while (Engine.IsWindowOpen)
            {
                #region Engine Window Control
                Engine.UpdateWindow();
                #endregion

                calcDeltatime();
                input();
                update();
                draw();


                #region Engine Window Control
                Engine.Clear(Color.Black);
                // mensajes de debug
                if (showDebug)
                {
                    Engine.ClearDebug();
                    Engine.DebugLog(currentMsg);

                }
                Engine.Window.Invalidate();
                #endregion
            }
        }
        

    }
}