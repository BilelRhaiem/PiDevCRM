using PiDevCRM.Data;
using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM
{
    class Program
    {
        static void Main(string[] args)
        {
            Category cat1 = new Category()
            {
                CategoryName = "Laptops"
            };
            Category cat2 = new Category()
            {
                CategoryName = "Accessories"
            };
            Category cat3 = new Category()
            {
                CategoryName = "Mobiles"
            };

            PiDevCRMContexte ctx = new PiDevCRMContexte();
            ctx.Categories.Add(cat1);
            ctx.Categories.Add(cat2);
            ctx.SaveChanges();

            //Product p1 = new Product()
            //{
            //    NameProduct = "samsung",
            //    Category = cat1,
            //    ImageProduct = "myphone",
            //    Price = 12
            //};

            //Product p2 = new Product()
            //{
            //    NameProduct = "Topnet",
            //    Category = cat2,
            //    ImageProduct = "myInternet",
            //    Price = 13
            //};

            //ctx.Products.Add(p1);
            //ctx.Products.Add(p2);
            //ctx.SaveChanges();


            System.Console.WriteLine("datebase created");
            Console.ReadKey();
        }
    }
}
