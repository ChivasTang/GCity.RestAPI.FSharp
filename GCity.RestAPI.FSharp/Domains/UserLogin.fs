namespace GCity.RestAPI.FSharp.Domains

type UserLogin(username: string, password: string, isRemember: bool) =
    let mutable username: string = username
    let mutable password: string = password
    let mutable isRemember: bool = isRemember
    new() = UserLogin()

    member this.Username
        with get () = username
        and set value = username <- value

    member this.Password
        with get () = password
        and set value = password <- value

    member this.IsRemember
        with get () = isRemember
        and set value = isRemember <- value
