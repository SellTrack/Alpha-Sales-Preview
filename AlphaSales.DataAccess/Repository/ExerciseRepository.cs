using System;
using System.Linq.Expressions;
using AlphaSales.DataAccess.Data;
using AlphaSales.DataAccess.Repository.IRepository;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository
{
    public class ExerciseRepository : Repository<ExercisePlan>, IExerciseRepository
    {
        private ApplicationDbContext _db;
        public ExerciseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ExercisePlan obj)
        {
            _db.ExercisePlans.Update(obj);
        }

        

    }
}

