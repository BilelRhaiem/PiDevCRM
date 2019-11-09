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
        public PackService pas = new PackService();
        public ProductService():base(UTK)
        {

        }

        public int ProductID(Product prod)
        {
            return prod.IdProduct;
        }

        public void Addprodtocart(Cart cart,Product prod)
        {
            cart.IdProduct = prod.IdProduct;
        }
    
        public IEnumerable<Product> GetProductByPack(Pack pack)
        {
            return GetMany(p => p.IdPack== pack.IdPack);
        }

        public IEnumerable<Product> GetProductByPackName(string packname)
        {
            return GetMany(p => p.Pack .Equals(packname));
        }

        public IEnumerable<Product> GetProductByPackId(int IdPack)
        {
            return GetMany(p => p.IdPack.Equals(IdPack));
        }

        public IEnumerable<Product> GetProductByPackRefer(int IdPack, Pack pack)
        {
            return pack.ListProducts.Where(prod => prod.IdPack== pack.IdPack);
        }

        public IEnumerable<Product> GetProductofPackProds(Pack pack)
        {
            //return pack.ListProducts.Where(prod => prod.IdPack == pack.IdPack);
            foreach (var i in ListProds)
            {
                if (i.IdPack.Equals(pack.IdPack)){
                    return pack.ListProducts;
                }
                
            }
            return null;
        }

        //public void Update(Cart c)
        //{
        //    c.IdProduct=
        //}

        //public void prodpack()
        //{
        //    var req = from i in ListProds join j in ListPack on i.IdPack equals j.IdPack select i.NameProduct;

        //    foreach (var j in req)
        //    {
        //        Console.WriteLine(j);

        //    }

        //}


    }
}
