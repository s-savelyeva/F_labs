using System;

namespace task1
{
    class InputBox
    {
        public void InputBoxCheck(out string material, out bool hasLid)
        {
            Console.WriteLine("Введите материал ящика = ");
            material = Console.ReadLine();

            Console.WriteLine("Введите true - если есть крышка ящика, false - если крышки нет: ");
            while (!bool.TryParse(Console.ReadLine(), out hasLid))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите true или false.");
            }
        }
    }
}