namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Models

type IUserProfileRepository =
    abstract member GetById: userId: Guid -> UserProfile
