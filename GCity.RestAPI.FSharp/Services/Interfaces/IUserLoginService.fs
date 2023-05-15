namespace GCity.RestAPI.FSharp.Services

open GCity.RestAPI.FSharp.Domains

type IUserLoginService =
    abstract member Login: userLogin: UserLogin -> ResCode
