using System;

namespace task1
{ 
    // Дочерний класс: MaterialBox - представляет собой ящик из определенного материала
    // Содержательный смысл: Расширяет Box, добавляя информацию о материале, толщине стенок и наличие крышки.
    class MaterialBox : Box
    {
        // Поле: material - материал, из которого сделан ящик
        private string material;

        // Поле: hasLid - наличие крышки
        private bool hasLid;

        // Конструктор с параметрами (включая длину, ширину, высоту, материал, толщину)
        public MaterialBox(double length, double width, double height, string material, bool hasLid): base(length, width, height)
        {
            this.material = material;
            this.hasLid = hasLid;
        }

        // Конструктор копирования
        public MaterialBox(MaterialBox other) : base(other)
        {
            material = other.material;
            hasLid = other.hasLid;
        }

        // Метод для вычисления внешней площади поверхности дерева
        public double OuterSquare()
        {
            double length = Length;
            double width = Width;
            double height = Height;

            double outerSquare = 2 * (length * width + length * height + width * height);
            if(!hasLid)
            {
                outerSquare -= length * width;
            }
            return outerSquare;
        }

        // Метод для изменения материала
        public void ChangeMaterial(string newmaterial)
        {
            material = newmaterial;
        }

        //Перегрузка метода ToString()
        public override string ToString()
        {
            return $"{base.ToString()}, material: {material}, hasLid: {hasLid}";
        }
    }
}