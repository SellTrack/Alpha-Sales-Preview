using System;
using System.Linq.Expressions;
using AlphaSales.DataAccess.Data;
using AlphaSales.DataAccess.Repository.IRepository;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository
{
    public class SpecialityRepository : Repository<Speciality>, ISpecialityRepository
    {
        private ApplicationDbContext _db;
        public SpecialityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Speciality obj)
        {
            _db.Specialities.Update(obj);
        }

        

    }
}

