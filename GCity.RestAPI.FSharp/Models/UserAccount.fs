namespace GCity.RestAPI.FSharp

open System.ComponentModel.DataAnnotations.Schema
open System.ComponentModel.DataAnnotations
open System

[<Table("USER_ACCOUNT"); CLIMutable>]
type UserAccount =
    { [<Key>]
      Id: Guid
      [<Required>]
      [<MaxLength(64)>]
      Username: string
      [<Required>]
      [<MaxLength(128)>]
      Password: string
      [<Required>]
      CreatedTime: DateTime
      [<Required>]
      CreatedUserId: Guid
      UpdatedTime: DateTime
      UpdatedUserId: Guid
      Deleted: DeleteFlag }
