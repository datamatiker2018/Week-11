using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(i * 7);
            }

            for (int i = 0; i < 40; i += 4)
            {
                Console.WriteLine(i);
            }

            for (int i = 8000000; i >= 8; i /= 10)
            {
                Console.WriteLine(i);
            }
        }
    }
}