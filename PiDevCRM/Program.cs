using PiDevCRM.Data;
using PiDevCRM.Domain.Entities;
using PiDevCRM.Service;
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
            //Category cat1 = new Category()
            //{
            //    CategoryName = "Laptops"
            //};
            //Category cat2 = new Category()
            //{
            //    CategoryName = "Accessories"
            //};
            //Category cat3 = new Category()
            //{
            //    CategoryName = "Mobiles"
            //};
            ProductService ps = new ProductService();

            PiDevCRMContexte ctx = new PiDevCRMContexte();
            //ctx.Categories.Add(cat1);
            //ctx.Categories.Add(cat2);
            //ctx.SaveChanges();

            //Pack pa1 = new Pack()
            //{
            //    PackName = "first"
            //};

            //Pack pa2 = new Pack()
            //{
            //    PackName = "second"
            //};

            
            //Product p1 = new Product()
            //{
            //    NameProduct = "samsung",
            //    //Category = cat1,
            //    ImageProduct = "myphone",
            //    Price = 12,
            //    IdPack=1
                
            //};

            //Product p2 = new Product()
            //{
            //    NameProduct = "Topnet",
            //    //Category = cat2,
            //    ImageProduct = "myInternet",
            //    Price = 13,
            //    IdPack = 2
               
            //};

            //ctx.Products.Add(p1);
            //ctx.Products.Add(p2);
            //ctx.SaveChanges();

            //List<Product> prods = new List<Product>()
            //{
            //    p1,p2
            //};

            //foreach (var prod in ps.GetProductByPackName("UpdatedPack"))
            //{
            //    Console.WriteLine(prod.NameProduct);
            //}


            System.Console.WriteLine("datebase created");
            Console.ReadKey();
        }
    }
}
