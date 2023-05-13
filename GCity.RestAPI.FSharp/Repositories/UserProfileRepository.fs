namespace GCity.RestAPI.FSharp

open System

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
