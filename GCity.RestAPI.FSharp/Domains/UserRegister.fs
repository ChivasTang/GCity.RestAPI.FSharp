namespace GCity.RestAPI.FSharp

type UserRegister(username: string, password: string, confirm: string) =
    let mutable username: string = username
    let mutable password: string = password
    let mutable confirm: string = confirm

    new() = UserRegister()

    member this.Username
        with get () = username
        and set value = username <- value

    member this.Password
        with get () = password
        and set value = password <- value

    member this.Confirm
        with get () = confirm
        and set value = confirm <- value
