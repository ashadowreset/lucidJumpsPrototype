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
        public static Player player = new Player(0, 630, 1, 1, 0);
        public static bool showDebug = true;
        public static string currentMsg = "";

        public static Vector2 playerPosition = new Vector2(0,0);


        public static float jumpForce = 20;
        public static float gravity = 10;


        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        public static int screenWidth = 1024;
        public static int screenHeight = 780;
        public static List<object> scene_object = new List<object>();  
        
        
       

        
        static void Draw()
        {
            Engine.Draw("Fondo.png", 0, 0);
            player.Draw();
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
            for (int i = 0; i < scene_object.Count; i++)
            {
                var obj = scene_object[i] as Player;
                obj?.update();
            }


            // player.update();
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
                player.input();
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

       static public bool IsBoxColliding(Vector2 positionA, Vector2 sizeA, Vector2 positionB, Vector2 sizeB)
        {

            float distanceX = Math.Abs(positionA.X - positionB.X);
            float distanceY = Math.Abs(positionA.Y - positionB.Y);


            float sumHalfWidths = sizeA.X / 2 + size B.X / 2);
            float sumHalfHeight = sizeA.Y / 2 + size B.Y / 2);

            return distanceX <= sumHalfWidths && distanceY <= sumHalfHeight;

        }

       static  public bool IsCircleColliding(Vector2 positionA, float radiusA, Vector2 positionB, float radiusB)
        {

            float distanceX = positionA.X - positionB.X;
            float distanceY = positionA.Y - positionB.Y;

            float totalDistance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);


            return totalDistance < radiusA + radiusB;

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
            scene_object.Add(player);
            Player1= new Player (100,100,1, 1, 0, "Pollo.png");
            Enemy= new Player ()
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
        }
        

}