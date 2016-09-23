// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

type PersonName = {FirstName: string; LastName:string}

[<EntryPoint>]
let main argv =
    printfn "%A" argv

    let list = [1;2;3;4]

    // prepend to make a new List
    let list2 = 0::list

    // get the last 4
    let list3 = list2.Tail

    // the two lists are the identical object in memory
    printfn "%A" (System.Object.ReferenceEquals(list, list3))

    let john = {FirstName="John"; LastName="Doe"}
    printfn "%A" john

    let alice = {john with FirstName="Alice"}
    printfn "%A" alice

    0 // return an integer exit code
