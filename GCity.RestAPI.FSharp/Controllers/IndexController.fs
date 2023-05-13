namespace GCity.RestAPI.FSharp

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("[controller]"); Route("")>]
type IndexController(logger: ILogger<IndexController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Index() =
        logger.LogDebug "IndexController ==== Index.Get ===="
        ApiResult.FAILED(ResCode.ACCESS_DENIED)
