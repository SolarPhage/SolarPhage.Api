module Game.Controller

open Game.Types
open Falco

let getAllGames : HttpHandler = 
    Response.ofJson { GameId = 5; MaxFloor = 100 }

let getGame : HttpHandler = 
    Request.mapRoute (fun r -> 
        let id = r.GetInt("gameId")
        { GameId = id; MaxFloor = 100 })
        Response.ofJson
    
let createGame : HttpHandler = 
    let handleOk game : HttpHandler = 
        Response.ofJson game.GameId

    Request.mapJson handleOk

let updateGame : HttpHandler = 
    let handleOk game : HttpHandler = 
        Response.ofJson game.GameId

    Request.mapJson handleOk
