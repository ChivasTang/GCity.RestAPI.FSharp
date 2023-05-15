namespace GCity.RestAPI.FSharp

open GCity.RestAPI.FSharp.Services
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open GCity.RestAPI.FSharp.Domains

[<ApiController>]
[<Route("[controller]")>]
type LoginController(logger: ILogger<LoginController>, _userLoginService: IUserLoginService) =
    inherit ControllerBase()

    [<HttpPost>]
    member _.Login([<FromBody>] _userLogin: UserLogin) =
        logger.LogDebug "LoginController --- Login ---"
        let resCode = _userLoginService.Login _userLogin

        if resCode <> ResCode.SUCCESS_RESULT then
            ApiResult.FAIL(resCode)
        else
            let login: UserLogin =
                { Username = _userLogin.Username
                  Password = null
                  IsRemember = true }

            ApiResult.SUCCESS(login)
