module Character.Endpoints

open Falco
open Falco.Routing

let getEndpoints = [
    get "/character/{id:int}" Controller.getCharacter
    all "/character" [GET, Controller.getAllCharacters
                      POST, Controller.createCharacter
                      PUT, Controller.updateCharacter]
]
    