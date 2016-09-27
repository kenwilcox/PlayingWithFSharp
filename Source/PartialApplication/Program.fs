// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv =
    printfn "%A" argv

    // define an adding function
    let add x y = x + y

    // normal use
    let z = add 1 3
    printfn "%A" z

    // make 42 be fixed, accept additional parameters later
    let add42 = add 42

    printfn "%A" (add42 2)
    printfn "%A" (add42 3)


    // revisit the generic logger
    let genericLogger anyFunc input =
      printfn "input is %A" input   // Log the input
      let result = anyFunc input    // evaluate the function
      printfn "result is %A" result // Log the result
      result                        // return the result

    let genericLogger before after anyFunc input =
      before input                  // callback for custom behavior
      let result = anyFunc input    // evaluate the function
      after result                  // callback for custom behavior
      result                        // return the result

    let add1 input = input + 1

    // reuse case 1
    genericLogger
        (fun x -> printf "before=%i. " x)
        (fun x -> printf " after=%i." x)
        add1
        2 |> ignore

    // reuse case 2
    genericLogger
        (fun x -> printf "started with=%i " x)
        (fun x -> printf " ended with %i" x)
        add1
        2 |> ignore

    let add1WithConsoleLogging =
      genericLogger
        (fun x -> printf "input=%i. " x)
        (fun x -> printf " result=%i\n" x)
        add1

    printfn "\n"
    printfn "2: %A\n" (add1WithConsoleLogging 2)
    printfn "3: %A\n" (add1WithConsoleLogging 3)
    printfn "4: %A\n" (add1WithConsoleLogging 4)

    [1..5] |> List.map add1WithConsoleLogging |> ignore

    0 // return an integer exit code
