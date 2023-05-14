namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Models

type UserProfileRepository(_context: ApiDbContext) =
    let userProfiles = _context.UserProfiles

    interface IUserProfileRepository with
        override this.GetById(userId: Guid) : UserProfile =
            query {
                for userProfile in userProfiles do
                    where (userProfile.Id = userId)
                    select userProfile
                    lastOrDefault
            }
