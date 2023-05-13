namespace GCity.RestAPI.FSharp

open Microsoft.EntityFrameworkCore.ChangeTracking

type UserAccountRepository(_context: ApiDbContext) =
    let userAccounts = _context.UserAccounts

    interface IUserAccountRepository with
        override this.ChangeUserName(userAccount: UserAccount) : EntityEntry<UserAccount> =
            userAccounts.Update(userAccount)

        override this.Delete(userAccount: UserAccount) : EntityEntry<UserAccount> = userAccounts.Remove(userAccount)

        override this.Insert(userAccount: UserAccount) : EntityEntry<UserAccount> = userAccounts.Add(userAccount)

        override this.GetByUsername(username: string) : UserAccount =
            query {
                for userAccount in userAccounts do
                    where (userAccount.Username = username)
                    select userAccount
                    lastOrDefault
            }

        override this.GetById(userId: System.Guid) : UserAccount =
            query {
                for userAccount in userAccounts do
                    where (userAccount.Id = userId)
                    select userAccount
                    lastOrDefault
            }

        override this.CountByUsername(username: string) : int =
            query {
                for userAccount in userAccounts do
                    where (userAccount.Username = username)
                    count
            }
