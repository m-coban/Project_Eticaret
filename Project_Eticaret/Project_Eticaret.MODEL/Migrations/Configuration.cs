namespace Project_Eticaret.MODEL.Migrations
{
    using Project_Eticaret.MODEL.Entites;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Principal;

    internal sealed class Configuration : DbMigrationsConfiguration<Project_Eticaret.MODEL.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Project_Eticaret.MODEL.Context.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            Category c = new Category()
            {
                ID = Guid.NewGuid(),
                Name = "Main Category",
                Status = CORE.Entity.Enum.Status.Active,
                Description = "Main test category description",
                CreatedDate = DateTime.Now,
                MasterID = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIP = "123",
                CreatedADUserName = WindowsIdentity.GetCurrent().Name
            };

            SubCategory sc = new SubCategory()
            {
                ID = Guid.NewGuid(),
                Name = "Sub Category",
                Status = CORE.Entity.Enum.Status.Active,
                Description = "Test subcategory description",
                CreatedDate = DateTime.Now,
                MasterID = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIP = "123",
                CreatedADUserName = WindowsIdentity.GetCurrent().Name,
                CategoryID = c.ID
            };

            AppUser au = new AppUser()
            {
                UserName = "admin",
                Password = "123",
                ID = Guid.NewGuid(),
                Role = Role.Admin,
                Status = CORE.Entity.Enum.Status.Active,
                CreatedDate = DateTime.Now,
                MasterID = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIP = "123",
                CreatedADUserName = WindowsIdentity.GetCurrent().Name,
                Address = "Test Mahallesi Test Sokak",
                PhoneNumber = "0001112233",
                Name = "Test Ad",
                SurName = "Test Soyad"
            };

            List<Product> products = new List<Product>()
            {
                new Product
                {
                ID = Guid.NewGuid(),
                Name = "Test Product 1",
                Status = CORE.Entity.Enum.Status.Active,
                CreatedDate = DateTime.Now,
                MasterID = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIP = "123",
                CreatedADUserName = WindowsIdentity.GetCurrent().Name,
                SubCategoryID = sc.ID,
                Price = 50,
                Quantity = "KG",
                UnitInStock = 100
                },
                new Product
                {
                ID = Guid.NewGuid(),
                Name = "Test Product 2",
                Status = CORE.Entity.Enum.Status.Active,
                CreatedDate = DateTime.Now,
                MasterID = null,
                CreatedComputerName = Environment.MachineName,
                CreatedIP = "123",
                CreatedADUserName = WindowsIdentity.GetCurrent().Name,
                SubCategoryID = sc.ID,
                Price = 70,
                Quantity = "Adet",
                UnitInStock = 160
                }
            };

            context.Users.AddOrUpdate(au);
            context.Categories.AddOrUpdate(c);
            context.SubCategories.AddOrUpdate(sc);
            context.Products.AddRange(products);

            base.Seed(context);
        }
    }
}
