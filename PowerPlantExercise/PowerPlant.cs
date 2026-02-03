using System;
using System.Collections.Generic;
using System.Text;

namespace PowerPlantEntity
{
    internal class PowerPlant
    {
        public PowerPlant(){ }

        public Warning Warning { get; set; }

        public void HeadUp()
        {
            Random randomInteger = new Random();
            int increaseInTemperature = randomInteger.Next(0, 101);
            if (increaseInTemperature > 50)
            {
                Warning();
            }
        }


    }

    internal delegate void Warning();

}
