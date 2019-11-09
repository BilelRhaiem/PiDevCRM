using PiDevCRM.Data.Infrastructure;
using PiDevCRM.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PiDevCRM.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);
        public ProductService():base(UTK)
        {

        }
        public IEnumerable<Product> GetProductByCategory(string nameCategory)
        {
            return GetMany(p => p.Category.CategoryName.Equals(nameCategory));
        }
        public IEnumerable<Product> ListProdTrie()
        {
            return GetAll().OrderByDescending(t => t.Price); 
        }
    }
}
