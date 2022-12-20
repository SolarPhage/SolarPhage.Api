module ConfigurationBuilder.Program

open Falco.HostBuilder
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Builder

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

    add_service (fun svc -> 
                    svc.AddCors(fun o -> 
                        o.AddPolicy(name = "solarphage", configurePolicy = fun policy -> 
                            policy.WithOrigins("*") |> ignore)))
    
    use_middleware (fun app -> app.UseCors("solarphage"))

    endpoints getAllEndpoints
}