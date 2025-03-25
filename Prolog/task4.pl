check(1, Ans) :-
    not(member((_, "Фантик", "Рыжий"), Ans)),
    not(member((_, "Мурлыка", "Серый"), Ans)).
check(2, Ans) :-
    not(member((_, "Дружок", "Белый"), Ans)),
    not(member((_, "Елисей", "Серый"), Ans)).
check(3, Ans) :-
    member(("Миша", _, "Черный"), Ans),
    member(("Максим", "Мурлыка", _), Ans).
check(4, Ans) :-
    member(("Леня", "Елисей", _), Ans),
    member(("Дима", _, "Белый"), Ans).
check(5, Ans) :-
    not(member(("Дима", "Фантик", _), Ans)),
    not(member((_, "Дружок", "Серый"), Ans)).

check2(N, true, Ans) :-
    check(N, Ans).
check2(N, false, Ans) :-
    not(check(N, Ans)).

% Предикат для построчного вывода списка
print_list([]).     % База рекурсии: пустой список ничего не выводит
print_list([Head|Tail]) :-
    writeln(Head),   % Вывести первый элемент списка
    print_list(Tail). % Рекурсивно обработать остальные элементы
 
solve(Ans, Solve) :-
    %Генерация всех возможных вариантов котят и их цветов
    permutation(["Дружок", "Елисей", "Фантик", "Мурлыка"], [K1, K2, K3, K4]),
    permutation(["Рыжий", "Серый", "Белый", "Черный"], [C1, C2, C3, C4]),
    Solve =
        [ ("Миша", K1, C1), ("Максим", K2, C2),
            ("Леня", K3, C3), ("Дима", K4, C4)
        ],
    select(false, Ans, [true, true, true, true]),   %Выбор ложного утверждения
    Ans = [I1, I2, I3, I4, I5],
    %Проверка условий
    check2(1, I1, Solve),
    check2(2, I2, Solve),
    check2(3, I3, Solve),
    check2(4, I4, Solve),
    check2(5, I5, Solve),
    writeln("Ответ на задачу: "),
    print_list(Solve).