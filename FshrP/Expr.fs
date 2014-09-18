﻿

open System

// описываем новый тип
type Expression = 
    | Const of int
    | Var of string
    | Add of Expression * Expression
    | Sub of Expression * Expression
    | Mul of Expression * Expression
    | Div of Expression * Expression

let rec calc expression =
    let simple expression =
        match expression with
        |Add(Const 0, a) | Add(a, Const 0) -> a
        |Add(Const a, Const b) | Add(Const b, Const a) -> Const(a + b)
        |Sub(b, Const 0) -> b
        |Sub(Const a, Const b) -> Const(a-b)
        |Mul(a, Const 0) | Mul(Const 0, a) -> Const 0
        |Mul(Const a, Const b) | Mul(Const b, Const a) -> Const(a*b)
        |Div(Const 0, a) -> Const 0
        |Div(a, Const 0) -> failwith "Division by zero - exception"
        |Div(Const a, Const b) -> Const(a / b)
        |Div(a, Const 1) -> a
        |_ -> expression
    // запускаем отсюда как надо
    match expression with
    |Add(a, b) -> simple(Add(calc a, calc b)) 
    |Sub(a, b) -> simple(Sub(calc a, calc b))
    |Mul(a, b) -> simple(Mul(calc a, calc b))
    |Div(a, b) -> simple(Div(calc a, calc b))
    |Const a -> expression
    |Var a -> expression

let x = (Mul((Div(Const 6, Const 2)), (Add(Var "a", Const 0))))
let y = (Sub((Add(Const 4, Const 3)), (Add(Const 0, Const 3))))

let newX = calc x
let newY = calc y

printfn "Before conversion:\n%A " x
printfn "%A" y

printfn "After conversion:\n%A" newX
printfn "%A" newY