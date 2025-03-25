% Рекурсивная функция для вычисления суммы цифр числа
sum_digits(0, 0). % База рекурсии: сумма цифр нуля равна нулю
sum_digits(N, Sum) :-
    N > 0,
    Digit is N mod 10,     % Получаем последнюю цифру числа
    Rest is N // 10,       % Удаляем последнюю цифру
    sum_digits(Rest, RestSum),   % Рекурсивный вызов для оставшейся части числа
    Sum is Digit + RestSum.      % Суммируем полученную цифру и результат рекурсии

% Определяем предикат для нахождения отношения числа к сумме его цифр
ratio_to_sum(Number, Ratio) :-
    sum_digits(Number, Sum),
    Sum > 0,  % Убедимся, что сумма не равна нулю
    Ratio is Number / Sum.

calculate_ratio(Number, Ratio) :-
    ratio_to_sum(Number, Ratio).

% Основная программа
main :-
    write('Введите число: '),
    read(X),
    calculate_ratio(X, Sum),
    format('Отношение числа ~w к его сумме равна ~w.~n', [X, Sum]).
