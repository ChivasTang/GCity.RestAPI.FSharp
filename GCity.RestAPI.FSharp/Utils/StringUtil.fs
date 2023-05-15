namespace GCity.RestAPI.FSharp.StringUtil

type StringUtils =
    static member IsEmpty(str: string) : bool = str.Equals "" || str.Equals null
