module Item.Endpoints

open Falco.Routing

let getEndpoints = [
    get "/item/{itemId:int}" Controller.getItem
]