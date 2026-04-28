using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucidJumpsPrototype2
{
    public class Transform
    { //Agregar Getter y Setter
        private Vector2 position;
        private Vector2 scale;
        private float rotation;

        public Transform(float posx, float posy, float scx, float scy, float rot)
        {
             position = new Vector2(posx, posy);
             scale = new Vector2(scx, scy);
             rotation = rot;
        }

        // Public properties to access and mutate transform data
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        public Vector2 Scale
        {
            get => scale;
            set => scale = value;
        }

        public float Rotation
        {
            get => rotation;
            set => rotation = value;
        }

        
        public float PositionX
        {
            get => position.X;
            set => position.X = value;
        }

        public float PositionY
        {
            get => position.Y;
            set => position.Y = value;
        }

        public float ScaleX
        {
            get => scale.X;
            set => scale.X = value;
        }

        public float ScaleY
        {
            get => scale.Y;
            set => scale.Y = value;
        }
    }
}
