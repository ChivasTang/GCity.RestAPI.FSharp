namespace GCity.RestAPI.FSharp.Domains

type UserLogin =
    {
        Username: string
        Password: string
        IsRemember: bool
    }