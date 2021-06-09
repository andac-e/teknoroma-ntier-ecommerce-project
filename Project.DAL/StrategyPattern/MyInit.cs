using Bogus.DataSets;
using Project.COMMON.Tools;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPattern
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            #region Admin
            AppUser admin = new AppUser
            {
                UserName = "admin",
                Password = PasswordHasher.Crypt("admin"),
                ConfirmPassword = PasswordHasher.Crypt("admin"),
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Admin,
                Active = true
            };
            context.AppUsers.Add(admin);
            context.SaveChanges();

            UserProfile adminProfile = new UserProfile
            {
                ID = admin.ID,
                FirstName = "Andaç",
                LastName = "Erdoğmuş",
                TCNO = "20000000000",
                Age = 25,
                Gender = ENTITIES.Enums.Gender.Male
            };
            context.UserProfiles.Add(adminProfile);
            context.SaveChanges();
            #endregion

            #region User
            AppUser user = new AppUser
            {
                UserName = "user1",
                Password = PasswordHasher.Crypt("user1"),
                ConfirmPassword = PasswordHasher.Crypt("user1"),
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Member,
                Active = true
            };
            context.AppUsers.Add(user);
            context.SaveChanges();

            UserProfile userProfile = new UserProfile
            {
                ID = user.ID,
                FirstName = "Cemre",
                LastName = "Uzun",
                TCNO = "20000000010",
                Age = 25,
                Gender = ENTITIES.Enums.Gender.Female
            };
            context.UserProfiles.Add(userProfile);
            context.SaveChanges();
            #endregion

            #region BranchManager
            AppUser manager = new AppUser
            {
                UserName = "manager",
                Password = PasswordHasher.Crypt("manager"),
                ConfirmPassword = PasswordHasher.Crypt("manager"),
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.BranchManager,
                Active = true
            };
            context.AppUsers.Add(manager);
            context.SaveChanges();

            Employee branchManager = new Employee
            {
                FirstName = "Haluk",
                LastName = "Saygın",
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Employee,
                TCNO = "20000000002",
                PhoneNumber = "05550001133",
                Gender = ENTITIES.Enums.Gender.Male,
                Salary = 12000
            };
            context.Employees.Add(branchManager);
            context.SaveChanges();
            #endregion

            #region SalesRepresentative
            AppUser sale = new AppUser
            {
                UserName = "sales",
                Password = PasswordHasher.Crypt("sales"),
                ConfirmPassword = PasswordHasher.Crypt("sales"),
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.SalesRepresentative,
                Active = true
            };
            context.AppUsers.Add(sale);
            context.SaveChanges();

            Employee sales = new Employee
            {
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Employee,
                FirstName = "Gül",
                LastName = "Satar",
                TCNO = "20000000002",
                PhoneNumber = "05550001133",
                Gender = ENTITIES.Enums.Gender.Female,
                MonthlySales = 15000,
                Salary = 8000
            };
            context.Employees.Add(sales);
            context.SaveChanges();
            #endregion

            #region WarehouseRepresentative
            AppUser wareHouse = new AppUser
            {
                UserName = "ware1",
                Password = PasswordHasher.Crypt("ware1"),
                ConfirmPassword = PasswordHasher.Crypt("ware1"),
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.WarehouseRepresentative,
                Active = true
            };
            context.AppUsers.Add(wareHouse);
            context.SaveChanges();

            Employee ware = new Employee
            {
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Employee,
                FirstName = "Kerim",
                LastName = "Zulacı",
                TCNO = "20000000003",
                PhoneNumber = "05550001144",
                Gender = ENTITIES.Enums.Gender.Male,
                Salary = 7000
            };
            context.Employees.Add(ware);
            context.SaveChanges();
            #endregion

            #region AccountingRepresentative
            AppUser acc = new AppUser
            {
                UserName = "acc11",
                Password = PasswordHasher.Crypt("acc11"),
                ConfirmPassword = PasswordHasher.Crypt("acc11"),
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.AccountingRepresentative,
                Active = true
            };
            context.AppUsers.Add(acc);
            context.SaveChanges();

            Employee accounting = new Employee
            {
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Employee,
                FirstName = "Feyza",
                LastName = "Paragöz",
                TCNO = "20000000004",
                PhoneNumber = "05550001155",
                Gender = ENTITIES.Enums.Gender.Female,
                Salary = 6000
            };
            context.Employees.Add(accounting);
            context.SaveChanges();
            #endregion

            #region TechnicalServiceRepresentative
            AppUser tech = new AppUser
            {
                UserName = "tech1",
                Password = PasswordHasher.Crypt("tech1"),
                ConfirmPassword = PasswordHasher.Crypt("tech1"),
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.TechnicalServiceRepresentative,
                Active = true
            };
            context.AppUsers.Add(tech);
            context.SaveChanges();

            Employee service = new Employee
            {
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Employee,
                FirstName = "Özgün",
                LastName = "Kablocu",
                TCNO = "20000000005",
                PhoneNumber = "05550001166",
                Gender = ENTITIES.Enums.Gender.Female,
                Salary = 5500
            };
            context.Employees.Add(service);
            context.SaveChanges();
            #endregion

            #region MobileSalesRepresentative
            AppUser mobile = new AppUser
            {
                UserName = "mobile",
                Password = PasswordHasher.Crypt("mobile"),
                ConfirmPassword = PasswordHasher.Crypt("mobile"),
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.MobileSalesRepresentative,
                Active = true
            };
            context.AppUsers.Add(mobile);
            context.SaveChanges();

            Employee mobileSales = new Employee
            {
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Employee,
                FirstName = "Fahri",
                LastName = "Cepçi",
                TCNO = "20000000006",
                PhoneNumber = "05550001177",
                Gender = ENTITIES.Enums.Gender.Male,
                Salary = 6000
            };
            context.Employees.Add(mobileSales);
            context.SaveChanges();
            #endregion

            #region FakeProducts
            for (int i = 0; i < 10; i++)
            {
                Category c = new Category
                {
                    CategoryName = new Commerce("tr").Categories(1)[0],
                    Description = new Lorem("tr").Sentence(10)
                };

                for (int j = 0; j < 20; j++)
                {
                    Product p = new Product
                    {
                        ProductName = new Commerce("tr").ProductName(),
                        UnitPrice = Convert.ToDecimal(new Commerce("tr").Price()),
                        UnitsInStock = 100,
                        ImagePath = new Images().PicsumUrl(),
                    };
                    c.Products.Add(p);
                }

                context.Categories.Add(c);
                context.SaveChanges();
            } 
            #endregion
        }
    }
}
