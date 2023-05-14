namespace GCity.RestAPI.FSharp

type IUserLoginService =
    abstract member Login: userLogin: UserLogin -> UserLogin
