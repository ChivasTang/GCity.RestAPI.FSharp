namespace GCity.RestAPI.FSharp.Repositories

open System
open GCity.RestAPI.FSharp.Database
open GCity.RestAPI.FSharp.Models

type UserAccountRepository(_context: ApiDbContext) =
    let mutable context = _context

    interface IUserAccountRepository with
        override this.ChangeUserName(userAccount: UserAccount) : unit =
            context.UserAccounts.Update(userAccount) |> ignore


        override this.Delete(userAccount: UserAccount) : unit =
            context.UserAccounts.Remove(userAccount) |> ignore


        override this.Insert(userAccount: UserAccount) : unit =
            context.UserAccounts.Add(userAccount) |> ignore



        override this.GetByUsername(username: string) : UserAccount =
            query {
                for userAccount in context.UserAccounts do
                    where (userAccount.Username = username)
                    select userAccount
                    lastOrDefault
            }

        override this.GetById(userId: Guid) : UserAccount =
            query {
                for userAccount in context.UserAccounts do
                    where (userAccount.Id = userId)
                    select userAccount
                    lastOrDefault
            }

        override this.CountByUsername(username: string) : int =
            query {
                for userAccount in context.UserAccounts do
                    where (userAccount.Username = username)
                    count
            }
