using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnuitexTraining.DataAccessLayer.Initialization
{
    public class DataBaseInitialization
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author() { Id = 1, CreationDate = DateTime.Now, Name = "Jmih V.A." },
                new Author() { Id = 2, CreationDate = DateTime.Now, Name = "Drozdov G.L." },
                new Author() { Id = 3, CreationDate = DateTime.Now, Name = "Teodorov V.V." },
                new Author() { Id = 4, CreationDate = DateTime.Now, Name = "Kovalenko S.A." },
                new Author() { Id = 5, CreationDate = DateTime.Now, Name = "Gorin O.V." }
                );

            modelBuilder.Entity<PrintingEdition>().HasData(
                new PrintingEdition() { Id = 1, CreationDate = DateTime.Now, Currency = Currency.UAH, Description = "Neurotechnologies", Price = 1000 },
                new PrintingEdition() { Id = 2, CreationDate = DateTime.Now, Currency = Currency.EUR, Description = "C# Starter", Price = 20 },
                new PrintingEdition() { Id = 3, CreationDate = DateTime.Now, Currency = Currency.USD, Description = "ASP.NET MVC 5", Price = 100 },
                new PrintingEdition() { Id = 2, CreationDate = DateTime.Now, Currency = Currency.EUR, Description = "How it works", Price = 50 },
                new PrintingEdition() { Id = 3, CreationDate = DateTime.Now, Currency = Currency.USD, Description = "Angular 9", Price = 70 }
                );

            modelBuilder.Entity<AuthorInPrintingEdition>().HasData(
                new AuthorInPrintingEdition() { AuthorId = 1, PrintingEditionId = 1, Date = new DateTime(2008,4,12)},
                new AuthorInPrintingEdition() { AuthorId = 2, PrintingEditionId = 2, Date = new DateTime(2010,1,6)},
                new AuthorInPrintingEdition() { AuthorId = 3, PrintingEditionId = 3, Date = new DateTime(2016,7,13)},
                new AuthorInPrintingEdition() { AuthorId = 4, PrintingEditionId = 4, Date = new DateTime(2002,5,5)},
                new AuthorInPrintingEdition() { AuthorId = 5, PrintingEditionId = 5, Date = new DateTime(2020,4,25)}
                );

            modelBuilder.Entity<Payment>().HasData(
                new Payment() { Id = 1, CreationDate = DateTime.Now, TransactionId = 21847238958},
                new Payment() { Id = 2, CreationDate = DateTime.Now, TransactionId = 57976548678},
                new Payment() { Id = 3, CreationDate = DateTime.Now, TransactionId = 45679839882}
                );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser() { Id = 1, Email = "admin@example.com", FirstName = "Vladislav", LastName = "Goncharuk", UserName = "vladiator", PhoneNumber = "+380935538212", EmailConfirmed = true, PhoneNumberConfirmed = true},
                new ApplicationUser() { Id = 1, Email = "user@example.com", FirstName = "Valerij", LastName = "Jmishenko", UserName = "valerajmih", PhoneNumber = "+380503487621", EmailConfirmed = true, PhoneNumberConfirmed = true }
                );
        }
    }
}
