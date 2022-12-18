module Combat.Controller

open Combat.Types
open Falco

let getState : HttpHandler = 
    Request.mapRoute (fun r -> 
        let id = r.GetInt("combatId")
        { CombatId = id; PlayerHp = 100 })
        Response.ofJson

let updateState : HttpHandler = 
    let handleOk combatState : HttpHandler = 
        Response.ofJson {|
            CombatId = combatState.CombatId
            PlayerHp = combatState.PlayerHp
        |}

    Request.mapJson handleOk