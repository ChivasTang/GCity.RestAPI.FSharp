namespace GCity.RestAPI.FSharp.Models

open System.ComponentModel.DataAnnotations.Schema
open System.ComponentModel.DataAnnotations
open System

[<CLIMutable; Table("UserAccount")>]
type UserAccount =
    { [<Key; Column("Id"); ForeignKey("UserProfileId")>]
      Id: Guid
      [<Required; MaxLength(64); Column("Username")>]
      Username: string
      [<Required; MaxLength(128); Column("Password")>]
      Password: string
      [<Required; Column("CreatedTime")>]
      CreatedTime: DateTime
      [<Required; Column("CreatedUserId")>]
      CreatedUserId: Guid
      [<Column("UpdatedTime")>]
      UpdatedTime: DateTime
      [<Column("UpdatedUserId")>]
      UpdatedUserId: Guid
      [<Column("Deleted")>]
      Deleted: int }
