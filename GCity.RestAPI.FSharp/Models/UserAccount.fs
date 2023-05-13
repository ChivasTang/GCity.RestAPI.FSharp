namespace GCity.RestAPI.FSharp

open System.ComponentModel.DataAnnotations.Schema
open System.ComponentModel.DataAnnotations
open System

[<Table("USER_ACCOUNT")>]
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
    [<Key; Column("ID"); ForeignKey("USER_PROFILE_ID")>]
    let mutable id = id

    [<Required; MaxLength(64); Column("USERNAME")>]
    let mutable username = username

    [<Required; MaxLength(128); Column("PASSWORD")>]
    let mutable password = password

    [<Required; Column("CREATED_TIME")>]
    let mutable createdTime = createdTime

    [<Required; Column("CREATED_USER_ID")>]
    let mutable createdUserId = createdUserId

    [<Column("UPDATED_TIME")>]
    let mutable updatedTime = updatedTime

    [<Column("UPDATED_USER_ID")>]
    let mutable updatedUserId = updatedUserId

    [<Column("DELETED")>]
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
