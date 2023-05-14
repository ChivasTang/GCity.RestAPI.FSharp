namespace GCity.RestAPI.FSharp

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open GCity.RestAPI.FSharp.Domains

[<ApiController>]
[<Route("[controller]"); Route("")>]
type IndexController(logger: ILogger<IndexController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Index() =
        logger.LogDebug "IndexController ==== Index.Get ===="
        //ApiResult.SUCCESS("this is index page...")
        ApiResult.FAIL(ResCode.LOGIN_USERNAME_PASSWORD_UNVALIDATED)
