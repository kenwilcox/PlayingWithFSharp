// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System.Text.RegularExpressions

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

    // regex example
    let (|FirstRegexGroup|_|) pattern input =
      let m = Regex.Match(input, pattern)
      if (m.Success) then Some m.Groups.[1].Value else None

    let testRegex str =
      match str with
      | FirstRegexGroup "http://(.*?)/(.*)" host ->
            printfn "The value is a url and the host is %s" host
      | FirstRegexGroup ".*?@(.*)" host ->
            printfn "The value is an email and the host is %s" host
      | _ -> printfn "The value '%s' is something else" str

    testRegex "http://example.com/test"
    testRegex "sue@example.com"

    0 // return an integer exit code
