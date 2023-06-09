using System;
using System.Collections.Generic;
using System.Text;

namespace Activity2Animal
{
    class Dog : Animal,IDomesticated
    {
        public Dog()
        {
            Console.WriteLine("Dog Constructor Good Puppy!");
        }
        public void Talk()
        {
            Console.WriteLine("BARK!");
        }
        public virtual void Sing()
        {
            Console.WriteLine("Awoooooooooooo!");
        }
        public void Fetch(String thing)
        {
            Console.WriteLine("Oh boy. Here is your " + thing + ". Lets do it again!");
        }

        public void TouchMe()
        {
            Console.WriteLine("Please Rub My belly");
        }

        public void FeedMe()
        {
            Console.WriteLine("Food? Food?! FOOD!!!!");
        }
    }
}
