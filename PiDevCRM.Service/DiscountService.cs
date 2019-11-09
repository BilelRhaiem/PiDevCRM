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
    public class DiscountService : Service<Discount>, IDiscountService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);
        public DiscountService() : base(UTK)
        {

        }

        //public void DiscountPourcentageProduct(Product p,Discount d)
        //{
            
        //    if (p.IdDiscount != null)
        //    {
        //        p.Price = p.Price * d.Pourcentage;
        //    }
        //}
    }
}
