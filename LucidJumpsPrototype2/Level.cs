using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace LucidJumpsPrototype2
{
    public class Level
    {
        public static List<Platform> scene_object = new List<Platform>();


        private float offsetX = 0f;
        private float offsetY = 0f;
        private string BgName = "";
        private Player player;
        private Platform platform;
        private Goal goal;
        Random rnd = new Random();
        private int lastPlatformX;
        private int lastPlatformY;

        public Level() 
        {

              player = new Player ("Clippy_placeholder.png",0, 740, 0.2f, 0.2f, 0);
             platform = new Platform("platform_Placeholder.png",0, 760, 0.2f, 0.2f, 0);
            lastPlatformX = 0;
            lastPlatformY = 760;
            // scene_object.Add(player);
             scene_object.Add(platform);


            for (int i = 0; i < 4; i++) {

                int direct = rnd.Next(0,2);
                if (direct == 0 && lastPlatformX>300) {
                    platform = new Platform("platform_Placeholder.png", rnd.Next( lastPlatformX-300, lastPlatformX-100), (lastPlatformY-150), 0.2f, 0.2f, 0);
                    scene_object.Add(platform);
                    lastPlatformX = (int)platform.Transform.Position.X;
                    lastPlatformY = (int)platform.Transform.Position.Y;
                }
                else
                {
                    platform = new Platform("platform_Placeholder.png", rnd.Next(lastPlatformX+200, lastPlatformX + 300), (lastPlatformY - 150), 0.2f, 0.2f, 0);
                    scene_object.Add(platform);
                    lastPlatformX = (int)platform.Transform.Position.X;
                    lastPlatformY = (int)platform.Transform.Position.Y;
                }
               
            }
            goal = new Goal("Goal_Placeholder.png", lastPlatformX, lastPlatformY-400, 0.2f, 0.2f, 0);


            // Platform platform = InstantiatePlatform();
            //Player player = InstantiateCharacter();


        }

      /*  private Player InstantiateCharacter() {

           player = new Player(0, 770, 3, 3, 0, "Clippy_placeholder");

            scene_object.Add(player);
         
        return player;

        }

        private Platform InstantiatePlatform()
        {

            platform = new Platform(0, 790, 3, 3, 0, "platform_Placeholder");

            scene_object.Add(platform);

            return platform;

        }
      */

        public void Update() {


            for (int i = 0; i < scene_object.Count; i++) {

                scene_object[i].update();

            }
                         player.update();
                        // platform.update();
            goal.update();  

            for (int i = 0; i < scene_object.Count; i++)
            {
                if (IsBoxColliding(player.Transform.Position, new Vector2(player.GetWidth(), player.GetHeight()), scene_object[i].Transform.Position, new Vector2(scene_object[i].GetWidth(), scene_object[i].GetHeight())) == true)
                {
                    if (scene_object[i].Transform.Position.X>  player.Transform.Position.X)
                    {  
                        player.GravitySetter(1);

                        //HandleCollision(i);
                    }
                }
            }


        }


        private void HandleCollision(int i)
        {
            

        }

        public void Input() {

            player.input();
        
        
        
        
        
        
        }

        public void Draw() {
            EngineGDI.Engine.Draw("BgLvl1_Placeholder.png", 0, 0);
          // platform.Draw();
            player.Draw();


            for (int i = 0; i < scene_object.Count; i++)
            {

                scene_object[i].Draw();

            }

            goal.Draw();


        }


          static public bool IsBoxColliding(Vector2 positionA, Vector2 sizeA, Vector2 positionB, Vector2 sizeB)
       {

             float distanceX = Math.Abs(positionA.X - positionB.X);
             float distanceY = Math.Abs(positionA.Y - positionB.Y);


             float sumHalfWidths = (sizeA.X / 2 + sizeB.X / 2);
             float sumHalfHeight = (sizeA.Y / 2 + sizeB.Y / 2);

             return distanceX <= sumHalfWidths && distanceY <= sumHalfHeight;

         }

        static public bool IsCircleColliding(Vector2 positionA, float radiusA, Vector2 positionB, float radiusB)
        {

            float distanceX = positionA.X - positionB.X;
            float distanceY = positionA.Y - positionB.Y;

            float totalDistance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);


            return totalDistance < radiusA + radiusB;

        }




       /* static public int IsBoxColliding(Vector2 positionA, Vector2 sizeA, Vector2 positionB, Vector2 sizeB)
        {

            float distanceX = Math.Abs(positionA.X - positionB.X);
            float distanceY = Math.Abs(positionA.Y - positionB.Y);


            float sumHalfWidths = (sizeA.X / 2 + sizeB.X / 2);
            float sumHalfHeight = (sizeA.Y / 2 + sizeB.Y / 2);

            if (distanceX! <= sumHalfWidths || distanceY! <= sumHalfHeight)
            {
                return 0;

            }

            else if (sizeA.X > sizeB.X)
            {

                return 1;
            }
            else
            {
                return 2;
            }


        }
       */
    }
}
