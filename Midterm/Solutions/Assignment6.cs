using System;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            decimal total = 0;

            for (int i = 0; i < 8; i++)
            {
                Delivery delivery = new Delivery(rng.Next(1, 1100), rng.Next(0, 1) == 1);
                
                if (delivery.IsPackage())
                {
                    Console.WriteLine($"Delivery {i + 1} is a package");
                    continue;
                }

                decimal cost = delivery.GetCost();
                total += cost;
                
                Console.WriteLine($"Delivery {i + 1} will cost {cost}");
            }

            Console.WriteLine($"In total: {total}");
        }
    }

    class Delivery
    {
        private readonly int _weight;
        private readonly bool _isTypeA;

        public Delivery(int weight, bool isTypeA)
        {
            _weight = weight;
            _isTypeA = isTypeA;
        }

        public decimal GetCost()
        {
            decimal cost = 0;
            
            if (_isTypeA)
            {
                cost += 1.5m;
            }
            
            if (_weight <= 50)
            {
                cost += 8m;
            }
            else if (_weight <= 100)
            {
                cost += 12.5m;
            }
            else
            {
                cost += 35m;
            }

            return cost;
        }

        public bool IsPackage()
        {
            return _weight > 1000;
        }
    }
}