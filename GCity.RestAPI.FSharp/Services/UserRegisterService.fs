namespace GCity.RestAPI.FSharp.Services

open System
open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Repositories
open GCity.RestAPI.FSharp.Domains
open GCity.RestAPI.FSharp.Models

type UserRegisterService(_context: ApiDbContext) =
    let mutable userAccountRepository: IUserAccountRepository =
        UserAccountRepository(_context)

    let mutable userProfileRepository: IUserProfileRepository =
        UserProfileRepository(_context)

    member this.UserAccountRepository
        with get () = userAccountRepository
        and set value = userAccountRepository <- value

    member this.UserProfileRepository
        with get () = userProfileRepository
        and set value = userProfileRepository <- value

    member this.Register(userAccount: UserAccount, userProfile: UserProfile) : int =
        userAccountRepository.Insert userAccount
        userProfileRepository.Insert userProfile
        _context.SaveChanges()


    interface IUserRegisterService with
        member this.Register(userRegister: UserRegister) : ResCode =
            if userRegister.Equals null then
                ResCode.REGISTER_USERNAME_NOT_INPUT |> ignore

            let username = userRegister.Username

            if username.Equals null then
                ResCode.REGISTER_USERNAME_NOT_INPUT |> ignore

            let password = userRegister.Password

            if password.Equals null then
                ResCode.REGISTER_PASSWORD_NOT_INPUT |> ignore

            let confirm = userRegister.Confirm

            if password <> confirm then
                ResCode.REGISTER_PASSWORD_NOT_CONFIRMED |> ignore

            let count = userAccountRepository.CountByUsername username

            if count > 0 then
                ResCode.REGISTER_USERNAME_EXISTED |> ignore

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

            let userProfile: UserProfile =
                { Id = id
                  Locale = Localization.EN.Code }

            let inserted = this.Register(userAccount, userProfile)

            if inserted = 0 then
                ResCode.REGISTER_SAVE_FAILED
            else
                ResCode.SUCCESS_RESULT
