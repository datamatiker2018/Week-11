using System;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            decimal total = 0;

            for (int i = 0; i < 8; i++)
            {
                int weight = rng.Next(1, 1100);
                bool isTypeA = rng.Next(0, 1) == 1;
                decimal cost = 0;

                if (weight > 1000)
                {
                    Console.WriteLine($"Delivery {i + 1} is a package");
                    continue;
                }
            
                if (isTypeA)
                {
                    cost += 1.5m;
                }
            
                if (weight <= 50)
                {
                    cost += 8m;
                }
                else if (weight <= 100)
                {
                    cost += 12.5m;
                }
                else
                {
                    cost += 35m;
                }

                total += cost;

                Console.WriteLine($"Delivery {i + 1} will cost {cost}");
            }

            Console.WriteLine($"In total: {total}");
        }
    }
}