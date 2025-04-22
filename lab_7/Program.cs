using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace tasks
{
    class Program
    {
        struct Student
        {
            public string LastName;
            public string FirstName;
            public int Score1;
            public int Score2;
            public int Score3;
        }

        

        private static List<string> reverseList(List<string> list)
        {
            // Разворачиваем список вручную
            for (int i = 0; i < list.Count / 2; i++)
            {
                string temp = list[i];
                list[i] = list[list.Count - 1 - i];
                list[list.Count - 1 - i] = temp;
            }

            return list;
        }

        private static LinkedList<string> insertElement(LinkedList<string> list, string element, string newElement)
        {
            // Начинаем с первого узла
            LinkedListNode<string> current = list.First;

            // Проходим по всему списку
            while (current != null)
            {
                // Сохраняем следующий узел перед изменением списка
                LinkedListNode<string> next = current.Next;

                if (current.Value == element)
                {
                    // Вставляем F перед текущим элементом E
                    list.AddBefore(current, newElement);
                
                    // Вставляем F после текущего элемента E
                    list.AddAfter(current, newElement);
                }

                // Переходим к следующему узлу (который мы сохранили)
                current = next;
            }

            return list;
        }

        private static void getVisitedDiscos(Dictionary<string, HashSet<string>> visits, HashSet<string> allDiscos)
        {
            HashSet<string> visitedByAll = new HashSet<string>();
            HashSet<string> visitedBySome = new HashSet<string>();
            HashSet<string> visitedByNone = new HashSet<string>();
            
            //Список студентов
            List<string> students = new List<string>(visits.Keys);

            foreach (var disco in allDiscos)
            {
                bool consist = true;    //содержится ли дискотека в списке
                for (int i = 0; i < students.Count; i++)
                {
                    string student = students[i];

                    //список посещенных дискотек
                    HashSet<string> visitedBy = visits[student];
                    
                    if (!visitedBy.Contains(disco)) //Если дискотеки нет в списке
                    {
                        consist = false;    //не добавляем дискотеку в список всех посещенных
                        break;
                    }
                }
                if (consist)
                {
                    visitedByAll.Add(disco);
                }
            }

            foreach (var studentVisits in visits.Values)
            {
                foreach (string disco in studentVisits)
                {
                    visitedBySome.Add(disco);   //Добавляем в список все найденные дискотеки из перестановок студент-дискотека
                }
            }
            
            foreach (var disco in allDiscos)
            {
                if (!visitedBySome.Contains(disco))
                {
                    visitedByNone.Add(disco);   //Если в списке посещенных не встречается дискотека - в список непосещенных
                }
            }
            
            Console.WriteLine("\nПосещенные всеми дискотеки:");
            for (int i = 0; i < visitedByAll.Count; i++)
            {
                Console.WriteLine(visitedByAll.ElementAt(i));
            }

            Console.WriteLine("\nДискотеки, посещенные несколькими студентами:");
            for (int i = 0; i < visitedBySome.Count; i++)
            {
                Console.WriteLine(visitedBySome.ElementAt(i));
            }

            Console.WriteLine("\nНепосещенные дискотеки:");
            for (int i = 0; i < visitedByNone.Count; i++)
            {
                Console.WriteLine(visitedByNone.ElementAt(i));
            }
        }
        
        private static void getCharsFromEvenWords(string text)
        {
            HashSet<char> chars = new HashSet<char>();
        
            // Разделители слов
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r', '(', ')' };
        
            // Разбиваем текст на слова
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        
            // Обрабатываем слова с чётными номерами (индексы 1, 3, 5...)
            for (int i = 1; i < words.Length; i += 2)
            {
                foreach (char c in words[i])
                {
                    chars.Add(c);
                }
            }
            
            // Конвертируем HashSet в List для сортировки
            List<char> sortedResult = new List<char>(chars);
            sortedResult.Sort();
            
            // Выводим результат
            foreach (char c in sortedResult)
            {
                Console.Write(c + " ");
            }
        
            if (sortedResult.Count == 0)
            {
                Console.WriteLine("Нет подходящих символов");
            }
        }
        
        private static SortedList<string, Student> processStudents(string filePath)
        {
            var admittedStudents = new SortedList<string, Student>();
        
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int n = int.Parse(reader.ReadLine()); // количество абитуриентов

                    for (int i = 0; i < n; i++)
                    {
                        string line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        // Разбираем строку
                        string[] parts = line.Split(' ');
                        if (parts.Length < 5) continue; // минимум 5 частей: фамилия, имя, 3 балла

                        // Собираем данные студента
                        Student student = new Student();
                        student.LastName = parts[0];
                        student.FirstName = parts[1];
                        student.Score1 = int.Parse(parts[2]);
                        student.Score2 = int.Parse(parts[3]);
                        student.Score3 = int.Parse(parts[4]);

                        // Проверяем условия допуска
                        if (student.Score1 >= 30 && student.Score2 >= 30 && student.Score3 >= 30)
                        {
                            int total = student.Score1 + student.Score2 + student.Score3;
                            if (total >= 140)
                            {
                                // Используем фамилию + имя как ключ для сортировки
                                string key = student.LastName + student.FirstName;
                                admittedStudents.Add(key, student);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обработки файла: {ex.Message}");
            }

            return admittedStudents;
        }
        
        private static void inputNumberTask(out bool exitFlag)
        {
            exitFlag = false;

            while (true)
            {
                Console.WriteLine("\nВыберите задание (1-10) или введите 0 для выхода:");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            task1();
                            break;
                        case 2:
                            task2();
                            break;
                        case 3:
                            task3();
                            break;
                        case 4:
                            task4();
                            break;
                        case 5:
                            task5();
                            break;
                        case 6:
                            task6();
                            break;
                        case 7:
                            task7();
                            break;
                        case 8:
                            task8();
                            break;
                        case 9:
                            task9();
                            break;
                        case 10:
                            task10();
                            break;
                        case 0:
                            exitFlag = true;
                            return;
                        default:
                            Console.WriteLine("\nНеверный выбор. Пожалуйста, попробуйте еще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nПожалуйста, введите корректное число.");
                }
            }
        }
        
        private static int getPositiveInteger(string prompt)
        {
            int number;
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                {
                    return number;
                }
                Console.WriteLine("\nОшибка! Пожалуйста, введите положительное целое число.");
            }
        }

        private static void task1()
        {
            FileGeneration fileGeneration = new FileGeneration();
            Console.Write("Введите имя файла: ");
            string name = Console.ReadLine();
            try
            {
                fileGeneration.generate(name);
                StreamReader file = new StreamReader(name);
                double sumMinMax = FirstFive.sumMinMax(file);
                Console.WriteLine($"Сумма максимального и минимального = {sumMinMax}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        
        private static void task2()
        {
            FileGeneration fileGeneration = new FileGeneration();
            Console.Write("Введите имя файла: ");
            string name = Console.ReadLine();
            try
            {
                fileGeneration.generate(name);
                StreamReader file = new StreamReader(name);
                double sumOdd = FirstFive.sumOdd(file);
                Console.WriteLine($"Сумма четных = {sumOdd}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void task3()
        {
            Console.Write("Введите имя файла: ");
            string name = Console.ReadLine();
            try
            {
                StreamReader file = new StreamReader(name);
                Console.Write("Введите имя нового файла: ");
                name = Console.ReadLine();
                StreamWriter newFile = new StreamWriter(name);;
                FirstFive.writeFirstChar(file, newFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void task4()
        {
            FileGeneration fileGeneration = new FileGeneration();
            try
            {
                string inputFile = "task41.bin";
                string outputFile = "task42.bin";
                int k = getPositiveInteger("Введите k = ");
                int count = 10;  // Количество чисел в исходном файле
                // 1. Заполняем исходный файл случайными числами
                Console.WriteLine("Сгенерированные числа: ");
                fileGeneration.randomFillBinaryFile(inputFile, count);

                // 2. Фильтруем числа и сохраняем результат
                FirstFive.filterNonMultiples(inputFile, outputFile, k);
            
                // Читаем данные из бинарного файла и записываем в текстовый
                string checkFile = "check4.txt";
                Console.WriteLine("Полученные числа: ");
                fileGeneration.convertBinaryToTextFile(outputFile, checkFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void task5()
        {
            FileGeneration fileGeneration = new FileGeneration();
            try
            {
                string inputFile = "task51.bin";
                string outputFile = "task52.xml";
            
                // 1. Создаем и заполняем бинарный файл
                fileGeneration.generateToysFile(outputFile);

                // 2. Ищем подходящие игрушки
                List<Toy> suitableToys = FirstFive.findSuitableToys(outputFile, 3);

                // 3. Сохраняем результаты в XML
                fileGeneration.saveResultsToXml(suitableToys, outputFile);

                // 4. Выводим результаты
                Console.WriteLine("Найденные подходящие игрушки (не мячи):");
                foreach (var toy in suitableToys)
                {
                    Console.WriteLine(toy.ToString());
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void task6()
        {
            FileGeneration fileGeneration = new FileGeneration();
            try
            {
                List<string> L = fileGeneration.inputListValidation("\nВведите элементы списка через пробел:");
                List<string> resultList = reverseList(L);

                Console.WriteLine("\nПеревернутый список:");
                Console.WriteLine(string.Join(", ", resultList));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void task7()
        {
            FileGeneration fileGeneration = new FileGeneration();
            try
            {
                LinkedList<string> L = fileGeneration.inputLinkedList("\nВведите элементы списка через пробел:");
                Console.Write("Введите элемент E: ");
                string E = Console.ReadLine();
                Console.Write("Введите элемент F: ");
                string F = Console.ReadLine();
                LinkedList<string> resultList = insertElement(L, E, F);

                Console.WriteLine("\nСписок после вставки:");
                Console.WriteLine(string.Join(", ", resultList));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void task8()
        {
            FileGeneration fileGeneration = new FileGeneration();
            try
            {
                //Задание 8
                //Ввод дискотек из файла
                HashSet<string> allDiscos = fileGeneration.inputDiscoSet();
                //Ввод данных о студентах
                Dictionary<string, HashSet<string>> studentVisits = fileGeneration.readStudentData();

                //Посещенные дискотеки
                getVisitedDiscos(studentVisits, allDiscos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void task9()
        {
            string inputFile = "task9.txt";
            try
            {
                // Чтение текста из файла
                string text = File.ReadAllText(inputFile);
            
                // Получаем символы из слов с чётными номерами
                // Сортируем и выводим результат
                Console.WriteLine("Уникальные символы из слов с чётными номерами:");
                getCharsFromEvenWords(text);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void task10()
        {
            try
            {
                FileGeneration fileGeneration = new FileGeneration();
                // Генерация тестовых данных в файл
                fileGeneration.generateTestData("task10.txt", 10);

                // Чтение и обработка данных
                SortedList<string, Student> admittedStudents = processStudents("task10.txt");

                // Вывод результатов
                Console.WriteLine("Абитуриенты, допущенные к экзаменам (в алфавитном порядке):");
                foreach (var student in admittedStudents)
                {
                    Console.WriteLine($"{student.Value.LastName} {student.Value.FirstName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        
        static void Main()
        {
            bool exitFlag;
            inputNumberTask(out exitFlag);
            if (exitFlag)
            {
                Console.WriteLine("Выход из программы.");
            }
        }
    }
}