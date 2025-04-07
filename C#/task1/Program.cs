using System;

namespace task1
{
    class Program
    {
        static void Main()
        {
            double length, width, height;
            string material;
            bool hasLid;
            InputChoiceHandler input = new InputChoiceHandler();
            input.InputChoice(out length, out width, out height);

            Box box1 = new Box(length, width, height);
            Console.WriteLine("\nЗначения: ");
            Console.WriteLine(box1.ToString());

            //Приведение к целому
            Console.WriteLine("\nПриведение к целым числам: ");
            box1.ConvertToInteger();
            Console.WriteLine(box1.ToString());

            //Тестирование конструктора копирования
            Console.WriteLine("\nКопия базового класса: ");
            Box box2 = new Box(box1);
            Console.WriteLine(box2.ToString());

            // Тестирование дочернего класса MaterialBox
            Console.WriteLine("\nTesting MaterialBox:");
            input.InputChoice(out length, out width, out height);
            InputBox inputBox = new InputBox();
            inputBox.InputBoxCheck(out material, out hasLid);
            MaterialBox MaterialBox1 = new MaterialBox(length, width, height, material, hasLid);
            Console.WriteLine($"MaterialBox1: {MaterialBox1}"); // Использование ToString()
            
            Console.WriteLine($"Внешняя площадь MaterialBox1: {MaterialBox1.OuterSquare()}");

            Console.WriteLine("Введите материал ящика = ");
            material = Console.ReadLine();
            MaterialBox1.ChangeMaterial(material);
            Console.WriteLine($"MaterialBox1 после ChangeMaterial: {MaterialBox1}");

            MaterialBox MaterialBox2 = new MaterialBox(MaterialBox1); // Конструктор копирования
            Console.WriteLine($"Копия дочернего класса: {MaterialBox2}");

        }
    }
}
