namespace GCity.RestAPI.FSharp

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open System

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController (logger : ILogger<WeatherForecastController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.WeatherForecast() =
        let rng = Random()
        "this is weather forecast page..."