using System;
using System.Linq.Expressions;
using AlphaSales.DataAccess.Data;
using AlphaSales.DataAccess.Repository.IRepository;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository
{
    public class UserSpecialityRepository : Repository<UserSpeciality>, IUserSpecialityRepository
    {
        private ApplicationDbContext _db;
        public UserSpecialityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UserSpeciality obj)
        {
            _db.UserSpecialities.Update(obj);
        }

        

    }
}

