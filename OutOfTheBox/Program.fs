// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

type USAddress = {Street: string; City: string; State: string; Zip: string}
type UKAddress = {Street: string; Town: string; PostCode: string}
type Address = US of USAddress | UK of UKAddress
type Person = {Name: string; Address: Address}

type PersonalName = {FirstName: string; LastName: string}

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let alice = {
       Name="Alice"; 
       Address=US {Street="123 Main";City="LA";State="CA";Zip="91201"}}
    let bob = {
       Name="Bob"; 
       Address=UK {Street="221b Baker St";Town="London";PostCode="NW1 6XE"}}

    // built in pretty printing
    printfn "Alice is %A" alice
    printfn "Bob is %A" bob

    // built in structural equality
    let alice1 = {FirstName = "Alice"; LastName="Adams"}
    let alice2 = {FirstName = "Alice"; LastName="Adams"}
    let bob1 = {FirstName = "Bob"; LastName="Bishop"}
    
    printfn "alice1 = alice2 is %A" (alice1=alice2)
    printfn "alice1 = bob1 is %A" (alice1=bob1)

    0 // return an integer exit code
