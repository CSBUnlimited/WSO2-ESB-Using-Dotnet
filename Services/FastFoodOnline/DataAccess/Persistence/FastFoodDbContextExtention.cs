using System.Collections.Generic;
using System.Linq;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Persistence
{
    /// <summary>
    /// FastFoodDbContext - Extention
    /// </summary>
    public static class FastFoodDbContextExtention
    {
        /// <summary>
        /// Do migrations and seed data
        /// </summary>
        /// <param name="context"></param>
        public static void InitializeDatabase(this FastFoodDbContext context)
        {
            // Perform database delete and create
            context.Database.Migrate();

            // Perform seed operations
            SeedData(context);

            // Save changes and release resources
            context.SaveChanges();
        }

        /// <summary>
        /// Seed data to database
        /// </summary>
        /// <param name="context"></param>
        private static void SeedData(FastFoodDbContext context)
        {
            if (context.Users.Any())
                return;

            List<User> users = new List<User>()
            {
                new User() { FirstName = "Chathuranga", LastName = "Basnayake", Username = "CSBUnlimited", Gender = Gender.Male, Email = "chathurangabasnayake@outlook.com", Mobile = "0778511690" },
                new User() { FirstName = "Harin", LastName = "Wijesekara", Username = "user2", Gender = Gender.Male, Email = "harin.w@gmail.com", Mobile = "077xxxxxxx" },
                new User() { FirstName = "Heshani", LastName = "Nanayakkara", Username = "user3", Gender = Gender.Female, Email = "heshnai.n@gmail.com", Mobile = "071xxxxxxx" },
                new User() { FirstName = "Pathmika", LastName = "Rajapakshe", Username = "user4", Gender = Gender.Male, Email = "pathmika.r@outlook.com", Mobile = "076yyyyyyy" },
                new User() { FirstName = "Nikeshala", LastName = "Amarasinghe", Username = "user5", Gender = Gender.Female, Email = "nikeshala.a@ymail.com", Mobile = "071yyyyyyy" },
                new User() { FirstName = "Samith", LastName = "Dilshan", Username = "user6", Gender = Gender.Male, Email = "samith.d@gmail.com", Mobile = "077zzzzzzz" }
            };

            
            for (int ind = 0, usersCount = users.Count(); ind < usersCount; ind++)
            {
                byte[] passwordHash, passwordSalt;
                string password = $"user{ (ind + 1) }";

                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }

                User user = users[ind];

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            context.Users.AddRange(users);
            
            context.Foods.AddRange
            (
                new Food() { Name = "Pizza", Price = 500 },
                new Food() { Name = "Rotti", Price = 100 },
                new Food() { Name = "Potato Chips", Price = 150 },
                new Food() { Name = "Burger", Price = 200 },
                new Food() { Name = "Fish Buns", Price = 50 },
                new Food() { Name = "Kottu", Price = 200 },
                new Food() { Name = "Submarine Sandwich", Price = 250 },
                new Food() { Name = "Soft Drink", Price = 150 }
            );

            context.PaymentMethods.AddRange
            (
                new PaymentMethod() { Code = "CC", Name = "Credit Card" },
                new PaymentMethod() { Code = "MO", Name = "Mobile Phone" }
            );
        }

    }
}
