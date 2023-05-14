namespace GCity.RestAPI.FSharp

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open GCity.RestAPI.FSharp.Domains

[<ApiController>]
[<Route("[controller]")>]
type LoginController(logger: ILogger<LoginController>) =
    inherit ControllerBase()

    [<HttpPost>]
    member _.Login() =
        logger.LogDebug "LoginController --- Login ---"
        ApiResult.SUCCESS("This is Login api...")
