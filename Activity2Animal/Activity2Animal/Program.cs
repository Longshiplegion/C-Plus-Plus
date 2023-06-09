using System;

namespace Activity2Animal
{
    class Program
    {
        static void Main(string[] args)
        {
           // Animal Beast = new Animal();
            //Beast.Talk();
            //Beast.Greet();
            //Beast.Sing();

            Dog Lilly = new Dog();

            Lilly.Greet();
            Lilly.Talk();
            Lilly.Sing();
            Lilly.Fetch("Stick");
            Lilly.FeedMe();
            Lilly.TouchMe();

            Robin Red = new Robin();

            Red.Greet();
            Red.Talk();
            Red.Talk();
            //Red.Fetch("Worm");
            //Red.FeedMe();
            //Red.TouchMe();
            Camel Fred = new Camel();
            Fred.Greet();
            Fred.Ride();
            Fred.Sing();
            Fred.Talk();
            Cow Clarabell = new Cow();
            Clarabell.Talk();
            Clarabell.Milk();
            Clarabell.Greet();
            Clarabell.Sing();
            Fish Nemo = new Fish();
            Nemo.Talk();
            Nemo.Greet();
            Nemo.Sing();
            Console.ReadLine();


        }
    }
}
