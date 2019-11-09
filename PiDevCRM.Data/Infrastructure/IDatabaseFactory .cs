
using PiDevCRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
         PiDevCRMContexte DataContext { get; }
    }

}
