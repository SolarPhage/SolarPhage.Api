module Shop.Controller

open Item.Types
open Shop.Types
open Falco

let shopItem = {
    ItemInfo = {
        Id = 5
        Name = "Potion"
    }
    AmountForSale = 100
    CostPerItem = 5
}

let shopItems = [
    shopItem
    shopItem
    shopItem
    shopItem
    shopItem
    shopItem
    shopItem
    shopItem
    shopItem
    shopItem
    shopItem
    shopItem
    shopItem
]

let getAllShopItems : HttpHandler = 
    Response.ofJson shopItems