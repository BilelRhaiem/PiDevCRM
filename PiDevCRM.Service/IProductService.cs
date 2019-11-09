using PiDevCRM.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Service
{
    public interface IProductService : IService<Product>
    {

        IEnumerable<Product> GetProductByPack(Pack pack);
        int ProductID(Product prod);
    }
}
