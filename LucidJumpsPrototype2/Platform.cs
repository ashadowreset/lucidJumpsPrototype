using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using EngineGDI;

namespace LucidJumpsPrototype2
{
    public class Platform
    {


        public Transform Transform => transform;
        private Transform transform;

        private string sprite;
        public string Sprite => sprite;
        Animation idle;
        Animation currentAnimation = null;
        Animation run;
        private float jumpForce = 10.0f;


        public Platform ( string sprite, float posx, float posy, float scx, float scy, float rot)
        {
           
            this.sprite = sprite ;
            transform = new Transform(posx, posy, scx, scy, rot);

            
        }

        public float GetWidth()
        {
            return currentAnimation.Width * currentAnimation.ScaleX;
        }

        public float GetHeight()
        {
            return currentAnimation.Height * currentAnimation.ScaleY;
        }

        public void input()
        {
            
        }

        public void update()
        {
           // currentAnimation.Update();
        }
        public void Draw()
        {
            Engine.Draw( sprite, transform.Position.X, transform.Position.Y, transform.Scale.Y, transform.Scale.Y, transform.Rotation);
            Debug.WriteLine($"Drawing platform at position: {transform.Position.X}, {transform.Position.Y}");
            // Engine.Draw(currentAnimation.Currentframe, transform.Position.X, transform.Position.Y, transform.Scale.Y, transform.Scale.Y, transform.Rotation);
        }

        private Animation CreateAnimation(string id, string path, int amount, float speed, bool isLooped, float w, float h)
        {
            List<string> images = new List<string>();

            for (int i = 1; i < amount; i++)
            {
                images.Add($"{path}{i}.png");
            }

            Animation animation = new Animation(id, images, speed, isLooped);

            return animation;
        }
    }


}

