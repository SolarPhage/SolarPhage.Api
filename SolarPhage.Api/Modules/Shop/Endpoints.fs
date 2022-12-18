module Shop.Endpoints

open Falco.Routing

let getEndpoints = [
    get "/shop" Controller.getAllShopItems
]