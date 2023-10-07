using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Espressor
{
    public  class Boiler
    {
        public float watherLevel; //maximum 3 l
        private Indicator indicator = new Indicator();

        public Boiler()
        {
            float min = 0f;
            float max = 3000f;
            Random random = new Random();
            float watherLevel = (float)(min + (random.NextDouble() * (max - min)));
        }
        public bool checkLevelWather()
        {
            if (watherLevel > 0.5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AddWather(float watherML)
        {
            if (watherML + watherLevel <= 3)
                watherLevel += watherML;
            else
            {
                Console.WriteLine("E prea multa apa.");
                indicator.color = "RED";
            }
        }
    }
}
