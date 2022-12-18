module Combat.Endpoints

open Falco.Routing

let getEndpoints = [
    get "/combat/{combatId:int}" Controller.getState
    put "/combat" Controller.updateState
]