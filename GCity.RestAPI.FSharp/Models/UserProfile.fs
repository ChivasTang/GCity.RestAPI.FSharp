namespace GCity.RestAPI.FSharp

open System.ComponentModel.DataAnnotations.Schema
open System.ComponentModel.DataAnnotations
open System


[<Table("USER_PROFILE")>]
type UserProfile
    (
        id: Guid,
        localizationId: string,
        country: string,
        level1: string,
        level2: string,
        level3: string,
        level4: string,
        level5: string,
        postCode: string,
        address: string
    ) =
    [<Key; Column("ID")>]
    let mutable id = id

    [<Column("COUNTRY"); Required; MaxLength(128)>]
    let mutable country = country

    [<Column("LEVEL1"); Required; MaxLength(128)>]
    let mutable level1 = level1

    [<Column("LEVEL2"); Required; MaxLength(128)>]
    let mutable level2 = level2

    [<Column("LEVEL3"); Required; MaxLength(128)>]
    let mutable level3 = level3

    [<Column("LEVEL4"); Required; MaxLength(128)>]
    let mutable level4 = level4

    [<Column("LEVEL5"); Required; MaxLength(128)>]
    let mutable level5 = level5

    [<Column("POST_CODE"); Required; MaxLength(128)>]
    let mutable postCode = postCode

    [<Column("ADDRESS"); Required; MaxLength(1024)>]
    let mutable address = address

    [<Column("LOCALIZATION"); Required; ForeignKey("LOCALIZATION_ID")>]
    let mutable localizationId = localizationId

    new(id: Guid,
        localization: Localization,
        country: string,
        level1: string,
        level2: string,
        level3: string,
        level4: string,
        level5: string,
        postCode: string,
        address: string) =
        UserProfile(id, localization, country, level1, level2, level3, level4, level5, postCode, address)

    member this.Id
        with get () = id
        and set value = id <- value

    member this.LocalizationId
        with get () = localizationId
        and set value = localizationId <- value

    member this.Country
        with get () = country
        and set value = country <- value

    member this.Level1
        with get () = level1
        and set value = level1 <- value

    member this.Level2
        with get () = level2
        and set value = level2 <- value

    member this.Level3
        with get () = level3
        and set value = level3 <- value

    member this.Level4
        with get () = level4
        and set value = level4 <- value

    member this.Level5
        with get () = level5
        and set value = level5 <- value

    member this.PostCode
        with get () = postCode
        and set value = postCode <- value

    member this.Address
        with get () = address
        and set value = address <- value
