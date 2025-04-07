using System;

namespace task3
{
    class Rand
    {
        private Random random = new Random();

        public double GenerateRandomDouble()
        {
            return random.NextDouble() * 100;
        }
    }
}