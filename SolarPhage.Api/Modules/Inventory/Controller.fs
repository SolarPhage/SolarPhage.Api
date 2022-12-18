module Inventory.Controller

open Inventory.Types
open Falco

let updateInventory : HttpHandler = 
    let handleOk inventoryUpdate : HttpHandler = 
        Response.ofJson {
            CharacterId = 5
            ItemId = 5
            Amount = inventoryUpdate.Amount
            Cost = -100
         }

    Request.mapJson handleOk