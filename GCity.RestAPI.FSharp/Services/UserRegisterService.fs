namespace GCity.RestAPI.FSharp.Services

open System
open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Repositories
open GCity.RestAPI.FSharp.Domains
open GCity.RestAPI.FSharp.Models

type UserRegisterService
    (
        _context: ApiDbContext,
        _userAccountRepository: IUserAccountRepository,
        _userProfileRepository: IUserProfileRepository
    ) =
    member this.Register(userAccount: UserAccount, userProfile: UserProfile) : int =
        _userAccountRepository.Insert userAccount |> ignore
        _userProfileRepository.Insert userProfile |> ignore
        _context.SaveChanges()

    member this.CheckExisted(username) : bool =
        let count = _userAccountRepository.CountByUsername username
        count > 0

    interface IUserRegisterService with
        override this.Register(userRegister) =
            let username = userRegister.Username.Trim()
            let password = userRegister.Password.Trim()
            let confirm = userRegister.Confirm.Trim()

            if userRegister.Equals null || username.Equals "" || username.Equals null then
                ResCode.REGISTER_USERNAME_NOT_INPUT
            elif password.Equals "" || password.Equals null then
                ResCode.REGISTER_PASSWORD_NOT_INPUT
            elif password <> confirm then
                ResCode.REGISTER_PASSWORD_NOT_CONFIRMED
            elif this.CheckExisted username then
                ResCode.REGISTER_USERNAME_EXISTED
            else
                let id = Guid.NewGuid()
                let timestamp = DateTime.Now

                let userAccount: UserAccount =
                    { Id = id
                      Username = userRegister.Username
                      Password = userRegister.Password
                      CreatedTime = timestamp
                      CreatedUserId = id
                      UpdatedTime = timestamp
                      UpdatedUserId = id
                      Deleted = DeleteFlag.EXISTING }

                let userProfile: UserProfile = { Id = id; LocaleCode = Locale.EN.Code }
                let saved = this.Register(userAccount, userProfile)

                if saved <> 2 then
                    ResCode.REGISTER_SAVE_FAILED
                else
                    ResCode.SUCCESS_RESULT
