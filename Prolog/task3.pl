%(A * B) + C = (A + C) * (B + C)

union([], L, L).
union([H|T], L, R) :- member(H, L), !, union(T, L, R).
union([H|T], L, [H|R]) :- union(T, L, R).

intersec([], _, []).
intersec([H|T1], S2, [H|T]):- member(H, S2), !, intersec(T1, S2, T).
intersec([_|T], S2, S) :- intersec(T, S2, S).

distributive_law() :-
    writeln('Введите списки в формате [элемент1, элемент2, ..., элементN]'),
    write('Введите A: '),
    read(A),
    write('Введите B: '),
    read(B),
    write('Введите C: '),
    read(C),
    union(A, B, UnionAB),   % A * B
    %Сохраняем в переменную, отвечающую за левую часть выражения
    intersec(UnionAB, C, LeftSi%(A * B) + C = (A + C) * (B + C)

union([], L, L).
union([H|T], L, R) :- member(H, L), !, union(T, L, R).
union([H|T], L, [H|R]) :- union(T, L, R).

intersec([], _, []).
intersec([H|T1], S2, [H|T]):- member(H, S2), !, intersec(T1, S2, T).
intersec([_|T], S2, S) :- intersec(T, S2, S).

distributive_law() :-
    writeln('Введите списки в формате [элемент1, элемент2, ..., элементN]'),
    write('Введите A: '),
    read(A),
    write('Введите B: '),
    read(B),
    write('Введите C: '),
    read(C),
    union(A, B, UnionAB),   % A * B
    %Сохраняем в переменную, отвечающую за левую часть выражения
    intersec(UnionAB, C, LeftSide), % (A * B) + C
    
    intersec(A, C, IntersectAC),    % A + C
    intersec(B, C, IntersectBC),    % B + C
    %Сохраняем в переменную, отвечающую за правую часть выражения
    union(IntersectAC, IntersectBC, RightSide), % (A + C) * (B + C)
    
    %Сортируем 
    sort(LeftSide, SortedLeftSide),
    sort(RightSide, SortedRightSide),
    
    %Для доказательства сравниваем левую и правую часть выражения
    write('Результат доказательства: '),
    SortedLeftSide == SortedRightSide.de), % (A * B) + C
    
    intersec(A, C, IntersectAC),    % A + C
    intersec(B, C, IntersectBC),    % B + C
    %Сохраняем в переменную, отвечающую за правую часть выражения
    union(IntersectAC, IntersectBC, RightSide), % (A + C) * (B + C)
    
    %Сортируем 
    sort(LeftSide, SortedLeftSide),
    sort(RightSide, SortedRightSide),
    
    %Для доказательства сравниваем левую и правую часть выражения
    writeln('Результат доказательства: '),
    write(SortedLeftSide),
    write(" = "),
    write(SortedRightSide),
    SortedLeftSide == SortedRightSide.