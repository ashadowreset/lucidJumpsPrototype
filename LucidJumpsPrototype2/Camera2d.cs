using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LucidJumpsPrototype2
{
    /*public class Camera2d
    {
    // EL SETTER NO LE GUSTA CREO
        public Vector2 FocusPosition { get, set; };
        public float Zoom  {get, set; }; ;
      
        public Camera2d(Vector2 focusPosition, float zoom)
        {
            this.FocusPosition = focusPosition;
            this.Zoom = zoom;   


        }


        public Matrix4x4 GetProjectMatrix() {
    
            float left = FocusPosition.X - Program.screenWidth/ 2;
            float right = FocusPosition.X + Program.screenWidth / 2;
            float top = FocusPosition.Y - Program.screenHeight / 2;
            float bottom = FocusPosition.Y + Program.screenHeight / 2;



            Matrix4x4 Ortomatrix = Matrix4x4.CreateOrthographicOffCenter(left, right, bottom, top, 0.01f, 100f);
            Matrix4x4 zoomMatrix = Matrix4x4.CreateScale(Zoom);
            return (Ortomatrix*zoomMatrix);
        }


    }*/
}
