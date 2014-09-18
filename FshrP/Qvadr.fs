
let squareSolve = fun (a,b,c) ->
        let d = b * b - 4.0 * a * c
        ((-b+sqrt(d))/(2.*a),(-b-sqrt(d))/(2.*a));

let (x1, x2) = squareSolve (1.0, 3.0, -4.0)

printfn "%A" (x1, x2)
