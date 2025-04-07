using System;

namespace task1
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