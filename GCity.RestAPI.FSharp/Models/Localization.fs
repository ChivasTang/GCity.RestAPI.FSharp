namespace GCity.RestAPI.FSharp

// 举例说明：Code:ja Name:Japanese Native:日本語 MsCode:ja-jp GgCode:ja_jp
type Localization(code: string, name: string, native: string, msCode: string, ggCode: string) =
    let mutable code = code
    let mutable name = name
    let mutable native = native
    let mutable msCode = msCode
    let mutable ggCode = ggCode

    member this.Code
        with get () = code
        and set value = code <- value

    member this.Name
        with get () = name
        and set value = name <- value

    member this.Native
        with get () = native
        and set value = native <- value

    member this.MsCode
        with get () = msCode
        and set value = msCode <- value

    member this.GgCode
        with get () = ggCode
        and set value = ggCode <- value

    static member JA = Localization("ja", "Japanese", "日本語", "ja-JP", "ja_JP")
    static member EN = Localization("en", "English", "English", "en", "en")
    static member ZH_CN = Localization("zh-CN", "Chinese Simplified", "中文简体", "zh-CN", "zh_CN")
    static member ZH_TW = Localization("zh-TW", "Chinese Traditional", "中文繁体", "zh-TW", "zh_TW")

    static member Of(code: string) : Localization =
        match code with
        | "ja" -> Localization.JA
        | "en" -> Localization.EN
        | "zh-CN" -> Localization.ZH_CN
        | "zh-TW" -> Localization.ZH_TW
        | _ -> Localization.EN
