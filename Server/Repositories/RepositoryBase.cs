using System.Linq.Expressions;

using FlightManagement.Server.Data;
using FlightManagement.Server.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Server.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext context;

        public RepositoryBase(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity) => context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? context.Set<T>().AsNoTracking() : context.Set<T>();

        public IQueryable<T> FindBy(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? context.Set<T>().Where(expression).AsNoTracking() :
                context.Set<T>().Where(expression);

        public void Update(T entity) => context.Set<T>().Update(entity);
    }
}
