using System;
using System.Collections.Generic;
using System.Text;

namespace Activity2Animal
{
    class Camel : Animal, IRidable
    {
        public void Ride()
        {
            Console.WriteLine("Lets go for a ride!");
        }
        public void Talk()
        {
            Console.WriteLine("Rrrr");
        }
    }
}
