namespace GCity.RestAPI.FSharp.Services

open GCity.RestAPI.FSharp.Domains

type IUserRegisterService =
    abstract member Register: userRegister: UserRegister -> UserRegister
