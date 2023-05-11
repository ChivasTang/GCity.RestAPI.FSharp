namespace GCity.RestAPI.FSharp
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("[controller]");Route("")>]
type IndexController(logger : ILogger<IndexController>) =
    inherit ControllerBase()

    member _.Index() =
        "This is Index Page"