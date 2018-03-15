using System;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            int weight = 42;
            bool isTypeA = true;
            float cost = 0;

            if (weight > 1000)
            {
                Console.WriteLine("This is a package");
                return;
            }
            
            if (isTypeA)
            {
                cost += 1.5F;
            }
            
            if (weight <= 50)
            {
                cost += 8F;
            }
            else if (weight <= 100)
            {
                cost += 12.5F;
            }
            else
            {
                cost += 35F;
            }

            Console.WriteLine($"This delivery will cost {cost}");
        }
    }
}
