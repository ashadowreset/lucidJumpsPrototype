using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucidJumpsPrototype2
{
    public class Camera
    {
        private float bgSizeX;
        private float bgSizeY;
        private float offsetX;
        private float offsetY;

        public Vector2 OffsetClaculation(float BgSizeX, float BgSizeY) {

            offsetX = BgSizeX - Program.screenWidth;
            offsetY = BgSizeY - Program.screenHeight;

            return new Vector2(offsetX, offsetY);
        }


        public float offsetMoveLeft() {
            offsetX--;

            return offsetX;
        }

        public float offsetMoveRight()
        {
            offsetX++;

            return offsetX;
        }
        public float offsetMoveUp ()
        {
            offsetY--;

            return offsetY;
        }

        public float offsetMoveDown()
        {
            offsetX++;

            return offsetY;
        }

        public Vector2 FetchCurrentOffSet => new Vector2(offsetX, offsetY);
    }
}
