using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucidJumpsPrototype2
{
    public class Animation
    {
        private string id;
        private bool isLoopEnabled;
        private List<string> frames;
        private float speed =20;
        private float currentAnimationTIme= 0;
        private int currentFrameIndex= 0;
        private float width = 0.0f;
        private float height = 0.0f; 
        private float scaleX = 1.0f;
        private float scaleY = 1.0f;

        public string Id => id;

        public string Currentframe => frames[currentFrameIndex];

        public float Width => width;
        public float Height => height;  
        public float ScaleX => scaleX;
        public float ScaleY => scaleY;


        public Animation(string id, List<string> frames, float speed, bool isLoopEnabled) {

            this.id = id;
            this.frames = frames;
            this.speed = speed;
            this.isLoopEnabled = isLoopEnabled;
        }


        public void Reset ()
        {
            this.currentFrameIndex = 0;
            this.currentAnimationTIme = 0;

        }
        public void Update() {

            currentAnimationTIme += Program.deltaTime;
            if (currentAnimationTIme >= speed)
            {
                currentFrameIndex ++;



            }


        }




    }
}
