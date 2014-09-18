
let filter func list =
        let rec loop acc = function
        | [] -> acc
        | head :: tail ->
            match func head with
            | true -> loop (head :: acc) tail
            | false -> loop (acc) tail
        List.rev (loop [] list)

let newList = filter (fun x -> x % 2 = 1) [1..3..28]
printfn "%A" newList