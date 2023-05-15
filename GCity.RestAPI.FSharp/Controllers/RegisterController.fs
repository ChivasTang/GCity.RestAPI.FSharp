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
        let resCode: ResCode = userRegisterService.Register(_userRegister)

        if resCode <> ResCode.SUCCESS_RESULT then
            ApiResult.FAIL(resCode) |> ignore

        let userRegistered: UserRegister =
            { Username = _userRegister.Username
              Password = null
              Confirm = null }

        ApiResult.SUCCESS(userRegistered)
