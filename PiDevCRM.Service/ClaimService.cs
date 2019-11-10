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
   public class ClaimService : Service<Claims>, IClaimService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);
        public ClaimService():base(UTK)
        {

        }
<<<<<<< Updated upstream
=======
       public int NbrRec()
        {

           //return GetAll().Where(c=>c.Description=="").Count();
           // return GetAll().Where(c => c.statustype.Equals(0)).Count();
            return GetAll().Count();


        }

>>>>>>> Stashed changes
    }
}
