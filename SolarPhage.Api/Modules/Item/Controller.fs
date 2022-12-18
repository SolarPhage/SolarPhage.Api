module Item.Controller

open Item.Types
open Falco

let getItem : HttpHandler = 
    Request.mapRoute (fun r -> 
        let id = r.GetInt("itemId")
        { Id = id; Name = "potion"; })
        Response.ofJson
