using System;
using System.Linq.Expressions;
using AlphaSales.DataAccess.Data;
using AlphaSales.DataAccess.Repository.IRepository;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository
{
    public class UserExerciseRepository : Repository<UserExercisePlan>, IUserExerciseRepository
    {
        private ApplicationDbContext _db;
        public UserExerciseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UserExercisePlan obj)
        {
            _db.UserExercisePlans.Update(obj);
        }

        

    }
}

