namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Models

type UserProfileRepository(_context: ApiDbContext) =
    let context = _context

    interface IUserProfileRepository with
        override this.GetById(userId: Guid) : UserProfile =
            query {
                for userProfile in context.UserProfiles do
                    where (userProfile.Id = userId)
                    select userProfile
                    lastOrDefault
            }

        override this.Delete userProfile =
            context.UserProfiles.Remove userProfile |> ignore

        override this.Insert userProfile =
            context.UserProfiles.Add userProfile |> ignore

        override this.Update(userProfile) =
            context.UserProfiles.Update userProfile |> ignore
