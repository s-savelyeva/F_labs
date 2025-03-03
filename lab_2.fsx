open System

let rec check_input_int() =
    let input = System.Console.ReadLine() 
    let success, value = System.Int64.TryParse(input)
    if success then 
        value 
    else 
        printfn "Ошибка! Введено неверное значение."
        printf "Введите число = "
        check_input_int()

let rec input() = 
    printf "Введите число = "
    let x = int(check_input_int())
    if x = -1 then
        []
    else
        x :: input()

let rec check_input_rim() =
    let input = System.Console.ReadLine() 
    let success =
        match input with
            | "I" -> true
            | "II" -> true
            | "III" -> true
            | "IV" -> true
            | "V" -> true
            | "VI" -> true
            | "VII" -> true
            | "VIII" -> true
            | "IX" -> true
            | "ex" -> true
            | _ -> false
    if success then
        input
    else
        printfn "Ошибка! Введено неверное значение."
        printf "Введите римское число = "
        check_input_rim()
let rec input_rim() = 
    printf "Введите римское число = "
    let x = check_input_rim()
    if x = "ex" then
        []
    else
        x :: input_rim()

let print str result =
    let s = System.String.Join(" ", str, string(result))
    printfn "%s" s

let check_odd x = 
    if x % 2 = 0 then
        true 
    else 
        false

let to_dec x=
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

let rand() =
    let rndGen = new Random(int DateTime.Now.Ticks)
    rndGen.Next(-1000, 1000)

let task1() =
    printfn "*Введите -1 для выхода*"
    printf "Введите 1 - для ввода чисел, 2 - для генерации: "
    let choice = int(check_input_int())
    let list_numbers =
        if choice = 1 then
            input()
        else
            printf "Введите количество чисел = "
            let count = int(check_input_int())
            [for i in 1 .. count do
                yield rand()]
    if choice = 2 then 
        printfn "Сгенерированный список: %s" (System.String.Join(", ", list_numbers))

    let list_odd = List.map check_odd list_numbers
    let result = System.String.Join(", ", list_odd)
    print "Список: " result

let task2() =
    printfn "*Введите ex для выхода*"
    let rim_numbers = input_rim()
    let result = List.fold(fun acc elem -> acc + to_dec(elem)) 0 rim_numbers
    printfn "Сумма элементов списка = %d" result

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
    else
        printfn "Неправильный номер задания"
        Main()

printfn "Задания:\n1) List.Map (четность)\n2) List.Fold (римские цифры)"
Main()