open System

type Complex = {
    Real: float
    Imaginary: float
}

let rec check_input_int() =
    let input = System.Console.ReadLine() 
    let success, value = System.Int64.TryParse(input)
    if success then 
        value 
    else 
        printfn "Ошибка! Введено неверное значение."
        printf "Введите число = "
        check_input_int()

let rec check_input_float() =
    let input = System.Console.ReadLine() 
    let x = input.Replace(".", ",")
    let success, value = System.Double.TryParse(x)
    if success then 
        value 
    else 
        printfn "Ошибка! Введено неверное значение."
        printf "Введите число = "
        check_input_float()

let print str result =
    let s = System.String.Join(" ", str, string(result))
    printfn "%s" s

let rec input() = 
    printf "Введите число = "
    let x = int(check_input_int())
    if x = -1 then
        []
    else
        if x%2 = 0 then
            1 :: input()
        else
            0 :: input()

let task1() =
    printfn "Введите -1 для выхода"
    let list = input()
    let result = System.String.Join(", ", list)
    print "Список: " result

let createList(x) = 
    let str = string x
    let lst = [
        for c in str do   
            yield c
    ]

    lst
    |> List.filter (fun c -> c >= '0' && c <= '9')
    |> List.filter (fun c -> (int c - int '0') % 2 = 0) // Оставляем только четные цифры

let task2() =
    printf "Введите число = "
    let value = check_input_float()
    let list = createList value
    let sortedList = List.sort list
    let result = System.String.Join(", ", sortedList)
    print "Список: " result


let addComplex complex1 complex2 =
    { Real = complex1.Real + complex2.Real; Imaginary = complex1.Imaginary + complex2.Imaginary }

let subComplex complex1 complex2 =
    { Real = complex1.Real - complex2.Real; Imaginary = complex1.Imaginary - complex2.Imaginary }

let mulComplex complex1 complex2 =
    { 
        Real = complex1.Real * complex2.Real - complex1.Imaginary * complex2.Imaginary;
        Imaginary = complex1.Real * complex2.Imaginary + complex1.Imaginary * complex2.Real
    }

let divComplex c1 c2 = 
    {
        Real = (c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / (c2.Real ** 2.0 + c2.Imaginary ** 2.0);
        Imaginary = (c2.Real * c1.Imaginary - c1.Real * c2.Imaginary) / (c2.Real ** 2.0 + c2.Imaginary ** 2.0)
    }

let rec powComplex c step = 
    let z = (c.Real ** 2.0 + c.Imaginary ** 2.0) ** 0.5
    let f = 
        if c.Real < 0 && c.Imaginary > 0 then
            Math.PI + Math.Atan(c.Imaginary / c.Real)
        elif c.Real < 0 && c.Imaginary < 0 then
            -Math.PI + Math.Atan(c.Imaginary / c.Real)
        else
            Math.Atan(c.Imaginary / c.Real)
    let power = z ** float(step)
    { 
        Real = power * Math.Cos(step * f);
        Imaginary = power * Math.Sin(step * f)
    }


let rec inputComplex() =
    let parseComplex (s: string) =
        let input = s.Replace(".", ",")
        let trimmedInput = input.Replace(" ", "")
        let plusIndex = trimmedInput.IndexOf('+')
        let minusIndex = trimmedInput.IndexOf('-')

        let signIndex = if plusIndex > 0 then plusIndex else minusIndex
        if signIndex < 0 then
            None  // Возврат None при ошибке
        else
            let iIndex = trimmedInput.IndexOf("i")
            if iIndex = trimmedInput.Length - 1 then        //Если число в формате a + bi
                let realPartString, imaginaryPartString =
                    if signIndex = 0 then   //Если знак стоит перед числом
                        let newString = trimmedInput.Substring(1, trimmedInput.Length - 1)
                        let newSign =   //Находим индекс следующего знака
                            if newString.IndexOf("+") > 0 then
                                newString.IndexOf("+") 
                            else
                                newString.IndexOf("-") 
                        trimmedInput.Substring(0, newSign+1), trimmedInput.Substring(newSign+1) //Парсим строку по индексу второго знака
                    else
                        trimmedInput.Substring(0, signIndex), trimmedInput.Substring(signIndex) //Если знак только один, то парсим по нему

                if not (imaginaryPartString.EndsWith("i")) then
                    None  // Возврат None при ошибке
                else
                    //Проверяем числа на корректность ввода
                    let success1, realPart = System.Double.TryParse(realPartString)  
                    let success2, imaginaryPart = System.Double.TryParse(imaginaryPartString.Substring(0, imaginaryPartString.Length - 1))
                    if not(success1) || not(success2) then
                        None
                    else
                        Some { Real = realPart; Imaginary = imaginaryPart }  // Возврат результата
            else        //Если число в формате bi + a
                let imaginaryPartString = trimmedInput.Substring(0, iIndex + 1)
                let realPartString = trimmedInput.Substring(iIndex + 1, trimmedInput.Length - iIndex - 1)
                
                if not (imaginaryPartString.EndsWith("i")) then
                    None  // Возврат None при ошибке
                else
                    //Проверяем числа на корректность ввода
                    let success1, realPart = System.Double.TryParse(realPartString)
                    let success2, imaginaryPart = System.Double.TryParse(imaginaryPartString.Substring(0, imaginaryPartString.Length - 1))
                    if not(success1) || not(success2) then
                        None
                    else
                        Some { Real = realPart; Imaginary = imaginaryPart }  // Возврат результата

    let input = System.Console.ReadLine()
    match parseComplex input with
    | Some complex -> complex  // Если парсинг успешен, возвращаем комплексное число
    | None -> 
        printf "Неверный формат комплексного числа. Введите снова = "
        inputComplex()  // Рекурсивный вызов для повторного ввода


let rec task3() =
    printf "Введите номер операции = "
    let number = int(check_input_int())
    if number = 0 then
        0
    else
        if number <= 4 then
            printf "Введите первое комплексное число (в формате a + bi) = "
            let complex1 = inputComplex()

            printf "Введите второе комплексное число (в формате a + bi) = "
            let complex2 = inputComplex()

            if number = 1 then
                let result = addComplex complex1 complex2
                printfn "Сумма комплексных чисел: %.1f + %.1fi" result.Real result.Imaginary
                task3()
            elif number = 2 then
                let result = subComplex complex1 complex2
                printfn "Разность комплексных чисел: %.1f + %.1fi" result.Real result.Imaginary
                task3()
            elif number = 3 then
                let result = mulComplex complex1 complex2
                printfn "Произведение комплексных чисел: %.1f + %.1fi" result.Real result.Imaginary
                task3()
            else
                let result = divComplex complex1 complex2
                if (complex2.Real ** 2.0 + complex2.Imaginary ** 2.0) = 0 then
                    printfn "Деление на ноль!"
                    task3()
                else
                    printfn "Результат деления комплексных чисел: %.1f + %.1fi" result.Real result.Imaginary
                    task3()
        elif number = 5 then
            printf "Введите степень = "
            let n = check_input_float()
            printf "Введите комплексное число (в формате a + bi) = "
            let complex = inputComplex()
            let result = powComplex complex n
            printfn "Результат возведения в степень: %.1f + %.1fi" result.Real result.Imaginary
            task3()
        else
            printfn "Неправильный номер задачи"
            task3()

let rec Main() = 
    printfn "\n*Чтобы выйти, введите 0*"
    printf "Введите номер задачи (1-3) = "
    let number = int(check_input_int())
    if number = 0 then
        0
    else
    if number = 1 then
        task1()
        Main()
    elif number = 2 then
        task2()
        Main()
    elif number = 3 then
        printfn "[Комплексные числа]"
        printfn "\n*Чтобы выйти, введите 0*"
        printfn "Операции:\n 1) Сложение \n 2) Вычитание \n 3) Умножение \n 4) Деление \n 5) Возведение в степень"
        task3()
        Main()
    else
        printfn "Неправильный номер задачи"
        Main()

Main()