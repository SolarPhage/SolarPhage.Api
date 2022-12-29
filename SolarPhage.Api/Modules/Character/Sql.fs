module Character.Sql

open Character.Types
open Dapper.FSharp.MSSQL
open System.Data.SqlClient
open System

let conn  =
    new SqlConnection ""

let characterTable = table'<CharacterReadSql> "Characters"

let getCharactersByUserId (id : string) = 
    select {
        for c in characterTable do
        where (c.UserId = id)
    } |> conn.SelectAsync<CharacterReadSql> 
        |> Async.AwaitTask
        |> Async.RunSynchronously

let insertCharacter (character : CharacterWriteSql) = 
    insert {
        into  (table'<CharacterWriteSql> "Characters")
        value character
    } |> conn.InsertAsync
        |> Async.AwaitTask
        |> Async.RunSynchronously