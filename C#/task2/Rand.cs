using System;

namespace task2
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