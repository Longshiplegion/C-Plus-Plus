using System;

namespace Activity3pt1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Please enter an integer. I will do some math and eventually arrive at 1.");
            int startingNumber = int.Parse(Console.ReadLine());
            int x = countToOne(startingNumber);
        }

        static public int countToOne(int n)
        {
            Console.WriteLine("N is {0}", n);
            if(n == 1)
            {
                return 1;
            }

            else
            {
                if(n % 2 == 0)
                {
                    Console.WriteLine("N is even. Divide by 2");
                    return countToOne(n / 2);

                }
                else
                {
                    Console.WriteLine("N is odd. Add 1");
                    return countToOne(n + 1);
                }
            }
        }
    }
}
