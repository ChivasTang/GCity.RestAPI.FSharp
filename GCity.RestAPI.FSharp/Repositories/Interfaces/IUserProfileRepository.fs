namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Models
open Microsoft.EntityFrameworkCore.ChangeTracking

type IUserProfileRepository =
    abstract member SelectById: userId: Guid -> UserProfile
    abstract member Insert: userProfile: UserProfile -> EntityEntry<UserProfile>
    abstract member Update: userProfile: UserProfile -> EntityEntry<UserProfile>
    abstract member Delete: userProfile: UserProfile -> EntityEntry<UserProfile>
