namespace GCity.RestAPI.FSharp

open System.ComponentModel.DataAnnotations.Schema
open System.ComponentModel.DataAnnotations
open System
open Microsoft.FSharp.Core

[<Table("UserProfile"); CLIMutable>]
type UserProfile =
    { [<Key; Column("Id")>]
      Id: Guid
      [<Column("Locale"); Required>]
      Locale: string }
