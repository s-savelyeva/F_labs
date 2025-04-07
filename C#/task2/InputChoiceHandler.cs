using System;

namespace task2
{
    class InputChoiceHandler
    {
        private Rand generator = new Rand();

        public void InputChoice(out double x, out double y)
        {
            Console.WriteLine("Выберите метод ввода x и y:");
            Console.WriteLine("1) Ввести с клавиатуры.");
            Console.WriteLine("2) Ввести случайным способом.");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            }

            if (choice == 1)
            {
                x = InputDataWithCheck.InputDoubleCheck("Введите x = ");
                y = InputDataWithCheck.InputDoubleCheck("Введите y = ");
            }
            else
            {
                x = generator.GenerateRandomDouble();
                y = generator.GenerateRandomDouble();
                Console.WriteLine($"\nСгенерированные значения: x = {x}, y = {y}");
            }
        }
    }
}
