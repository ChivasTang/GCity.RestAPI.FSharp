namespace GCity.RestAPI.FSharp

open System.ComponentModel.DataAnnotations.Schema
open System.ComponentModel.DataAnnotations
open System


[<Table("USER_PROFILE"); CLIMutable>]
type UserProfile =
    { [<Key>]
      UserId: Guid
      [<Column("LOCALIZATION"); Required>]
      Localization: Localization
      [<Column("COUNTRY"); Required; MaxLength(128)>]
      Country: string
      [<Column("LEVEL1"); Required; MaxLength(128)>]
      Level1: string
      [<Column("LEVEL2"); Required; MaxLength(128)>]
      Level2: string
      [<Column("LEVEL3"); Required; MaxLength(128)>]
      Level3: string
      [<Column("LEVEL4"); Required; MaxLength(128)>]
      Level4: string
      [<Column("LEVEL5"); Required; MaxLength(128)>]
      Level5: string
      [<Column("POST_CODE"); Required; MaxLength(128)>]
      PostCode: string
      [<Column("ADDRESS"); Required; MaxLength(128)>]
      Address: string }
