﻿

let fieldSearching =  "chan po chanu chanom pechanit ".ToCharArray() |> Array.toList // Преобразовали к массиву символов, после к списку символов
let template = "chan".ToCharArray() |> Array.toList // то же самое


// as = Используется, чтобы дать текущему объекту класса имя объекта.
// :: = Используется в сопоставлениях с шаблоном для отделения частей списка.
// :: = Создает список. Элемент левой части присоединяется к списку правой части.
// |> = Передает результат левой части в функцию правой части (оператор прямого канала).
// -> = Выдает выажение 
// -> = Используется в выражениях соответствия

let rec simple = function
    | _, [] -> 1 // список символов строки шаблона пуст, вернем 1
    | [], _ -> 0 // список символов строки где ищем пуст, вернем 0
    | fieldSearchingHead  :: fieldSearchingTail as fieldSearching,  (templateHead :: templateTail  as template) -> 
    // деление на хвост и голову строки для поиска, аналогично с шаблоном
        if fieldSearchingHead = templateHead  then // символы совпали, проверяем следующие
            simple (fieldSearchingTail , templateTail) + simple (fieldSearchingTail , template)
        else
            simple (fieldSearchingTail , template)

let res = simple (fieldSearching, template)
printfn "%A" res

// смысл в избежании повторений рекурсивных вызовов
let memoization fieldSearchingIn templateIn = 
    let memo = new System.Collections.Generic.Dictionary<(list<char> * list<char>), bigint> () // представляет коллекцию ключей и значений.
    let rec insideFun fieldSearchingIn2 templateIn2 = 
        if memo.ContainsKey (fieldSearchingIn2 , templateIn2) then // определяет наличие ключа в словаре Dictionary(TKey, TValue).
            memo.[(fieldSearchingIn2 , templateIn2)]
        else
            let slot = 
                match (fieldSearchingIn2 , templateIn2) with
                | _, [] -> 1I
                | [], _ -> 0I
                | fieldHead :: fieldTail, templateHead :: templateTail -> 
                    if fieldHead = templateHead  then
                        insideFun fieldTail templateTail + insideFun fieldTail templateIn2 // проверка и запуск слеудующего
                    else
                        insideFun fieldTail templateIn2 // не совпали - запускаем следующий
            memo.Add ((fieldSearchingIn2 , templateIn2), slot)
            slot 
    insideFun fieldSearchingIn templateIn

let res2 = memoization fieldSearching template
printfn "%A" res2