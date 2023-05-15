namespace GCity.RestAPI.FSharp.Utils

type StringUtil =
    static member IsEmpty(str: string) : bool = str.Equals "" || str.Equals null
