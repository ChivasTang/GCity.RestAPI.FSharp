namespace GCity.RestAPI.FSharp

// 举例说明：Code:ja Name:Japanese Native:日本語 MsCode:ja-jp GgCode:ja_jp
type Localization =
    { Code: string
      Name: string
      Native: string
      MsCode: string
      GgCode: string }

    static member JA =
        { Code = "ja"
          Name = "Japanese"
          Native = "日本語"
          MsCode = "ja-JP"
          GgCode = "ja_JP" }

    static member EN =
        { Code = "en"
          Name = "English"
          Native = "English"
          MsCode = "en"
          GgCode = "en" }

    static member ZH_CN =
        { Code = "zh-cn"
          Name = "Chinese Simplified"
          Native = "中文简体"
          MsCode = "zh-CN"
          GgCode = "zh_CN" }

    static member ZH_TW =
        { Code = "zh"
          Name = "Chinese Traditional"
          Native = "ZHON"
          MsCode = "ja-JP"
          GgCode = "ja_JP" }
