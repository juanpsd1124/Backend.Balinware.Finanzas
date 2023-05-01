using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balinware.Finanzas.Application.Interface.Persistence;

namespace Balinware.Finanzas.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthsRepository Auths { get; }

        public UnitOfWork(IAuthsRepository auths) 
        { 
            Auths = auths;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
