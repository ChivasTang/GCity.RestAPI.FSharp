namespace GCity.RestAPI.FSharp.Domains

type UserRegister(username: string, password: string, confirm: string) =
    let mutable username = username
    let mutable password = password
    let mutable confirm = confirm

    member this.Username
        with get () = username
        and set value = username <- value

    member this.Password
        with get () = password
        and set value = password <- value

    member this.Confirm
        with get () = confirm
        and set value = confirm <- value
