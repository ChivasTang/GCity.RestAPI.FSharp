namespace GCity.RestAPI.FSharp

open Microsoft.EntityFrameworkCore

type ApiDbContext(options: DbContextOptions<ApiDbContext>) =
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable UserAccounts: DbSet<UserAccount>

    [<DefaultValue>]
    val mutable UserProfiles: DbSet<UserProfile>

    member this._UserAccounts
        with get () = this.UserAccounts
        and set value = this.UserAccounts <- value

    member this._UserProfiles
        with get () = this.UserProfiles
        and set value = this.UserProfiles <- value

    override _.OnModelCreating(modelBuilder: ModelBuilder) = base.OnModelCreating(modelBuilder)
