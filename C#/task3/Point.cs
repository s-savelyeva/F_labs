using System;

namespace task3
{
    //базовый класс
    class Point
    {
        // Поля
        private double x;
        private double y;

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }

        // Конструктор с параметрами
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Конструктор копирования
        public Point(Point other)
        {
            x = other.x;
            y = other.y;
        }

        // Перегруженный метод ToString()
        public override string ToString()
        {
            return $"x: {x}, y: {y}";
        }

        // Унарный оператор -- (уменьшить координаты x и y на 1)
        public static Point operator --(Point p)
        {
            return new Point(p.X - 1, p.Y - 1);
        } 

        // Унарный оператор - (поменять координаты x и y местами)
        public static Point operator +(Point p)
        {
            return new Point(p.Y, p.X);
        }

        // Неявное приведение типа к int (возвращает целую часть координаты x)
        public static implicit operator int(Point p)
        {
            return (int)p.X;
        }

        // Явное приведение типа к double (возвращает координату y)
        public static explicit operator double(Point p)
        {
            return p.Y;
        }

        // Бинарный оператор - уменьшается координата x
        public static Point operator -(Point p, int value)
        {
            return new Point(p.X - value, p.Y);
        }

        // Бинарный оператор - (int value, Point p) - уменьшается координата y
        public static Point operator -(int value, Point p)
        {
            return new Point(p.X, p.Y - value);
        }

        // Бинарный оператор - (Point p) - вычисляется расстояние между точками p и p1
        public static double operator -(Point p)
        {
            return Math.Sqrt(Math.Pow(p.X, 2) + Math.Pow(p.Y, 2));
        }

    }
    
}


