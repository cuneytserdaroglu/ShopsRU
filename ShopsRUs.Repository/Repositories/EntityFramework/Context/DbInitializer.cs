using ShopsRUs.Domain.Concrete;
using ShopsRUs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Repository.Repositories.EntityFramework.Context
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Customers.Any())
            {
                Discount discount = new Discount()
                {
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    DiscountRate = 30
                };
                Discount discount2 = new Discount()
                {
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    DiscountRate = 10
                };
                CustomerType customerType = new CustomerType()
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Name = "Mağaza Çalışanı"
                };
                CustomerType customerType2 = new CustomerType()
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Name = "Üye-Müşteri"
                };
                context.Customers.Add(new Customer
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Name = "Ceyda",
                    //CustomerTypeId = (int)CustomerTypes.Employee,
                    //DiscountId =1,
                    CustomerType = customerType,
                    Discount = discount
                });
                context.Customers.Add(new Customer
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Name = "Cüneyt",
                    //CustomerTypeId = (int)CustomerTypes.Member,
                    //DiscountId = 2,
                    CustomerType = customerType2,
                    Discount = discount2

                });
                context.Customers.Add(new Customer
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now.AddYears(-3),
                    Name = "Miray",
                    //CustomerTypeId = (int)CustomerTypes.Member,
                    //DiscountId = 2
                    CustomerType = customerType2,
                    Discount = discount2
                });



                context.SaveChanges();
                return;
            }

            context.SaveChanges();
        }
    }
}
