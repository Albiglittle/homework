   

let generator func list =
     let rec loop acc = function
        | [] -> acc
        | head :: tail -> loop (func head :: acc) tail
     List.rev (loop [] list)

let newList = generator (fun x -> x*x-1) [1..6]

printfn "%A" newList