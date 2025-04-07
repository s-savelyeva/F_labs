using System;

namespace task2
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

        // Перегруженный метод ToString()
        public override string ToString()
        {
            return $"x: {x}, y: {y}";
        }

        // Метод, приводящий поля к целому типу (округляет до ближайшего целого)
        public double Distance(double x, double y)
        {
            double distance = Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2));
            return distance;
        }           

    }

    
}


