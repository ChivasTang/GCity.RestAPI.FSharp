namespace GCity.RestAPI.FSharp.Utils

open System.IdentityModel.Tokens.Jwt
open System
open System.Security.Claims
open Microsoft.IdentityModel.Tokens
open System.Text
open System.Collections.Generic


type JwtUtil =
    static member SECRET_KEY:string = "pleaseReplaceWithYourSecretKeyRetrievedFromSomeSecureLocation"
    static member ISSUER:string = "https://certificateissuer.example.com/"
    static member AUDIENCE:string = "https://backendserver.example.com"
    static member ALGORITHM:string = SecurityAlgorithms.HmacSha256;
    static member SECURITY_KEY:SymmetricSecurityKey = SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtUtil.SECRET_KEY))
    static member SIGNING_CREDENTIALS:SigningCredentials = SigningCredentials(key = JwtUtil.SECURITY_KEY, algorithm = JwtUtil.ALGORITHM)
    static member EXPIRES:Nullable<DateTime> = Nullable(DateTime.UtcNow.AddHours(24.0))
    static member NOT_BEFORE:Nullable<DateTime> = Nullable(DateTime.UtcNow)
    static member GetClaimsByUserId(userId:Guid): IEnumerable<Claim>= [|
            Claim(JwtRegisteredClaimNames.Sub, userId.ToString());
            Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
        |]
    static member Generate(userId:Guid):string =
        JwtSecurityTokenHandler().WriteToken(JwtSecurityToken(
                issuer = JwtUtil.ISSUER,
                audience = JwtUtil.AUDIENCE,
                claims = JwtUtil.GetClaimsByUserId userId,
                expires = JwtUtil.EXPIRES,
                notBefore = JwtUtil.NOT_BEFORE,
                signingCredentials = JwtUtil.SIGNING_CREDENTIALS))