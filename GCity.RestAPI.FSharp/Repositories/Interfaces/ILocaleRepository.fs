namespace GCity.RestAPI.FSharp.Repositories

open GCity.RestAPI.FSharp.Models
open Microsoft.EntityFrameworkCore.ChangeTracking
open System.Collections.Generic

type ILocaleRepository =
    abstract member Insert: locale:Locale ->EntityEntry<Locale>
    abstract member Update: locale:Locale ->EntityEntry<Locale>
    abstract member Delete: locale:Locale ->EntityEntry<Locale>

    abstract member SelectByCode: code:string -> Locale
    abstract member SelectAll: unit -> IEnumerable<Locale>
    