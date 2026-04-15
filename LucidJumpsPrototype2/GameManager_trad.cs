using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucidJumpsPrototype2
{
    internal class GameManager
    { private static GameManager instance = new GameManager();
       // public static GameManager Instance;
      
        


        public static GameManager Instance {

            get
            { 
                if (instance==null)
                    {
                    instance = new GameManager();
                }

                return instance;
            
            }
        
        
        }

    

    }
}
