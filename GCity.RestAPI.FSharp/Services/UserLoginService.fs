namespace GCity.RestAPI.FSharp.Services

open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Domains
open GCity.RestAPI.FSharp.Models
open GCity.RestAPI.FSharp.Repositories
open GCity.RestAPI.FSharp.Utils

type UserLoginService
    (
        _context: ApiDbContext,
        _userAccountRepository: IUserAccountRepository,
        _userProfileRepository: IUserProfileRepository
    ) =
    member this.LoadUserByUsername(username: string) : UserAccount =
        _userAccountRepository.SelectByUsername username

    interface IUserLoginService with
        override this.Login(userLogin) =
            let username = userLogin.Username.Trim()
            let password = userLogin.Password.Trim()

            if userLogin.Equals null || StringUtil.IsEmpty username then
                ResCode.LOGIN_USERNAME_NOT_EXIST
            elif StringUtil.IsEmpty password then
                ResCode.LOGIN_PASSWORD_NOT_INPUT
            else
                let userAccount = this.LoadUserByUsername username

                if password <> userAccount.Password then
                    ResCode.LOGIN_CREDENTIAL_BAD
                else
                    ResCode.SUCCESS_RESULT
