using System;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Check(5000))
            {
                Console.WriteLine("Criteria met");
            }
            else
            {
                Console.WriteLine("Criteria not met");
            }
        }

        static bool Check(int n)
        {
            return n < 10000 && n > 0;
        }
    }
}