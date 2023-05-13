namespace GCity.RestAPI.FSharp

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

    new() = ApiResult()

    new(data: 'T) =
        ApiResult(
            ResCode.SUCCESS_RESULT.Code,
            ResCode.SUCCESS_RESULT.Message,
            DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds(),
            data
        )

    new(resCode: ResCode) =
        ApiResult(resCode.Code, resCode.Message, DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds(), null)

    new(resCode: ResCode, data: 'T) =
        ApiResult(resCode.Code, resCode.Message, DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds(), data)

    static member SUCCESS(data: 'T) = ApiResult(data)

    static member FAIL(resCode: ResCode) = ApiResult(resCode)

    static member FAIL(resCode: ResCode, data: 'T) = ApiResult(resCode, data)
