using EngineGDI;
using System;
using System.Drawing;
using System.Media;
using System.Numerics;
using System.Security.Policy;
using System.Windows.Forms;

namespace LucidJumpsPrototype2
{
    class Program
    {
      //  public static Player player = new Player(0, 630, 1, 1, 0);
        public static bool showDebug = true;
        public static string currentMsg = "";

        public static Vector2 playerPosition = new Vector2(0, 0);


        public static float jumpForce = 20;
        public static float gravity = 10;


        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        public static int screenWidth = 1024;
        public static int screenHeight = 780;
        public static List<object> scene_object = new List<object>();




        [STAThread]
        static void Main()
        {
            //En lugar de utilizar variables 
            Engine.Initialize("IERVA ENGINE", screenWidth, screenHeight, false);
            GameManager.Instance.ChangeLevel("MenuScreen");
            // scene_object.Add(player);
            // Player1 = new Player(100, 100, 1, 1, 0, "Pollo.png");
            //Enemy = new Player();
            while (Engine.IsWindowOpen)
            {
                #region Engine Window Control
                Engine.UpdateWindow();
                #endregion

                calcDeltatime();
                input();
                update();
                Draw();


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






            static void Draw()
        {
                GameManager.Instance.Draw();
        }
       
        static void update()
        {
            for (int i = 0; i < scene_object.Count; i++)
            {
                var obj = scene_object[i] as Player;
                obj?.update();
            }


            // player.update();
           // PlayerColision();
        }


        static void input()
        {

            GameManager.Instance.Input();
        }

        

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }


        }


    }
}