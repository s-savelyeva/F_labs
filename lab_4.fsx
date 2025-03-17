open System

type BinaryTree =
    | Node of float * BinaryTree * BinaryTree
    | Empty


let rand() =
    let rndGen = new Random(int DateTime.Now.Ticks)
    rndGen.Next(-1000, 1000)

let rec check_input_float(input:string) =
    let x = input.Replace(".", ",")
    let success, value = System.Double.TryParse(x)
    if success then 
        value 
    else 
        printfn "Ошибка! Введено неверное значение."
        printf "Введите число = "
        let newInput = System.Console.ReadLine() 
        check_input_float(newInput)

let rec check_input_int() =
    let input = System.Console.ReadLine() 
    let success, value = System.Int64.TryParse(input)
    if success then 
        value 
    else 
        printfn "Ошибка! Введено неверное значение."
        printf "Введите число = "
        check_input_int()

//Функция для вывода дерева
let rec printTree tree tab =
    match tree with
    | Empty -> ()
    | Node (value, left, right) ->
        printTree right (tab + 4)
        printfn "%s%.2f" (System.String(' ', tab)) value
        printTree left (tab + 4)

//Функция для поиска и вставки элемента в дерево
let rec addValue tree value =
    match tree with
    | Empty -> Node (value, Empty, Empty)
    | Node (nodeValue, left, right) ->
        if value < nodeValue then
            Node (nodeValue, addValue left value, right)
        else
            Node (nodeValue, left, addValue right value)

//Функция для создания дерева
let inputTree tree =
    printfn "[Введите ex для выхода]"
    let rec create tree =
        printf "Введите число = "
        let input = System.Console.ReadLine()
        
        match input with
        | "ex"  -> tree
        | _ ->
            let value = check_input_float(input)
            let node = addValue tree value
            create node
    create tree

let randTree tree =
    printf "Введите кол-во чисел = "
    let count = int(check_input_int())
    let rec createRand tree count acc =
        if acc = count then 
            tree
        else
            let value = rand()
            let node = addValue tree value
            createRand node count (acc+1)
    createRand tree count 0

// Функция для замены значений в дереве
let rec replaceValues tree =
    match tree with
    | Empty -> Empty
    | Node (value, left, right) ->
        let newValue = 
            if value < 0.0 then
                0.0
            else 
                1.0
        Node (newValue, replaceValues left, replaceValues right)
    
let rec countElements tree digit =
    match tree with
    | Empty -> 0
    | Node (value, left, right) ->
        let countAcc = if value.ToString().Contains(digit.ToString()) then 1 else 0
        countAcc + (countElements left digit) + (countElements right digit)

let rec check_digit() =
    let digit = int(check_input_int())
    if digit < 0 || digit > 9 then
        printf "Не цифра. Повторите ввод = "
        check_digit()
    else
        digit

let rec task1() =
    printf "Выберите способ ввода = "
    let number = int(check_input_int())
    let tree = 
        if number = 1 then
            inputTree(Empty)
        elif number = 2 then
            randTree(Empty)
        else
            printfn "Неверный номер"
            task1()
    printfn "Исходное дерево:"
    printTree tree 0

    let resultTree = replaceValues tree
    printfn "После замены:"
    printTree resultTree 0
    Empty

let task2() =
    printf "Выберите способ ввода = "
    let number = int(check_input_int())
    let tree = 
        if number = 1 then
            inputTree(Empty)
        elif number = 2 then
            randTree(Empty)
        else
            printfn "Неверный номер"
            task1()
    printfn "Исходное дерево:"
    printTree tree 0

    printf "Введите цифру = "
    let digit = check_digit()

    let result = countElements tree digit
    printfn "Количество = %d" result


let rec Main() =
    printfn "[Введите 0 для выхода]"
    printf "Введите номер задания = "
    let task = int(check_input_int())
    printfn ""
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

printfn "Задания:\n1) Map (замена отр. -> 1 и пол. -> 0)\n2) Fold (подсчет кол-ва чисел с цифрой)"
Main()