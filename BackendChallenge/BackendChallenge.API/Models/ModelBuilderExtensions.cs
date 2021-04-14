using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendChallenge.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void SeedInfo(this CurrencyContext context)
        {
            if (!context.Currency.Any())
            {
                context.Currency.AddRange(
                    new Currency { CurrencyId = 1, Name = "European euro", Code = "EUR" },
                    new Currency { CurrencyId = 2, Name = "United States dollar", Code = "USD" },
                    new Currency { CurrencyId = 3, Name = "Canadian dollar", Code = "CAD" },
                    new Currency { CurrencyId = 4, Name = "Japanese yen", Code = "JPY" },
                    new Currency { CurrencyId = 5, Name = "Australian dollar", Code = "AUD" },
                    new Currency { CurrencyId = 6, Name = "Peruvian sol", Code = "PEN" }
                );
                context.CurrencyExchange.AddRange(
                    new CurrencyExchange { CurrencyExchangeId = 1, CurrencyId_From = 1, CurrencyId_To = 2, Equivalent = 1.13 },
                    new CurrencyExchange { CurrencyExchangeId = 2, CurrencyId_From = 1, CurrencyId_To = 3, Equivalent = 1.53 },
                    new CurrencyExchange { CurrencyExchangeId = 3, CurrencyId_From = 1, CurrencyId_To = 4, Equivalent = 120.89 },
                    new CurrencyExchange { CurrencyExchangeId = 4, CurrencyId_From = 1, CurrencyId_To = 5, Equivalent = 1.63 },
                    new CurrencyExchange { CurrencyExchangeId = 5, CurrencyId_From = 1, CurrencyId_To = 6, Equivalent = 3.97 },

                    new CurrencyExchange { CurrencyExchangeId = 6, CurrencyId_From = 2, CurrencyId_To = 1, Equivalent = 0.89 },
                    new CurrencyExchange { CurrencyExchangeId = 7, CurrencyId_From = 2, CurrencyId_To = 3, Equivalent = 1.36 },
                    new CurrencyExchange { CurrencyExchangeId = 8, CurrencyId_From = 2, CurrencyId_To = 4, Equivalent = 107.43 },
                    new CurrencyExchange { CurrencyExchangeId = 9, CurrencyId_From = 2, CurrencyId_To = 5, Equivalent = 1.44 },
                    new CurrencyExchange { CurrencyExchangeId = 10, CurrencyId_From = 2, CurrencyId_To = 6, Equivalent = 3.53 },

                    new CurrencyExchange { CurrencyExchangeId = 11, CurrencyId_From = 3, CurrencyId_To = 1, Equivalent = 0.65 },
                    new CurrencyExchange { CurrencyExchangeId = 12, CurrencyId_From = 3, CurrencyId_To = 2, Equivalent = 0.74 },
                    new CurrencyExchange { CurrencyExchangeId = 13, CurrencyId_From = 3, CurrencyId_To = 4, Equivalent = 79.06 },
                    new CurrencyExchange { CurrencyExchangeId = 14, CurrencyId_From = 3, CurrencyId_To = 5, Equivalent = 1.06 },
                    new CurrencyExchange { CurrencyExchangeId = 15, CurrencyId_From = 3, CurrencyId_To = 6, Equivalent = 2.60 },

                    new CurrencyExchange { CurrencyExchangeId = 16, CurrencyId_From = 4, CurrencyId_To = 1, Equivalent = 0.0083 },
                    new CurrencyExchange { CurrencyExchangeId = 17, CurrencyId_From = 4, CurrencyId_To = 2, Equivalent = 0.0093 },
                    new CurrencyExchange { CurrencyExchangeId = 18, CurrencyId_From = 4, CurrencyId_To = 3, Equivalent = 0.013 },
                    new CurrencyExchange { CurrencyExchangeId = 19, CurrencyId_From = 4, CurrencyId_To = 5, Equivalent = 0.013 },
                    new CurrencyExchange { CurrencyExchangeId = 20, CurrencyId_From = 4, CurrencyId_To = 6, Equivalent = 0.033 },

                    new CurrencyExchange { CurrencyExchangeId = 21, CurrencyId_From = 5, CurrencyId_To = 1, Equivalent = 0.61 },
                    new CurrencyExchange { CurrencyExchangeId = 22, CurrencyId_From = 5, CurrencyId_To = 2, Equivalent = 0.69 },
                    new CurrencyExchange { CurrencyExchangeId = 23, CurrencyId_From = 5, CurrencyId_To = 3, Equivalent = 0.94 },
                    new CurrencyExchange { CurrencyExchangeId = 24, CurrencyId_From = 5, CurrencyId_To = 4, Equivalent = 74.31 },
                    new CurrencyExchange { CurrencyExchangeId = 25, CurrencyId_From = 5, CurrencyId_To = 6, Equivalent = 2.44 },

                    new CurrencyExchange { CurrencyExchangeId = 26, CurrencyId_From = 6, CurrencyId_To = 1, Equivalent = 0.25 },
                    new CurrencyExchange { CurrencyExchangeId = 27, CurrencyId_From = 6, CurrencyId_To = 2, Equivalent = 0.28 },
                    new CurrencyExchange { CurrencyExchangeId = 28, CurrencyId_From = 6, CurrencyId_To = 3, Equivalent = 0.3 },
                    new CurrencyExchange { CurrencyExchangeId = 29, CurrencyId_From = 6, CurrencyId_To = 4, Equivalent = 30.44 },
                    new CurrencyExchange { CurrencyExchangeId = 30, CurrencyId_From = 6, CurrencyId_To = 5, Equivalent = 0.41 }
                );
                context.User.AddRange(
                    new User { UserId = 1, Username = "jvaldez", Password = "12345" },
                    new User { UserId = 2, Username = "aperez", Password = "12345" }
                );
                context.SaveChanges();
            }
        }
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                    new Currency
                    {
                        CurrencyId = 1,
                        Name = "European euro",
                        Code = "EUR"
                    },
                    new Currency
                    {
                        CurrencyId = 2,
                        Name = "United States dollar",
                        Code = "USD"
                    },
                    new Currency
                    {
                        CurrencyId = 3,
                        Name = "Canadian dollar",
                        Code = "CAD"
                    },
                    new Currency
                    {
                        CurrencyId = 4,
                        Name = "Japanese yen",
                        Code = "JPY"
                    },
                    new Currency
                    {
                        CurrencyId = 5,
                        Name = "Australian dollar",
                        Code = "AUD"
                    },
                    new Currency
                    {
                        CurrencyId = 6,
                        Name = "Peruvian sol",
                        Code = "PEN"
                    }
                );

            modelBuilder.Entity<CurrencyExchange>().HasData(
               new CurrencyExchange { CurrencyExchangeId = 1, CurrencyId_From = 1, CurrencyId_To = 2, Equivalent = 1.13 },
               new CurrencyExchange { CurrencyExchangeId = 2, CurrencyId_From = 1, CurrencyId_To = 3, Equivalent = 1.53 },
               new CurrencyExchange { CurrencyExchangeId = 3, CurrencyId_From = 1, CurrencyId_To = 4, Equivalent = 120.89 },
               new CurrencyExchange { CurrencyExchangeId = 4, CurrencyId_From = 1, CurrencyId_To = 5, Equivalent = 1.63 },
               new CurrencyExchange { CurrencyExchangeId = 5, CurrencyId_From = 1, CurrencyId_To = 6, Equivalent = 3.97 },

               new CurrencyExchange { CurrencyExchangeId = 6, CurrencyId_From = 2, CurrencyId_To = 1, Equivalent = 0.89 },
               new CurrencyExchange { CurrencyExchangeId = 7, CurrencyId_From = 2, CurrencyId_To = 3, Equivalent = 1.36 },
               new CurrencyExchange { CurrencyExchangeId = 8, CurrencyId_From = 2, CurrencyId_To = 4, Equivalent = 107.43 },
               new CurrencyExchange { CurrencyExchangeId = 9, CurrencyId_From = 2, CurrencyId_To = 5, Equivalent = 1.44 },
               new CurrencyExchange { CurrencyExchangeId = 10, CurrencyId_From = 2, CurrencyId_To = 6, Equivalent = 3.53 },

               new CurrencyExchange { CurrencyExchangeId = 11, CurrencyId_From = 3, CurrencyId_To = 1, Equivalent = 0.65 },
               new CurrencyExchange { CurrencyExchangeId = 12, CurrencyId_From = 3, CurrencyId_To = 2, Equivalent = 0.74 },
               new CurrencyExchange { CurrencyExchangeId = 13, CurrencyId_From = 3, CurrencyId_To = 4, Equivalent = 79.06 },
               new CurrencyExchange { CurrencyExchangeId = 14, CurrencyId_From = 3, CurrencyId_To = 5, Equivalent = 1.06 },
               new CurrencyExchange { CurrencyExchangeId = 15, CurrencyId_From = 3, CurrencyId_To = 6, Equivalent = 2.60 },

               new CurrencyExchange { CurrencyExchangeId = 16, CurrencyId_From = 4, CurrencyId_To = 1, Equivalent = 0.0083 },
               new CurrencyExchange { CurrencyExchangeId = 17, CurrencyId_From = 4, CurrencyId_To = 2, Equivalent = 0.0093 },
               new CurrencyExchange { CurrencyExchangeId = 18, CurrencyId_From = 4, CurrencyId_To = 3, Equivalent = 0.013 },
               new CurrencyExchange { CurrencyExchangeId = 19, CurrencyId_From = 4, CurrencyId_To = 5, Equivalent = 0.013 },
               new CurrencyExchange { CurrencyExchangeId = 20, CurrencyId_From = 4, CurrencyId_To = 6, Equivalent = 0.033 },

               new CurrencyExchange { CurrencyExchangeId = 21, CurrencyId_From = 5, CurrencyId_To = 1, Equivalent = 0.61 },
               new CurrencyExchange { CurrencyExchangeId = 22, CurrencyId_From = 5, CurrencyId_To = 2, Equivalent = 0.69 },
               new CurrencyExchange { CurrencyExchangeId = 23, CurrencyId_From = 5, CurrencyId_To = 3, Equivalent = 0.94 },
               new CurrencyExchange { CurrencyExchangeId = 24, CurrencyId_From = 5, CurrencyId_To = 4, Equivalent = 74.31 },
               new CurrencyExchange { CurrencyExchangeId = 25, CurrencyId_From = 5, CurrencyId_To = 6, Equivalent = 2.44 },

               new CurrencyExchange { CurrencyExchangeId = 26, CurrencyId_From = 6, CurrencyId_To = 1, Equivalent = 0.25 },
               new CurrencyExchange { CurrencyExchangeId = 27, CurrencyId_From = 6, CurrencyId_To = 2, Equivalent = 0.28 },
               new CurrencyExchange { CurrencyExchangeId = 28, CurrencyId_From = 6, CurrencyId_To = 3, Equivalent = 0.3 },
               new CurrencyExchange { CurrencyExchangeId = 29, CurrencyId_From = 6, CurrencyId_To = 4, Equivalent = 30.44 },
               new CurrencyExchange { CurrencyExchangeId = 30, CurrencyId_From = 6, CurrencyId_To = 5, Equivalent = 0.41 }
           );

           modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "jvaldez", Password = "12345" },
                new User { UserId = 2, Username = "aperez", Password = "12345" }
           );
        }
    }
}
