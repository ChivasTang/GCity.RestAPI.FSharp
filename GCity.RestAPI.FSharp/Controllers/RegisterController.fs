namespace GCity.RestAPI.FSharp

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("[controller]")>]
type RegisterController(logger: ILogger<RegisterController>) =
    inherit ControllerBase()

    [<HttpPost>]
    member _.Register() =
        logger.LogDebug "RegisterController --- Register ---"
        ApiResult.SUCCESS("This is register api...")
