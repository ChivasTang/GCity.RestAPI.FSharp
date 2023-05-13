namespace GCity.RestAPI.FSharp

open System.ComponentModel.DataAnnotations.Schema
open System.ComponentModel.DataAnnotations
open System

[<Table("UserAccount")>]
type UserAccount
    (
        id: Guid,
        username: string,
        password: string,
        createdTime: DateTime,
        createdUserId: Guid,
        updatedTime: DateTime,
        updatedUserId: Guid,
        deleted: DeleteFlag
    ) =
    [<Key; Column("Id"); ForeignKey("UserProfileId")>]
    let mutable id = id

    [<Required; MaxLength(64); Column("Username")>]
    let mutable username = username

    [<Required; MaxLength(128); Column("Password")>]
    let mutable password = password

    [<Required; Column("CreatedTime")>]
    let mutable createdTime = createdTime

    [<Required; Column("CreatedUserId")>]
    let mutable createdUserId = createdUserId

    [<Column("UpdatedTime")>]
    let mutable updatedTime = updatedTime

    [<Column("UpdatedUserId")>]
    let mutable updatedUserId = updatedUserId

    [<Column("Deleted")>]
    let mutable deleted = deleted

    new() = UserAccount()

    new(id: Guid,
        username: string,
        password: string,
        createdTime: DateTime,
        createdUserId: Guid,
        updatedTime: DateTime,
        updatedUserId: Guid,
        deleted: int) =
        UserAccount(
            id,
            username,
            password,
            createdTime,
            createdUserId,
            updatedTime,
            updatedUserId,
            enum<DeleteFlag> (deleted)
        )

    member this.Id
        with get () = id
        and set value = id <- value

    member this.Username
        with get () = username
        and set value = username <- value

    member this.Password
        with get () = password
        and set value = password <- value

    member this.CreatedTime
        with get () = createdTime
        and set value = createdTime <- value

    member this.CreatedUserId
        with get () = createdUserId
        and set value = createdUserId <- value

    member this.UpdatedTime
        with get () = updatedTime
        and set value = updatedTime <- value

    member this.UpdatedUserId
        with get () = updatedUserId
        and set value = updatedUserId <- value

    member this.Deleted
        with get () = deleted
        and set value = deleted <- value
