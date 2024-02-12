using System;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository.IRepository
{
    public interface IExerciseRepository : IRepository<ExercisePlan>
    {
        void Update(ExercisePlan obj);
    }
}

