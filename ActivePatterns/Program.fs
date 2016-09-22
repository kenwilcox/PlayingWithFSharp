// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    // create some active patterns
    let (|Int|_|) str =
      match System.Int32.TryParse(str) with
      | (true, int) -> Some(int)
      | _ -> None

    let (|Bool|_|) str =
      match System.Boolean.TryParse(str) with
      | (true, bool) -> Some(bool)
      | _ -> None

    // Now we can use it with match..with
    let testParse str =
      match str with
      | Int i -> printfn "The value is an int '%i'" i
      | Bool b -> printfn "The value is a bool '%b'" b
      | _ -> printfn "The value '%s' is something else" str

    testParse "12"
    testParse "true"
    testParse "abc"

    0 // return an integer exit code
