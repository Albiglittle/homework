

let rec pushBack l n =
    match l with
    | [] -> n :: []
    | head :: tail -> head :: pushBack tail n

printfn "%A" (pushBack [1; 2; 3; 4; 5] 6)