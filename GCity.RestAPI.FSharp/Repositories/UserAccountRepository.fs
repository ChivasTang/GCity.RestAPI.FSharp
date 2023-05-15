namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Models
open Microsoft.EntityFrameworkCore.ChangeTracking

type UserAccountRepository(_context: ApiDbContext) =

    interface IUserAccountRepository with
        override this.ChangeUserName(userAccount: UserAccount) : EntityEntry<UserAccount> =
            _context.UserAccounts.Update(userAccount)


        override this.Delete(userAccount: UserAccount) : EntityEntry<UserAccount> =
            _context.UserAccounts.Remove(userAccount)


        override this.Insert(userAccount: UserAccount) : EntityEntry<UserAccount> =
            _context.UserAccounts.Add(userAccount)



        override this.GetByUsername(username: string) : UserAccount =
            query {
                for userAccount in _context.UserAccounts do
                    where (userAccount.Username = username)
                    select userAccount
                    exactlyOneOrDefault
            }

        override this.GetById(userId: Guid) : UserAccount =
            query {
                for userAccount in _context.UserAccounts do
                    where (userAccount.Id = userId)
                    select userAccount
                    exactlyOneOrDefault
            }

        override this.CountByUsername(username: string) : int =
            query {
                for userAccount in _context.UserAccounts do
                    where (userAccount.Username = username)
                    count
            }
