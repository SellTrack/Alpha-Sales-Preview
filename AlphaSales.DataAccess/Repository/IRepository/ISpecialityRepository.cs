using System;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository.IRepository
{
    public interface ISpecialityRepository : IRepository<Speciality>
    {
        void Update(Speciality obj);
    }
}

