namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Models

type UserProfileRepository(_context: ApiDbContext) =

    interface IUserProfileRepository with
        override this.GetById(userId: Guid) : UserProfile =
            query {
                for userProfile in _context.UserProfiles do
                    where (userProfile.Id = userId)
                    select userProfile
                    lastOrDefault
            }

        override this.Delete userProfile =
            _context.UserProfiles.Remove userProfile

        override this.Insert userProfile = _context.UserProfiles.Add userProfile

        override this.Update(userProfile) =
            _context.UserProfiles.Update userProfile
