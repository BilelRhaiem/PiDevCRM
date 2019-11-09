using PiDevCRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
       
         public PiDevCRMContexte dataContext;

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.DataContext;
        }

        public UnitOfWork()
        {
            //this._dataContext = new MyFinanceContext();
            this.dbFactory = new DatabaseFactory();
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }
        
        public void Dispose()
        {
            dataContext.Dispose();
        }
        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            IRepositoryBase<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }

        public IRepositoryBase<T> GetRepositoryBase<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
