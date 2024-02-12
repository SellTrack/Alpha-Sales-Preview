using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSales.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }
        ICorporationRepository Corporation { get; }
        IClientRepository Client { get; }

        void Save();
    }
}
