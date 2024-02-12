using AlphaSales.DataAccess.Data;
using AlphaSales.DataAccess.Repository.IRepository;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IEmployeeRepository Employee { get; private set; }
        public ICorporationRepository Corporation { get; private set; }
        public IClientRepository Client { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db);
            Corporation = new CorporationRepository(_db);
            Client = new ClientRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
