﻿namespace GCity.RestAPI.FSharp.Domains

open System

type ApiResult(code: int, message: string, timestamp: int64, data: 'T) =
    let mutable data = data
    let mutable code = code
    let mutable message = message
    let mutable timestamp = timestamp

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

    new(resCode: ResCode, data: 'T) =
        ApiResult(resCode.Code, resCode.Message, DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds(), data)

    static member SUCCESS(data: 'T) = ApiResult(ResCode.SUCCESS_RESULT, data)

    static member FAIL(resCode: ResCode) = ApiResult(resCode, null)

    static member FAIL(resCode: ResCode, data: 'T) = ApiResult(resCode, data)
