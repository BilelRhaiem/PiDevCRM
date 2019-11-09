
using PiDevCRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        public PiDevCRMContexte dataContext;
        public PiDevCRMContexte DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new PiDevCRMContexte();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
