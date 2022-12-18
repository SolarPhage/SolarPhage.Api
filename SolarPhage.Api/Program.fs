module ConfigurationBuilder.Program

open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Logging

/// App configuration, loaded on startup
let config = configuration [||] {
    required_json "appsettings.json"
    optional_json "appsettings.Development.json"
}

let getAllEndpoints = 
    List.concat [
        Character.Endpoints.getEndpoints
        Combat.Endpoints.getEndpoints
        Dungeon.Endpoints.getEndpoints
        Game.Endpoints.getEndpoints
        Item.Endpoints.getEndpoints
        Shop.Endpoints.getEndpoints
    ]

webHost [||] {
    logging (fun logging ->
        logging
            .ClearProviders()
            .AddSimpleConsole()
            .AddConfiguration(config)
    )

    endpoints getAllEndpoints
}