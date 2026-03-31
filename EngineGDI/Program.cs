
using System;
using System.Drawing;
using System.Windows.Forms;


namespace EngineGDI
{
    static class Program
    {
        // mostrar debug
        public static bool showDebug = true;
        public static string currentMsg = "";

        //Posicion Player
        public static float polloX = 0;
        public static float polloY = 500;
        public static float polloJumpX = 0;
        public static float polloJumpY = 0;
        public static float gravity = 0;
        public static float deltaTime;

        static DateTime lastFrameTime = DateTime.Now;

        //Tamaño del juego
        public static int SCREEN_WIDTH = 1024;
        public static int SCREEN_HEIGHT = 780;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Engine.Initialize("IERVA ENGINE", SCREEN_WIDTH, SCREEN_HEIGHT, false);

         

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

        static void draw()
        {
            Engine.Draw("Fondo.png", 0, 0);
            Engine.Draw("Pollo.png", polloX, polloY, 0.1f, 0.1f);
        }

       static void update()
       {
            
          polloY = polloY + gravity;
          if (polloY >= 630)
            {
                gravity = 0;
            }
          else
            {
                gravity = 1;
            }
          if (polloX > 1000)
            {
                polloX = 0;
            }
            
       }

        static void input()
        {
            if (Engine.IsKeyDown(Keys.W))
            {
                polloY = polloY - 5;
            }
            if (Engine.IsKeyDown(Keys.D))
            {
                polloX = polloX + 0.8f;
                    
            }
            if ((Engine.IsKeyDown(Keys.A)))
            {
                polloX = polloX - 0.8f;
            }
            while ((Engine.IsKeyDown(Keys.Space) && (polloJumpX < 100)))
            {
                polloJumpX = polloJumpX + 20;
                polloJumpY = polloJumpY + 100;
            }
            if (((Engine.IsKeyDown(Keys.S))))
            {
                polloX = polloX + polloJumpX;
                polloY = polloY - polloJumpY;
                polloJumpY = 0;
                polloJumpX = 0;
            }
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }
    }
}
