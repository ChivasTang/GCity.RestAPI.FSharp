namespace GCity.RestAPI.FSharp

open Microsoft.EntityFrameworkCore
open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Repositories
open GCity.RestAPI.FSharp.Services
open System
open Microsoft.AspNetCore.Authentication.JwtBearer
open Microsoft.IdentityModel.Tokens
open System.Text
open GCity.RestAPI.FSharp.Utils

#nowarn "20"

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)
        
        // AppSettings
        let configurationBuilder =
            ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json", false, true)
                .AddEnvironmentVariables()
                .Build()

        // DbContext
        let connectionString = configurationBuilder.GetConnectionString("MSSQLSERVER")

        //let version = Version "8.0.32"
        //let serverVersion = ServerVersion.Create (version, ServerType.MySql)

        builder.Services.AddDbContext<ApiDbContext>(fun (options: DbContextOptionsBuilder) ->
            options.UseSqlServer(connectionString).EnableSensitiveDataLogging() |> ignore)
        |> ignore

        // Add AutoMapper
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())

        // Add Authentication
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(fun options ->
            options.TokenValidationParameters<-TokenValidationParameters(
                IssuerSigningKey = JwtUtil.SECURITY_KEY,
                ValidIssuer = JwtUtil.ISSUER,
                ValidAudience = JwtUtil.AUDIENCE,
                ValidateActor = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            ))|>ignore
        // Add Cors
        builder.Services.AddCors()

        // Add Repositories
        builder.Services.AddTransient<ILocaleRepository, LocaleRepository>()
        builder.Services.AddTransient<IUserAccountRepository, UserAccountRepository>()
        builder.Services.AddTransient<IUserProfileRepository, UserProfileRepository>()

        // Add Services
        builder.Services.AddTransient<IUserLoginService, UserLoginService>()
        builder.Services.AddTransient<IUserRegisterService, UserRegisterService>()

        // Add Controller
        builder.Services.AddControllers()

        let app = builder.Build()

        app.UseHttpsRedirection()
        app.UseCors()
        app.UseAuthorization()
        app.MapControllers()
        
        app.Run()

        exitCode
