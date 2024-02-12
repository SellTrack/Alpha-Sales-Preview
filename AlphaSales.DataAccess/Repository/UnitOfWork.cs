using AlphaSales.DataAccess.Data;
using AlphaSales.DataAccess.Repository.IRepository;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ISpecialityRepository Speciality { get; private set; }
        public IUserSpecialityRepository UserSpeciality { get; private set; }
        public IExerciseRepository Exercise { get; private set; }
        public IUserExerciseRepository UserExercise { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Speciality = new SpecialityRepository(_db);
            UserSpeciality = new UserSpecialityRepository(_db);
            Exercise = new ExerciseRepository(_db);
            UserExercise = new UserExerciseRepository(_db);
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
