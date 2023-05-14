namespace GCity.RestAPI.FSharp

type IUserRegisterService =
    abstract member Register: userRegister: UserRegister -> UserRegister
