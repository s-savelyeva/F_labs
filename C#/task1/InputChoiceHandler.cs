using System;

namespace task1
{
    class InputChoiceHandler
    {
        private Rand generator = new Rand();

        public void InputChoice(out double length, out double width, out double height)
        {
            Console.WriteLine("Выберите метод ввода длины, ширины и высоты:");
            Console.WriteLine("1) Ввести с клавиатуры.");
            Console.WriteLine("2) Ввести случайным способом.");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            }

            if (choice == 1)
            {
                length = InputDataWithCheck.InputDoubleCheck("Введите длину: ");
                width = InputDataWithCheck.InputDoubleCheck("Введите ширину: ");
                height = InputDataWithCheck.InputDoubleCheck("Введите высоту: ");
            }
            else
            {
                length = generator.GenerateRandomDouble();
                width = generator.GenerateRandomDouble();
                height = generator.GenerateRandomDouble();
                Console.WriteLine($"\nСгенерированные значения: length = {length}, width = {width}, height = {height}");
            }
        }
    }
}
