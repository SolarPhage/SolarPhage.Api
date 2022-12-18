module Inventory.Endpoints

open Falco.Routing

let getEndpoints = [
    put "/inventory" Controller.updateInventory
]