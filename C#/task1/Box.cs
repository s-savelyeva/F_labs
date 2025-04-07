using System;

namespace task1
{
    //базовый класс
    class Box
    {
        // Поля (длина, ширина и высота)
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get { return length; }
        }

        public double Width
        {
            get { return width; }
        }

        public double Height
        {
            get { return height; }
        }

        // Конструктор с параметрами
        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        // Конструктор копирования
        public Box(Box other)
        {
            length = other.length;
            width = other.width;
            height = other.height;
        }

        // Перегруженный метод ToString()
        public override string ToString()
        {
            return $"length: {length}, width: {width}, height: {height}";
        }

        // Метод, приводящий поля к целому типу (округляет до ближайшего целого)
        public void ConvertToInteger()
        {
            length = Math.Round(length);
            width = Math.Round(width);
            height = Math.Round(height);
        }           

    }

    
}


