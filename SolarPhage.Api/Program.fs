module SolarPhage.Api.Program

open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection

// ------------
// Exception Handler
// ------------
let exceptionHandler : HttpHandler =
    Response.withStatusCode 500 
    >> Response.ofPlainText "Server error"

[<EntryPoint>]
let main args =  
    let configureServices : IServiceCollection -> unit = 
        fun services -> services.AddFalco() |> ignore

    let configureApp : HttpEndpoint list -> IApplicationBuilder -> unit = 
        fun endpoints app -> app.UseFalco(endpoints) |> ignore

    let configureWebHost : HttpEndpoint list -> IWebHostBuilder -> IWebHostBuilder = 
        fun endpoints webhost -> webhost
                                                                        .ConfigureServices(configureServices)
                                                                        .Configure(configureApp endpoints)
                                                                        .UseUrls("http://*:9090")

    webHost [||] {
        use_if    FalcoExtensions.IsDevelopment DeveloperExceptionPageExtensions.UseDeveloperExceptionPage
        use_ifnot FalcoExtensions.IsDevelopment (FalcoExtensions.UseFalcoExceptionHandler exceptionHandler)
        
        configure configureWebHost

        endpoints [            
            get "/" (Response.ofPlainText "actions test")
        ]
    }
    0