module Dungeon.Endpoints

open Falco.Routing

let getEndpoints = [
    get "/dungeon/{dungeonId:int}" Controller.getDungeon
    post "/dungeon" Controller.createDungeon
]