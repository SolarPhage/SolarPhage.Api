module Character.Controller

open Character.Types
open Falco

let handleConfigRead : HttpHandler =
    // Note: colon-separated to access nested values
    Response.ofJson {|
        LogLevel = "test"
        ConnectionString = "test" |}

let inventoryItem = { Item = { Id = 5; Name = "item" }; Count = 5 }

let character = {
    Id = 5
    Name = "TestName"
    Level = 5
    Enabled = true
    Inventory = [ inventoryItem ]
}

let characters = [
    character
    character
    character
]

let getAllCharacters : HttpHandler = 
    Response.ofJson characters

let getCharacter : HttpHandler = 
    Request.mapRoute (fun r -> 
        let id = r.GetInt("id")
        { Id = id; Name = "query"; Level = 1; Enabled = true; Inventory = [ inventoryItem ] })
        Response.ofJson
    
let createCharacter : HttpHandler = 
    let handleOk character : HttpHandler = 
        Response.ofJson character.Name

    Request.mapJson handleOk

let updateCharacter : HttpHandler = 
    let handleOk character : HttpHandler = 
        Response.ofJson character.Id

    Request.mapJson handleOk