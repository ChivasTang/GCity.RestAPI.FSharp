namespace GCity.RestAPI.FSharp.Repositories

open Microsoft.EntityFrameworkCore.ChangeTracking
open GCity.RestAPI.FSharp.Models
open GCity.RestAPI.FSharp.Database
open System.Collections.Generic


type LocaleRepository(_context: ApiDbContext) =
    interface ILocaleRepository with
        override this.Delete(locale: Locale) : EntityEntry<Locale> = _context.Locales.Remove locale

        override this.Insert(locale: Locale) : EntityEntry<Locale> = _context.Locales.Add locale

        override this.Update(locale: Locale) : EntityEntry<Locale> = _context.Locales.Update locale

        override this.SelectAll() : IEnumerable<Locale> =
            query {
                for locale in _context.Locales do
                    select locale
            }

        override this.SelectByCode(code: string) : Locale =
            query {
                for locale in _context.Locales do
                    where (locale.Code = code)
                    select locale
                    exactlyOneOrDefault
            }
