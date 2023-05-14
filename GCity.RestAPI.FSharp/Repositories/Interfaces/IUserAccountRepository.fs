namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Models

type IUserAccountRepository =
    abstract member GetByUsername: username: string -> UserAccount
    abstract member GetById: userId: Guid -> UserAccount
    abstract member CountByUsername: username: string -> int
    abstract member Insert: UserAccount: UserAccount -> unit
    abstract member ChangeUserName: userAccount: UserAccount -> unit
    abstract member Delete: userAccount: UserAccount -> unit
