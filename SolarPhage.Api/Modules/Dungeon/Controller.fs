module Dungeon.Controller
open System
open Dungeon.Types
open Falco

let getDungeon : HttpHandler = 
    Request.mapRoute (fun r -> 
        let id = r.GetInt("dungeonId")
        { Level = id })
        Response.ofJson

let createDungeon : HttpHandler = 
    let handleOk dungeon : HttpHandler = 
        Response.ofJson dungeon.Level

    Request.mapJson handleOk
