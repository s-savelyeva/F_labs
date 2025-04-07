using System;

namespace task3
{
    class Program
    {
        static void Main()
        {
            double x, y;
            InputChoiceHandler input = new InputChoiceHandler();
            input.InputChoice(out x, out y);

            Point point = new Point(x, y);
            Point savePoint = new Point(point);
            Console.WriteLine($"Координаты точки: {point.ToString()}");

            // Унарные операции
            Point pointDec = --point;
            Console.WriteLine($"Уменьшение x и y на 1: {pointDec}");

            point = savePoint;
            Point pointSwap = +point;
            Console.WriteLine($"Смена x и y местами: {pointSwap}");

            // Приведение типов
            point = savePoint;
            int intX = (int)point;
            Console.WriteLine($"Приведение к целому x: {intX}");

            point = savePoint;
            double doubleY = (double)point;
            Console.WriteLine($"Приведение к double y: {doubleY}");

            // Бинарные операции
            point = savePoint;
            int value = InputInt.InputIntCheck("Введите число = ");
            Point pointMinusIntLeft = point - value;
            Console.WriteLine($"Вычитание x: {pointMinusIntLeft}");

            point = savePoint;
            value = InputInt.InputIntCheck("Введите число = ");
            Point pointMinusIntRight = value - point;
            Console.WriteLine($"Вычитание y: {pointMinusIntRight}");

            point = savePoint;
            double distance = -point;
            Console.WriteLine($"Расстояние до точки: {distance}");

        }
    }
}
