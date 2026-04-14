using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineGDI;



namespace LucidJumpsPrototype2
{
    internal class Player
    {
        public Transform Transform => transform;
        private Transform transform;

        private string sprite;
        public string Sprite => sprite;
        Animation idle;
        Animation currentAnimation= null ;
        Animation run; 


        public Player(float posx, float posy, float scx, float scy, float rot)
        {
           run = CreateAnimation("Run", "Textures/Animations/" 8, 2, true, 95, 101)
                //cambiar path a los de cada animación, Run DEBE tener un path distinto
           idle = CreateAnimation("Idle", "Textures/Animations/" 8, 2, true, 95, 101)
            this.sprite = "Pollo.png";
            transform = new Transform(posx, posy, scx, scy, rot);

            currentAnimation = idle; 
            currentAnimation.Reset();

        }

        public float GetWidth() { 
        return currentAnimation.Width*currentAnimation.scaleX;
        
        }
        
        public character(float posx,float posy,float scx,float scy,float rot, string sprite);
        {



        }


        public void input()
        {
            if (Engine.IsKeyDown(Keys.Space))
            {
 
                transform.position.Y += jumpForce * (-1); //Pongo "*(-1)" para que el salto vaya hacia arriba
            }
        }

        public void update()
        {
            currentAnimation.Update();
        }
        public void Draw()
        {
            
            Engine.Draw(currentAnimation.Currentframe, transform.position.X, transform.position.Y, transform.scale.y, transform.scale.y, transform.rotation);

        }




        private Animation CreateAnimation(string id, string path, int amount, float speed, bool isLooped, float w, float h) { 
        
            List <string> images = new List <string>();

            for (int i = 1; i < amount; i++; ) { 
            
            images.Add($"{path}{i}.png");
            
            }




                Animation animation = new Animation(id, images, speed, isLooped);

            return animation;
        }


    }


}
