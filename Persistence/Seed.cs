using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class Seed
{

    public static async Task SeedData(DataContext context)
    {
        if (context.Categories.Any()) return;

        var categories = new List<Category>
            {
                new Category
                {
                     Name = "Technology"

                },
                  new Category
                {
                     Name = "School Items"

                },
                   new Category
                {
                     Name = "Art and books"

                },

            };

        var products = new List<Product>
        {
                new Product {
                     Code = "00001",
                     Name = "Dune",
                     Description = "Dune from frank herbert",
                      UnitPrice = 50,
                      ImageUrl = "/assets/productImages/book.png"
                },
                 new Product {
                     Code = "00002",
                     Name = "Blue Pencil",
                     Description = "Kilometrico pencil blue an glue",
                      UnitPrice = 1,
                      ImageUrl = "/assets/productImages/BluePencil.png"
                },
                 new Product {
                     Code = "00003",
                     Name = "Asus Laptop",
                     Description = "laptop for work and gaming, intel core i7 rtx 4000",
                      UnitPrice = 900,
                      ImageUrl = "/assets/productImages/Rog.png"
                },

                   new Product {
                     Code = "00004",
                     Name = "IPhone 15",
                     Description = "Iphone 15 6 gb ram ",
                      UnitPrice = 1000,
                      ImageUrl = "/assets/productImages/Iphone15.png"
                },
                       new Product {
                     Code = "00005",
                     Name = "Iphone 14",
                     Description = "Iphone 15 6 gb ram ",
                      UnitPrice = 900,
                      ImageUrl = "/assets/productImages/Iphone14.png"
                },
                     new Product {
                     Code = "00006",
                     Name = "Iphone 13",
                     Description = "Iphone 13 the best iphone",
                      UnitPrice = 700,
                      ImageUrl = "/assets/productImages/Iphone14.png"
                },
                    new Product {
                     Code = "00007",
                     Name = "Clean Code",
                     Description = "developer book from uncle bob",
                      UnitPrice = 10,
                      ImageUrl = "/assets/productImages/bookClean.png"
                },
                   new Product {
                     Code = "00008",
                     Name = "Clean architecture",
                     Description = "developer book from uncle bob",
                     UnitPrice = 10,
                     ImageUrl = "/assets/productImages/bookCleanarch.png"
                },
                     new Product {
                     Code = "00009",
                     Name = "Pragmatic programmer",
                     Description = "pragmatic in development is all, don complicate yourserf coding",
                     UnitPrice = 5,
                     ImageUrl = "/assets/productImages/Pragmatic.png"
                },
                 new Product {
                     Code = "00010",
                     Name = "Ipad pro 11",
                     Description = "tablet for work and school",
                     UnitPrice = 5,
                     ImageUrl = "/assets/productImages/Ipad.png"
                },
                 new Product {
                     Code = "00011",
                     Name = "Samsung Tablet",
                     Description = "tablet for work and school",
                     UnitPrice = 100,
                     ImageUrl = "/assets/productImages/samsung.png"
                },
                     new Product {
                     Code = "00012",
                     Name = "Logitech mx mouse",
                     Description = "mouse for gaming with 17000 dpi",
                     UnitPrice = 100,
                     ImageUrl = "/assets/productImages/mouse.png"
                },
                  new Product {
                     Code = "00013",
                     Name = "PS4 Console",
                     Description = "Ps4 Console, with one control",
                     UnitPrice = 100,
                     ImageUrl = "/assets/productImages/ps4.png"
                },
                  new Product {
                     Code = "00014",
                     Name = "PS5 Console",
                     Description = "Ps5 Console, with one control",
                     UnitPrice = 100,
                     ImageUrl = "/assets/productImages/ps5.png"
                },
                   new Product {
                     Code = "00015",
                     Name = "xbox one ",
                     Description = "xbox Console, with one control",
                     UnitPrice = 100,
                     ImageUrl = "/assets/productImages/xboxone.png"
                },
                  new Product {
                     Code = "00015",
                     Name = "xbox one series x ",
                     Description = "xbox Console, with one control",
                     UnitPrice = 100,
                     ImageUrl = "/assets/productImages/xboxonex.png"
                },
                 new Product {
                     Code = "00015",
                     Name = "xbox one series s ",
                     Description = "xbox Console, with one control",
                     UnitPrice = 100,
                     ImageUrl = "/assets/productImages/xboxones.png"
                },




        };

        var customers = new List<Customer>
        {
            new Customer {
                 Email = "alexander80143@gmail.com",
                  FirstName= "John",
                   LastName="ubaque"
            },
             new Customer {
                 Email = "info@solucionesug.com",
                  FirstName= "lizeth",
                   LastName="Garzon"
            }

        };







        Random numberGenerator = new Random();

        var productCategories = new List<ProductCategory>();
        var productStock = new List<ProductStock>();

        foreach (var product in products)
        {

            for (int i = 0; i < 5; i++)
            {
                productStock.Add(new ProductStock
                {
                    Product = product,
                    SerialNumber = "AAAA-" + numberGenerator.Next(),
                    BatchCode = "K00-" + numberGenerator.Next(),
                    Status = "S"
                });
            }
            foreach (var category in categories)
            {
                productCategories.Add(
                    new ProductCategory
                    {
                        Product = product,
                        Category = category,
                    }
                );
            }

        }


        await context.Categories.AddRangeAsync(categories);
        await context.Products.AddRangeAsync(products);
        await context.Customers.AddRangeAsync(customers);
        await context.ProductCategories.AddRangeAsync(productCategories);
        await context.ProductStock.AddRangeAsync(productStock);

        await context.SaveChangesAsync();





    }
}
