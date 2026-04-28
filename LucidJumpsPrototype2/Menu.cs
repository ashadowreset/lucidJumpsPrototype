using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using EngineGDI;

namespace LucidJumpsPrototype2
{
    public class Menu
    {



        public void Update()
        {


            // for (int i = 0; i < scene_object.Count; i++) { }




        }


        public void Input()
        {


            if (Engine.IsKeyDown(Keys.Space))
            {
                GameManager.Instance.ChangeLevel("LevelScreen");
            }





        }

        public void Draw() {
        
            EngineGDI.Engine.Draw("menu.png", 0, 0);

        }




    }
}
