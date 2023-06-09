using System;

namespace Activity3pt2
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNumber = 6;
            Console.Out.WriteLine(factorial(startingNumber));
            Console.ReadLine();

        }
        static int factorial(int x)
        {
            Console.WriteLine("x is {0}", x);
            if(x == 1)
            {
                return 1;
            }
            else
            {
                return x * factorial(x - 1);
            }
        }
    }
}
