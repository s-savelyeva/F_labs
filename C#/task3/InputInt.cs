using System;

namespace task3
{
    class InputInt
    {
        static public int InputIntCheck(string message)
        {
            bool validInput;
            int result;
            do
            {
                Console.WriteLine(message);
                validInput = int.TryParse(Console.ReadLine(), out result);

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
