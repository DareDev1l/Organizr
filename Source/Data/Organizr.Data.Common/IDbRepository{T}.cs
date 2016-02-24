namespace Organizr.Data.Common
{
    using System.Linq;

    using Organizr.Data.Common.Models;

    public interface IDbRepository<T> : IDbRepository<T, int>
        where T : class
    {
    }

    public interface IDbRepository<T, in TKey>
        where T : class
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}
