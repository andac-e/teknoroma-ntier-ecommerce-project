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
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            #region BranchManager
            AppUser manager = new AppUser
            {
                UserName = "manager",
                Password = DantexCrypt.Crypt("manager"),
                ConfirmPassword = DantexCrypt.Crypt("manager"),
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Admin,
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
            Employee sales = new Employee
            {
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Employee,
                FirstName = "Gül",
                LastName = "Satar",
                TCNO = "20000000002",
                PhoneNumber = "05550001133",
                Gender = ENTITIES.Enums.Gender.Female,
                Salary = 8000
            };
            context.Employees.Add(sales);
            context.SaveChanges();
            #endregion

            #region WarehouseRepresentative
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
            Employee acc = new Employee
            {
                Email = "andacerdogmus26@gmail.com",
                Role = ENTITIES.Enums.UserRole.Employee,
                FirstName = "Kerim",
                LastName = "Zulacı",
                TCNO = "20000000004",
                PhoneNumber = "05550001155",
                Gender = ENTITIES.Enums.Gender.Female,
                Salary = 6000
            };
            context.Employees.Add(acc);
            context.SaveChanges();
            #endregion

            #region TechnicalServiceRepresentative
            Employee tech = new Employee
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
            context.Employees.Add(tech);
            context.SaveChanges();
            #endregion

            //todo: app-user ve profilleri oluştur,fake kategori ürün oluştur. kullanıcıları düzenle.
        }
    }
}
