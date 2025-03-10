open System
open System.IO

let rand() =
    let rndGen = new Random(int DateTime.Now.Ticks)
    rndGen.Next(-1000, 1000)

let rec check_input_int() =
    let input = System.Console.ReadLine() 
    let success, value = System.Int64.TryParse(input)
    if success then 
        value 
    else 
        printfn "Ошибка! Введено неверное значение."
        printf "Введите число = "
        check_input_int()

let check_odd x = 
    if x % 2 = 0 then
        true 
    else 
        false

let rec input_seq() =
    printf "Введите целое число (или ex для выхода): "
    let input = Console.ReadLine()

    match input with
    | "ex" -> Seq.empty  // Завершение ввода
    | _ ->
        match Int64.TryParse(input) with
        | (true, number) ->
            seq { yield int(number); yield! input_seq() }  // Сохраняем число и продолжаем ввод
        | _ ->
            printfn "Ошибка: введите целое число"  // Сообщение об ошибке
            input_seq()  // Повторяем ввод

let task1() =
    printf "Введите 1 - для ввода чисел, 2 - для генерации: "
    let choice = int(check_input_int())

    let numbers = 
        if choice = 1 then
            input_seq()
        else    //Генерируем числа случайным образом
            printf "Введите количество чисел = "
            let count = int(check_input_int())
            seq{for i in 1 .. count do
                yield rand()}
    if choice = 2 then 
        printfn "Сгенерированная последовательность: %s" (System.String.Join(", ", numbers))
    let result = Seq.map check_odd numbers
    printfn "Результат: %s" (System.String.Join(", ", result))
    

let to_dec x =
    match x with
    | "I" -> 1
    | "II" -> 2
    | "III" -> 3
    | "IV" -> 4
    | "V" -> 5
    | "VI" -> 6
    | "VII" -> 7
    | "VIII" -> 8
    | "IX" -> 9
    | _ -> 0

let rec input_rim() =
    printf "Введите римское число (или ex для выхода): "
    let input = Console.ReadLine()

    match input with
    | "ex" -> Seq.empty  // Завершение ввода
    | _ ->
        match input with
        | "I" | "II" | "III" | "IV" | "V" | "VI" | "VII" | "VIII" | "IX" -> seq { yield input; yield! input_rim() }  // Сохраняем число и продолжаем ввод
        | _ ->
            printfn "Ошибка: введите римское число"  // Сообщение об ошибке
            input_rim()  // Повторяем ввод

let task2() =
    let rim_numbers = input_rim()

    let result = Seq.fold(fun acc elem -> acc + to_dec(elem)) 0 rim_numbers
    printfn "Результат: %d" result

let countFiles (directory: string) (startChar: string) : int =
    let rec getFiles (dir: string) =
        seq {
            // Получаем все файлы в текущем каталоге
            yield! Directory.GetFiles(dir) 
            // Получаем все подкаталоги и рекурсивно обрабатываем их
            for subDir in Directory.GetDirectories(dir) do
                yield! getFiles subDir
        }
    printfn "Файлы:\n%s" (System.String.Join(", ", getFiles(directory)))
    // Фильтруем файлы по начальной букве и считаем их
    getFiles directory
    |> Seq.filter (fun fileName -> Path.GetFileName(fileName).StartsWith(startChar))
    |> Seq.length

let rec task3() =
    // Запрос ввода каталога и символа
    printf "Введите путь к каталогу: "
    let directory = Console.ReadLine()
    //Проверка пути к каталогу
    let success =
        try
            Some(Directory.GetFiles(directory))
        with
            _ -> None   //Возвращаем ошибку в случае исключения
    if success = None then
        printfn "Неверный путь к каталогу"
        task3() //Запрашиваем ввод снова
    else
        printf "Введите символ: "
        let startChar = Console.ReadLine()

        // Получаем количество файлов и выводим результат
        let count = countFiles directory startChar
        printfn "Количество файлов, начинающихся с символа '%s': %d" startChar count

let rec Main() =
    printfn "*Введите 0 для выхода*"
    printf "Введите номер задания = "
    let task = int(check_input_int())
    if task = 0 then
        0
    elif task = 1 then
        task1()
        Main()
    elif task = 2 then
        task2()
        Main()
    elif task = 3 then
        task3()
        Main()
    else
        printfn "Неправильный номер задания"
        Main()

printfn "Задания:\n1) Seq.map (четность)\n2) Seq.fold (римские цифры)\n3) Задача на обработку каталогов"
Main()
