namespace GCity.RestAPI.FSharp.Models

open System.ComponentModel.DataAnnotations.Schema
open System.ComponentModel.DataAnnotations
open System
open Microsoft.FSharp.Core

[<CLIMutable; Table("UserProfile")>]
type UserProfile =
    { [<Key; Column("Id")>]
      Id: Guid
      [<Column("Locale"); Required>]
      Locale: string }
