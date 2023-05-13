namespace GCity.RestAPI.FSharp

open System.ComponentModel.DataAnnotations.Schema
open System.ComponentModel.DataAnnotations
open System
open Microsoft.FSharp.Core


[<Table("UserProfile")>]
type UserProfile(id: Guid, locale: string) =
    [<Key; Column("Id")>]
    let mutable id = id

    [<Column("Localization"); Required>]
    let mutable locale = locale

    [<DefaultValue>]
    val mutable localization: Localization

    member this.Id
        with get () = id
        and set value = id <- value

    member this.Locale
        with get () = locale
        and set value =
            locale <- value
            this.localization <- Localization.Of(value)

    member this.Localization = this.localization
