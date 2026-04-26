using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EngineGDI
{
    internal class Platforms
    {


        private float x;
        private float y;
        private float width;
        private float height;

        public Platforms(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public float CenterX
        {
            get { return x + width / 2; }
        }

        public float CenterY
        {
            get { return y + height / 2; }
        }

        public void Draw()
        {
            Engine.Draw("Platform.png", x, y, width / 100f, height / 100f);
        }

    }
}
