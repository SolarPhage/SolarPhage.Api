module Character.Controller

open Character.Types
open Character.Sql
open Falco

let inventoryItem = { Item = { Id = 5; Name = "item" }; Count = 5 }

let character = {
    CharacterId = 5
    UserId = "230598sfljf"
    // Name = "TestName"
    // Level = 5
    // Enabled = true
    // Inventory = [ inventoryItem ]
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
        let id = r.GetString("id")
        getCharactersByUserId id)
        Response.ofJson 
    
let createCharacter : HttpHandler = 
    let handleOk character : HttpHandler = 
        Response.ofJson character.Name

    Request.mapJson handleOk

let updateCharacter : HttpHandler = 
    let handleOk character : HttpHandler = 
        Response.ofJson character.Id

    Request.mapJson handleOk