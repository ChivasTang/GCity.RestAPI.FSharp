namespace GCity.RestAPI.FSharp

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("[controller]")>]
type RegisterController(logger: ILogger<RegisterController>, userRegisterService: IUserRegisterService) =
    inherit ControllerBase()

    [<HttpPost>]
    member _.Register() =
        logger.LogDebug "RegisterController --- Register ---"
        let userRegister = UserRegister("tangzh1983", "lipton1120", "lipton1120")
        let userRegister = userRegisterService.Register(userRegister)
        ApiResult.SUCCESS(userRegister)
