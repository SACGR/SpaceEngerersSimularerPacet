using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceEngerersSimularer
{
    public  class FysikObjekt
    {
        Vector3 speed;
        Vector3 position;
        public float massa;
        public FysikObjekt(Vector3 uSpeed, Vector3 uPostinon,double uMassa)
        {
            speed = uSpeed;
            position = uPostinon;
            massa = (float)uMassa;
           


        }
        public Vector3 Updatterar(Vector3 ExternalForce) {
            //Räknar ut fartförendringen
            Vector3 speedChange = ExternalForce/massa;
        
            speed += speedChange;
            //clampar eftersom att maxfarten är 100

            if(speed.Length()>= 100)
                speed = 100*Vector3.Normalize(speed);

            


            position += speed;
        
        return position;
        }
    }
}
