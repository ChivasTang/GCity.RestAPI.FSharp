namespace GCity.RestAPI.FSharp

open System

type IUserProfileRepository =
    abstract member GetById: userId: Guid -> UserProfile
