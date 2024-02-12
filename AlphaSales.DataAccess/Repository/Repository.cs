using System;
using System.Linq.Expressions;
using AlphaSales.DataAccess.Data;
using AlphaSales.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AlphaSales.DataAccess.Repository

{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.UserSpecialities.Include(u => u.Speciality).Include(u => u.Speciality_id);
            _db.UserSpecialities.Include(u => u.ApplicationUser).Include(u => u.User_id);
            _db.ExercisePlans.Include(u => u.ApplicationUser).Include(u => u.Coach_id);
            _db.UserExercisePlans.Include(u => u.ApplicationUser).Include(u => u.Client_id);
            _db.UserExercisePlans.Include(u => u.ExercisePlan).Include(u => u.Exercise_id);

        }


        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}

