using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation.dal
{
    public interface IDataRepository<TEntity> : IDisposable
    {
        IQueryable<TEntity> Fetch();
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        TEntity Single(Func<TEntity, bool> predicate);
        TEntity First(Func<TEntity, bool> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Attach(TEntity entity);
        void Update(TEntity entity);
        void SaveChanges();
        void SaveChanges(SaveOptions options);
        bool LazyLoadingEnabled { get; set; }
    }
}
