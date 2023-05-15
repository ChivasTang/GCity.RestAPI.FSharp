namespace GCity.RestAPI.FSharp.Models

open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema
open Microsoft.FSharp.Core

// 举例说明：Code:ja Name:Japanese Native:日本語 MsCode:ja-jp GgCode:ja_jp
[<CLIMutable; Table("Locale")>]
type Locale =
    { [<Key; MaxLength(64); Column("Code")>]
      Code: string
      [<Required; MaxLength(64); Column("Name")>]
      Name: string
      [<Required; MaxLength(64); Column("Native")>]
      Native: string
      [<Required; MaxLength(64); Column("MsLangCode")>]
      MsLangCode: string
      [<Required; MaxLength(64); Column("GgLangCode")>]
      GgLangCode: string }

    static member EN =
        { Code = "en"
          Name = "English"
          Native = "English"
          MsLangCode = "en"
          GgLangCode = "en" }

    static member JA =
        { Code = "ja"
          Name = "Japanese"
          Native = "日本語"
          MsLangCode = "ja_JP"
          GgLangCode = "ja-JP" }

    static member ZH_CN =
        { Code = "zh-CN"
          Name = "Simplified Chinese"
          Native = "中文(简体)"
          MsLangCode = "zh_CN"
          GgLangCode = "zh-CN" }

    static member ZH_TW =
        { Code = "zh-TW"
          Name = "Traditional Chinese"
          Native = "中文(繁体)"
          MsLangCode = "zh_TW"
          GgLangCode = "zh-TW" }

    static member Of(code: string) =
        match code with
        | "en" -> Locale.EN
        | "ja" -> Locale.JA
        | "zh-CN" -> Locale.ZH_CN
        | "zh-tw" -> Locale.ZH_TW
        | _ -> Locale.EN
