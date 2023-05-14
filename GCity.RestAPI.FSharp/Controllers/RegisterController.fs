namespace GCity.RestAPI.FSharp

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open GCity.RestAPI.FSharp.Services
open GCity.RestAPI.FSharp.Domains

[<ApiController>]
[<Route("[controller]")>]
type RegisterController(logger: ILogger<RegisterController>, userRegisterService: IUserRegisterService) =
    inherit ControllerBase()

    [<HttpPost>]
    member _.Register([<FromBody>] _userRegister: UserRegister) =
        logger.LogDebug "RegisterController --- Register ---"
        let userRegister = userRegisterService.Register(_userRegister)
        ApiResult.SUCCESS(userRegister)
