using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaSales.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
       ISpecialityRepository Speciality { get; }
       IUserSpecialityRepository UserSpeciality { get; }
       IExerciseRepository Exercise { get; }
       IUserExerciseRepository UserExercise { get; }
        void Save();
    }
}
