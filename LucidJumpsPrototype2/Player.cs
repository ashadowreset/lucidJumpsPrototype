using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EngineGDI;



namespace LucidJumpsPrototype2
{
    public class Player
    {
        public Transform Transform => transform;
        private Transform transform;

        private string sprite;
        public string Sprite => sprite;
        Animation idle;
        Animation currentAnimation= null ;
        Animation run; 
    

        private static float jumpForce = 70f;
        private static float gravity = 800f;
        private static bool isJumping = false;
        private static float velY = 20f;
        private float FallingPos = 0f;
        private float speed = 200f;

        Vector2 pos;
        private bool isGrounded { get; set; } = false;
        //public bool IsGrounded => isGrounded;



        public Player(string sprite, float posx, float posy, float scx, float scy, float rot)
        {
            // run = CreateAnimation("Run", "Textures/Animations/" ,8, 2, true, 95, 101);
            //cambiar path a los de cada animación, Run DEBE tener un path distinto
            // idle = CreateAnimation("Idle", "Textures/Animations/", 8, 2, true, 95, 101);
            this.sprite = sprite;
            transform = new Transform(posx, posy, scx, scy, rot);

            //  currentAnimation = idle; 
            //   currentAnimation.Reset();

        }

        private void Gravity()
        {
            if (!isGrounded)
            {
                velY += gravity * Program.deltaTime;
                var pos = transform.Position;
                pos.Y += velY * Program.deltaTime;
                transform.Position = pos;
            }
            else
            {
                velY = 0f;
            }
        }


        //VOLVER A HABILITAR AL PONER LAS ANIMACIONES!!

        /* public Player(float posx, float posy, float scx, float scy, float rot, string sprite)
         {
            // run = CreateAnimation("Run", "Textures/Animations/" ,8, 2, true, 95, 101);
             //cambiar path a los de cada animación, Run DEBE tener un path distinto
            // idle = CreateAnimation("Idle", "Textures/Animations/", 8, 2, true, 95, 101);
             //this.sprite = "Pollo.png";
             transform = new Transform(posx, posy, scx, scy, rot);

           //  currentAnimation = idle; 
          //   currentAnimation.Reset();

         }*/

        public float GetWidth() { 
            return currentAnimation.Width*currentAnimation.ScaleX;
        }

        public float GetHeight()
        {
            return currentAnimation.Height * currentAnimation.ScaleY;
        }

        public void input()
        {
            if (Engine.IsKeyDown(Keys.Space))
            {

                 pos = transform.Position;
                pos.Y -= jumpForce; 
                transform.Position = pos;
            }

            if (Engine.IsKeyDown(Keys.Space) && isGrounded)
            {
                isJumping = true;
                velY = -jumpForce;
                isGrounded = false;
               }

            if (Engine.IsKeyDown(Keys.A))
            {
                pos = transform.Position;
                pos.X -= speed * Program.deltaTime;
                transform.Position = pos;
            }
            if (Engine.IsKeyDown(Keys.D))
            {
                pos = transform.Position;
                    pos.X += speed * Program.deltaTime;
                transform.Position = pos;

            }

        }

        public void update()
        {
           

           /* currentAnimation.Update();
           
            }*/
        }
        public void Draw()
        { Engine.Draw(sprite, transform.Position.X, transform.Position.Y, transform.Scale.Y, transform.Scale.Y, transform.Rotation);

            // Engine.Draw(currentAnimation.Currentframe, transform.Position.X, transform.Position.Y, transform.Scale.Y, transform.Scale.Y, transform.Rotation);
        }

        private Animation CreateAnimation(string id, string path, int amount, float speed, bool isLooped, float w, float h) { 
            List <string> images = new List <string>();

            for (int i = 1; i < amount; i++ ) { 
                images.Add($"{path}{i}.png");
            }

            Animation animation = new Animation(id, images, speed, isLooped);

            return animation;
        }

      public void GravitySetter(int i)
        {
            if (i==1)
            {
                isGrounded = true;
                gravity = 0f;
                isJumping = false;
                velY = 0f;
            }
            else
            {
                gravity = 800f;
                isJumping = true;
            }



        }
       

        

    }
}
