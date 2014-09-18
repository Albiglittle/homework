
open System.Numerics

let factorial (number : BigInteger) =
    let rec loop (number : BigInteger) (acc : BigInteger) =
        match number with 
        | _ when number < 1I -> acc
        | _ -> loop (number - 1I) (acc * number)
    loop number 1I
let summary number =
    let rec loop (number : BigInteger) (acc : BigInteger) =
        match number with
        | _ when number = 0I -> acc
        | _ -> loop (number / 10I) (acc + (number % 10I))
    loop number 0I

let gogo = summary (factorial 100I)