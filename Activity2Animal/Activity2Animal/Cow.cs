using System;
using System.Collections.Generic;
using System.Text;

namespace Activity2Animal
{
    class Cow : Animal, IMilkable
    {
        public void Milk()
        {
            Console.WriteLine("Anyone for some frest milk?");
        }
        public void Greet()
        {
            Console.WriteLine("Moooo!");
        }
    }
}
