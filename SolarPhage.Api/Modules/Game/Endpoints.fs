module Game.Endpoints

open Falco
open Falco.Routing

let getEndpoints = [
    get "/game/{gameId:int}" Controller.getGame
    all "/game" [GET, Controller.getAllGames
                 POST, Controller.createGame
                 PUT, Controller.updateGame]
]