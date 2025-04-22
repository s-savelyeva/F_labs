using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace tasks
{
    class FileGeneration
    {
        public void generate(string filePath)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                Random random = new Random();
                for (int i = 0; i < 50; i++)
                {
                    int randomNumber = random.Next(-100, 100);
                    writer.WriteLine(randomNumber);
                }
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nОшибка: {e.Message}.");
            }
        }
        
        /// <summary>
        /// Заполняет бинарный файл случайными числами (int).
        /// </summary>
        public void randomFillBinaryFile(string filePath, int numberCount)
        {
            Random rand = new Random();
            BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create));
            
            for (int i = 0; i < numberCount; i++)
            {
                int number = rand.Next(-100, 100);
                writer.Write(number);  // Числа от 1 до 99
                Console.Write(number + ", ");
                
            }
            Console.WriteLine();
            writer.Close();
        }
        
        public void convertBinaryToTextFile(string binaryPath, string textPath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(binaryPath, FileMode.Open)))
            using (StreamWriter writer = new StreamWriter(textPath, false))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    // Читаем число (предполагаем формат int)
                    int number = reader.ReadInt32();
                
                    // Записываем число в текстовый файл
                    writer.WriteLine(number);
                    Console.Write(number + ", ");
                }
            }
        }
        
        public void generateToysFile(string filePath)
        {
            Random random = new Random();
            string[] toyNames = new[] { "Кукла", "Машинка", "Конструктор", "Пазл", "Мягкая игрушка", "Мяч", "Кубики", "Настольная игра" };

            Toy[] toys = new Toy[toyNames.Length];
            using (BinaryWriter writer = new BinaryWriter(File.Create(filePath)))
            {
                Console.WriteLine("Сгенерированные игрушки:");
                for (int i = 0; i < toyNames.Length; i++)
                {
                    int minAge = random.Next(0, 5);
                    Toy toy = new Toy
                    {
                        Name = toyNames[i],
                        Price = random.Next(100, 5000),
                        MinAge = minAge,
                        MaxAge = random.Next(minAge + 1, 8)
                    };
                    
                    Console.WriteLine(toy.ToString());

                    writer.Write(toy.Name);
                    writer.Write(toy.Price);
                    writer.Write(toy.MinAge);
                    writer.Write(toy.MaxAge);
                }
            }

            Console.WriteLine();
        }
        
        public void saveResultsToXml(List<Toy> toys, string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<Toy>));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, toys);
            }
        }
        
        public List<string> inputListValidation(string prompt)
        {
            List<string> list = new List<string>();

            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            list.Clear();
            string[] inputs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in inputs)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
        
        public LinkedList<string> inputLinkedList(string prompt)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nОшибка! Данные не были введены. Пожалуйста, попробуйте еще раз.");
                    continue;
                }

                string[] items = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                validInput = true;

                foreach (string item in items)
                {
                    linkedList.AddLast(item);
                }
            }
            return linkedList;
        }
        
        public HashSet<string> inputDiscoSet()
        {
            HashSet<string> discos = new HashSet<string>();
            Console.Write("Введите имя файла: ");
            string filePath = Console.ReadLine();
            try
            {
                // Чтение всех строк из файла
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Добавляем только непустые строки
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            discos.Add(line.Trim());
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filePath} не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        
            return discos;
        }

        public Dictionary<string, HashSet<string>> readStudentData()
        {
            var result = new Dictionary<string, HashSet<string>>();
            Console.Write("Введите имя файла: ");
            string filePath = Console.ReadLine();
            
            try
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    
                    var parts = line.Split(':');
                    if (parts.Length != 2)
                        continue;
                    
                    string studentName = parts[0].Trim();
                    string[] discos = parts[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                
                    var visitedDiscos = new HashSet<string>();
                    foreach (string disco in discos)
                    {
                        visitedDiscos.Add(disco.Trim());
                    }
                
                    result[studentName] = visitedDiscos;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filePath} не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении данных студентов: {ex.Message}");
            }
        
            return result;
        }
        
        public void generateTestData(string filePath, int count)
        {
            Random rnd = new Random();
            string[] lastNames = { "Иванов", "Петров", "Сидоров", "Романов", "Кузнецов", "Смирнов", "Попов", "Васильев" };
            string[] firstNames = { "Алексей", "Дмитрий", "Сергей", "Андрей", "Михаил", "Владимир", "Анна", "Елена" };

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(count); // количество записей

                for (int i = 0; i < count; i++)
                {
                    string lastName = lastNames[rnd.Next(lastNames.Length)];
                    string firstName = firstNames[rnd.Next(firstNames.Length)];
                    int score1 = rnd.Next(0, 101);
                    int score2 = rnd.Next(0, 101);
                    int score3 = rnd.Next(0, 101);

                    writer.WriteLine($"{lastName} {firstName} {score1} {score2} {score3}");
                }
            }
        }
    }
}