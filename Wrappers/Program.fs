// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv =
    printfn "%A" argv

    let add1 input = input + 1
    let times2 input = input * 2

    let genericLogger anyFunc input =
      printfn "input is %A" input
      let result = anyFunc input
      printfn "result is %A" input
      result

    let add1WithLogging = genericLogger add1
    let times2WithLogging = genericLogger times2

    add1WithLogging 3 |> ignore
    times2WithLogging 3 |> ignore

    [1..5] |> List.map add1WithLogging |> ignore

    let genericTimer anyFunc input =
      let stopwatch = System.Diagnostics.Stopwatch()
      stopwatch.Start()
      let result = anyFunc input
      printfn "elapsed ms is %A" stopwatch.ElapsedMilliseconds
      result

    let add1WithTimer = genericTimer add1WithLogging

    add1WithTimer 3 |> ignore

    0 // return an integer exit code
