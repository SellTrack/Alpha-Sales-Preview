using System;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository.IRepository
{
    public interface IUserExerciseRepository : IRepository<UserExercisePlan>
    {
        void Update(UserExercisePlan obj);
    }
}

