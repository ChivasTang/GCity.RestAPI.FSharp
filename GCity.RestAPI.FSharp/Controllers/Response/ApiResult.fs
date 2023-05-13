namespace GCity.RestAPI.FSharp

open System

type ApiResult(code: int, message: string, timestamp: int64, data: 'T) =

    let mutable data: 'T = data
    let mutable code: int = code
    let mutable message: string = message

    let mutable timestamp: int64 = timestamp
    new() = ApiResult()

    new(resCode: ResCode) =
        ApiResult(resCode.Code, resCode.Message, DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds(), null)

    new(resCode: ResCode, data: 'T) =
        ApiResult(resCode.Code, resCode.Message, DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds(), data)

    member this.Data
        with get () = data
        and set value = data <- value

    member this.Code
        with get () = code
        and set value = code <- value

    member this.Message
        with get () = message
        and set value = message <- value

    member this.Timestamp
        with get () = timestamp
        and set value = timestamp <- value

    static member SUCCESS(data: 'T) = ApiResult(ResCode.SUCCESS_RESULT, data)

    static member FAILED(resCode: ResCode) = ApiResult(resCode, null)
