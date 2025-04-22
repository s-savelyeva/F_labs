namespace tasks
{

    public class FirstFive
    {
        public static double sumMinMax(StreamReader file)
        {
            double min, max;
            double element;
            min = double.Parse(file.ReadLine());
            max = min;
            while (!file.EndOfStream)
            {
                element = double.Parse(file.ReadLine());
                if (element < min)
                {
                    min = element;
                }
                if (element > max)
                {
                    max = element;
                }
            }
            file.Close();
            return min + max;
        }

        public static double sumOdd(StreamReader file)
        {
            double sumOdd = 0;
            double element;
            while (!file.EndOfStream)
            {
                element = double.Parse(file.ReadLine());
                sumOdd += element;
            }
            file.Close();
            return sumOdd;
        }

        public static void writeFirstChar(StreamReader oldFile, StreamWriter newFile)
        {
            char element;
            while (!oldFile.EndOfStream)
            {
                element = oldFile.ReadLine()[0];
                newFile.WriteLine(element);
            }
            oldFile.Close();
            newFile.Close();
        }
        
        /// <summary>
        /// Читает числа из исходного бинарного файла и записывает в новый файл те, что НЕ кратны k.
        /// </summary>
        public static void filterNonMultiples(string inputPath, string outputPath, int k)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(inputPath, FileMode.Open)))
            using (BinaryWriter writer = new BinaryWriter(File.Open(outputPath, FileMode.Create)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    if (number % k != 0)
                    {
                        writer.Write(number);
                    }
                }
            }
        }
        
        public static List<Toy> findSuitableToys(string filePath, int targetAge)
        {
            var result = new List<Toy>();

            using (var reader = new BinaryReader(File.OpenRead(filePath)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    var toy = new Toy
                    {
                        Name = reader.ReadString(),
                        Price = reader.ReadInt32(),
                        MinAge = reader.ReadInt32(),
                        MaxAge = reader.ReadInt32()
                    };

                    // Условия: не мяч и подходит по возрасту
                    if (!toy.Name.Equals("Мяч", StringComparison.OrdinalIgnoreCase) && 
                        toy.MinAge <= targetAge && targetAge <= toy.MaxAge)
                    {
                        result.Add(toy);
                    }
                }
            }

            return result;
        }
    }
}