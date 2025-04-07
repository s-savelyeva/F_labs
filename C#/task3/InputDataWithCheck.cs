using System;

namespace task3
{
    class InputDataWithCheck
    {
        static public double InputDoubleCheck(string message)
        {
            bool validInput;
            double result;
            do
            {
                Console.WriteLine(message);
                validInput = Double.TryParse(Console.ReadLine(), out result);

                if (!validInput)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
                }
            }
            while (!validInput);
            return result;
        }
    }
}
