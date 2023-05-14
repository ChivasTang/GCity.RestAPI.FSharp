namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Models

type IUserProfileRepository =
    abstract member GetById: userId: Guid -> UserProfile
    abstract member Insert: userProfile: UserProfile -> unit
    abstract member Update: userProfile: UserProfile -> unit
    abstract member Delete: userProfile: UserProfile -> unit
