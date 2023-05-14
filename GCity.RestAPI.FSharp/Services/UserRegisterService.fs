namespace GCity.RestAPI.FSharp

open System

type UserRegisterService(userAccountRepository: IUserAccountRepository, userProfileRepository: IUserProfileRepository) =
    let mutable userAccountRepository = userAccountRepository
    let mutable userProfileRepository = userProfileRepository

    member this.UserAccountRepository
        with get () = userAccountRepository
        and set value = userAccountRepository <- value

    member this.UserProfileRepository
        with get () = userProfileRepository
        and set value = userProfileRepository <- value

    interface IUserRegisterService with
        member this.Register(userRegister: UserRegister) : UserRegister =

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

            userAccountRepository.Insert(userAccount) |> ignore
            userRegister.Password <- null
            userRegister
