using System;
using System.Collections.Generic;
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
            /*position = new Vector2(0, 0);
            scale = new Vector2(1, 1);
            rotation = 0;*/

            position.X = posx;
            position.Y = posy;  
            scale.X = scx;
            scale.Y = scy;
            rotation = rot;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            


                


        }


    }
}
