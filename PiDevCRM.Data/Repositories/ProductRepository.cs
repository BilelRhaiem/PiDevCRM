using PiDevCRM.Data.Infrastructure;
using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        //private PiDevCRMContexte _dbContext = new PiDevCRMContexte();

        private DatabaseFactory _db = new DatabaseFactory();
        public ProductRepository(DatabaseFactory db)
            : base(db)
        {
            //dbContext =  new PiDevCRMContexte();
            _db = db;
        }
    }
}
