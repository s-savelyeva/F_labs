using System;

namespace task2
{
    class Program
    {
        static void Main()
        {
            double x, y;
            InputChoiceHandler input = new InputChoiceHandler();
            input.InputChoice(out x, out y);

            Point point1 = new Point(x, y);
            Console.WriteLine($"Координаты точки: {point1.ToString()}");

            double distance = point1.Distance(x, y);
            Console.WriteLine($"Дистанция до точки = {distance}");
        }
    }
}
