count_nonzero([], 0).

count_nonzero([H|T], Count) :-
    % Если текущий элемент равен нулю, пропускаем его
    H = 0,
    count_nonzero(T, Count); count_nonzero(T, TCount),
    Count is TCount + 1.                % Увеличиваем счетчик на 1

main :-
    write('Введите список (в формате [элемент1, ..., элементN]): '),
    read(List),
    
    % Подсчет ненулевых элементов
    count_nonzero(List, NonZeroCount),
    
    % Вывод результата
    format('Количество ненулевых элементов в списке: ~w~n', NonZeroCount).