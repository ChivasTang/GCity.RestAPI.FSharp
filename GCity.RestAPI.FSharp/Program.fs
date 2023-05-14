namespace GCity.RestAPI.FSharp

open Microsoft.EntityFrameworkCore
open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Repositories
open GCity.RestAPI.FSharp.Services

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
        // Add Repositories
        builder.Services.AddTransient<IUserAccountRepository, UserAccountRepository>()
        builder.Services.AddTransient<IUserProfileRepository, UserProfileRepository>()

        // Add Services
        builder.Services.AddTransient<IUserRegisterService, UserRegisterService>()

        // Add Controller
        builder.Services.AddControllers()

        let app = builder.Build()

        app.UseHttpsRedirection()

        app.UseAuthorization()
        app.MapControllers()

        app.Run()

        exitCode
