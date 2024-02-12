using System;
using AlphaSales.Models;

namespace AlphaSales.DataAccess.Repository.IRepository
{
    public interface IUserSpecialityRepository : IRepository<UserSpeciality>
    {
        void Update(UserSpeciality obj);
    }
}

