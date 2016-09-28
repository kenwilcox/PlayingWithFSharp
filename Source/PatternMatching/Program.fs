﻿// create some types
type Address = {Street: string; City: string;}
type Customer = {ID: int; Name: string; Address: Address}
type State = New | Draft | Published | Inactive | Discontinued

[<EntryPoint>]
let main argv =
    printfn "%A" argv

    let first, second, _ = (1, 2, 3)
    printfn "first = %A, second = %A" first second

    //let e1::e2::rest -> = [1..10] // nowarn "25", don't care right now
    let listRest aList =
      match aList with
      | e1::e2::rest -> (rest)
      | _ -> (aList)

    printfn "the rest is %A" (listRest [1..10])

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

    let handleState state =
      match state with
      | Inactive -> (printfn "state is now Inactive")
      | Draft -> (printfn "state is now Draft")
      | New -> (printfn "state is now New")
      | Discontinued -> (printfn "state is now Discontinued")
      | Published -> (printfn "state is now Published")

    handleState Published

    let getFileInfo filePath =
      let fi = new System.IO.FileInfo(filePath)
      if fi.Exists then Some(fi) else None

    let goodFileName = "C:\\pagefile.sys"
    let badFileName = "C:\\IDontExist.foo.bar"

    let goodFileInfo = getFileInfo goodFileName
    let badFileInfo = getFileInfo badFileName

    let doSomethingWithFileInfo checkFileInfo =
      match checkFileInfo with
      | Some (fileInfo:System.IO.FileInfo) -> (printfn "the file %s exists" fileInfo.FullName)
      | None -> (printfn "the file doesn't exist")

    doSomethingWithFileInfo goodFileInfo
    doSomethingWithFileInfo badFileInfo


    0 // return an integer exit code
