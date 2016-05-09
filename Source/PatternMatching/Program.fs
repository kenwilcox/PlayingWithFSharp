#nowarn "25"

// create some types
type Address = {Street: string; City: string;}
type Customer = {ID: int; Name: string; Address: Address}


[<EntryPoint>]
let main argv =
    printfn "%A" argv

    let first, second, _ = (1, 2, 3)
    printfn "first = %A, second = %A" first second

    let e1::e2::rest = [1..10] // nowarn "25", don't care right now
    printfn "the rest is %A" rest

    let listMatcher aList =
      match aList with
      | [] -> printfn "the list is empty"
      | [first] -> printfn "the list has one element %A " first
      | [first; second] -> printfn "list is %A and %A" first second
      | _ -> printfn "the list has more than two elements"

    listMatcher [1;2;3;4]
    listMatcher [1;2]
    listMatcher [1]
    listMatcher []

    let customer1 = {ID =1; Name = "Bob"; Address = {Street="123 Main"; City="Nowheresville"}}
    let {Name=name1} =  customer1
    printfn "The customer is called %s" name1
    // why not use dot?
    printfn "The customer is called %s" customer1.Name

    let {ID=id2; Name=name2;} = customer1
    printfn "The customer called %s has id %i" name2 id2

    let {Name=name3; Address={Street=street3}} = customer1
    printfn "The customer is called %s and lives at %s" name3 street3

    0 // return an integer exit code
