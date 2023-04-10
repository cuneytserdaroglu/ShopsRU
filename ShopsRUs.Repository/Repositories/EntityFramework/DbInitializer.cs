using ShopsRUs.Domain.Concrete;
using ShopsRUs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Repository.Repositories.EntityFramework
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Customers.Any())
            {
                context.Discounts.Add(new Discount
                {
                    CreatedDate = DateTime.Now,
                    DiscountRate = 30,
                    IsActive = true,
                });
                context.Discounts.Add(new Discount
                {
                    CreatedDate = DateTime.Now,
                    DiscountRate = 10,
                    IsActive = true,
                });
                context.SaveChanges();
                using(var context1 = new AppDbContext())
                {
                    context.CustomerTypes.Add(new CustomerType
                    {
                        Name = "Mağaza Çalışanı",
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                        DiscountId = 1,
                    });
                    context.CustomerTypes.Add(new CustomerType
                    {
                        Name = "Müşteri - Üye",
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                        DiscountId = 2
                    });
                    context1.SaveChanges();
                }
                using (var context2 = new AppDbContext())
                {
                    context.Customers.Add(new Customer
                    {
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                        Name = "Cüneyt",
                        CustomerTypeId = (int)CustomerTypes.Employee,
                    });
                    context.Customers.Add(new Customer
                    {
                        IsActive = true,
                        CreatedDate = DateTime.Now.AddYears(-3),
                        Name = "Miray",
                        CustomerTypeId = (int)CustomerTypes.Member,
                    });
                    context.Customers.Add(new Customer
                    {
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                        Name = "Ceyda",
                        CustomerTypeId = (int)CustomerTypes.Member,
                    });
                    context2.SaveChanges();
                }

                return;   
            }


        }
    }
}
