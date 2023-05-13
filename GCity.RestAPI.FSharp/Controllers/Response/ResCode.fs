namespace GCity.RestAPI.FSharp


type ResCode =
    { Code: int
      Message: string }

    // OK
    static member SUCCESS_RESULT = { Code = 200; Message = "ok" }

    //Token
    static member INVALID_TOKEN = { Code = 6001; Message = "访问令牌不合法" }
    static member ACCESS_DENIED = { Code = 6002; Message = "没有权限访问该资源" }
    static member CLIENT_AUTH_FAILED = { Code = 6003; Message = "客户端认证失败" }

    //Login
    static member CREDENTIAL_BAD = { Code = 6101; Message = "用户名或密码错误" }
    static member UNSUPPORTED_GRANT_TYPE = { Code = 6102; Message = "不支持的认证模式" }
    static member USERNAME_NOT_INPUT = { Code = 6103; Message = "请输入用户名" }
    static member PASSWORD_NOT_INPUT = { Code = 6104; Message = "请输入密码" }

    static member USERNAME_NOT_EXIST =
        { Code = 6105
          Message = "未找到该用户，请检查并重新输入。" }

    static member USERNAME_PASSWORD_UNVALIDATED =
        { Code = 6106
          Message = "2次输入的密码不匹配，请检查并重新输入。" }

    // Register
    static member FAILED_USERNAME_NOT_INPUT = { Code = 6201; Message = "请填写用户名。" }
    static member FAILED_PASSWORD_NOT_INPUT = { Code = 6202; Message = "请填写密码。" }
    static member FAILED_PASSWORD_NOT_CONFIRMED = { Code = 6203; Message = "密码不一致。" }
    static member FAILED_USERNAME_EXISTED = { Code = 6204; Message = "该用户已经存在。" }
    static member FAILED_SAVED_INFO = { Code = 6205; Message = "该用户数据入库失败。" }
