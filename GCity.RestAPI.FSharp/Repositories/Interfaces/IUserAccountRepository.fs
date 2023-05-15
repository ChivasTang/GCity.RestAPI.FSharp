namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Models
open Microsoft.EntityFrameworkCore.ChangeTracking

type IUserAccountRepository =
    abstract member SelectByUsername: username: string -> UserAccount
    abstract member SelectById: userId: Guid -> UserAccount
    abstract member CountByUsername: username: string -> int
    abstract member Insert: UserAccount: UserAccount -> EntityEntry<UserAccount>
    abstract member ChangeUserName: userAccount: UserAccount -> EntityEntry<UserAccount>
    abstract member Delete: userAccount: UserAccount -> EntityEntry<UserAccount>
