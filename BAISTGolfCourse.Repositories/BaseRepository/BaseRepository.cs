using BAISTGolfCourse.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Repositories.BaseRepository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ClubBAISTEntities DbContext;

        protected readonly IDbSet<T> DbSet;

        protected BaseRepository(DbContext context)
        {
            DbContext = context as ClubBAISTEntities;
            DbSet = DbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().AsEnumerable();
        }

        public T GetSingle(int ID)
        {
            return DbContext.Set<T>().Find(ID);
        }

        public T FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().SingleOrDefault(predicate);
        }

        public async Task<T> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            try
            {
                var entry = DbContext.Entry(entity);

                DbContext.Set<T>().Attach(entity);
                entry.State = EntityState.Modified;
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        public void SaveChanges()
        {
            try
            {
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }


        IEnumerable<T> IRepository<T>.FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).AsEnumerable();
        }
    }
}
