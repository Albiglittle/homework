

let rec filter list =
    match list with
    |head::tail -> if (head < 6) then [head] @ filter(tail) else filter(tail)
    |[] -> []

let example = filter[10; 5; 1; 2; 345; 1; 3; 1; 0; 20; 5]

printfn "%A" example