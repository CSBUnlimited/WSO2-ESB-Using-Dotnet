using System.Linq;
using FastFoodOnline.Models;
using FastFoodOnline.Services;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Persistence
{
    public static class FastFoodDbContextExtention
    {
        public static void InitializeDatabase(this FastFoodDbContext context)
        {
            // Perform database delete and create
            context.Database.Migrate();

            // Perform seed operations
            SeedData(context);

            // Save changes and release resources
            context.SaveChanges();
        }

        private static void SeedData(FastFoodDbContext context)
        {
            if (context.Users.Any())
                return;

            context.Users.AddRange
            (
                new User() { Username = "CSBUnlimited", Password = StringEncryptService.GetStringSha256Hash("user1"), FirstName = "Chathuranga", LastName = "Basnayake", Gender = Gender.Male, Email = "chathurangabasnayake@outlook.com", Mobile = "0778511690" },
                new User() { Username = "user2", Password = StringEncryptService.GetStringSha256Hash("user2"), FirstName = "Harin", LastName = "Wijesekara", Gender = Gender.Male, Email = "harin.w@gmail.com", Mobile = "077xxxxxxx" },
                new User() { Username = "user3", Password = StringEncryptService.GetStringSha256Hash("user3"), FirstName = "Heshani", LastName = "Nanayakkara", Gender = Gender.Female, Email = "heshnai.n@gmail.com", Mobile = "071xxxxxxx" },
                new User() { Username = "user4", Password = StringEncryptService.GetStringSha256Hash("user4"), FirstName = "Pathmika", LastName = "Rajapakshe", Gender = Gender.Male, Email = "pathmika.r@outlook.com", Mobile = "076yyyyyyy" },
                new User() { Username = "user5", Password = StringEncryptService.GetStringSha256Hash("user5"), FirstName = "Nikeshala", LastName = "Amarasinghe", Gender = Gender.Female, Email = "nikeshala.a@ymail.com", Mobile = "071yyyyyyy" },
                new User() { Username = "user6", Password = StringEncryptService.GetStringSha256Hash("user6"), FirstName = "Samith", LastName = "Dilshan", Gender = Gender.Male, Email = "samith.d@gmail.com", Mobile = "077zzzzzzz" }
            );

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
