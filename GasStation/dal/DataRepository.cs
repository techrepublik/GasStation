using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using GasStation.dal.data;

namespace GasStation.dal
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        public bool LazyLoadingEnabled { get; set; }

        private readonly DbContext _context;

        private readonly DbSet<TEntity> _objectSet;

        public DataRepository()
            : this(new GasModel())
        {
        }

        private DataRepository(DbContext context)
        {
            var adapter = (IObjectContextAdapter) context;
            adapter.ObjectContext.ContextOptions.LazyLoadingEnabled = LazyLoadingEnabled;
            _context = context;
            _objectSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Fetch()
        {
            return _objectSet;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Fetch().AsEnumerable();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _objectSet.Where(predicate);
        }

        public TEntity Single(Func<TEntity, bool> predicate)
        {
            return _objectSet.SingleOrDefault(predicate);
        }

        public TEntity First(Func<TEntity, bool> predicate)
        {
            return _objectSet.First(predicate);
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _objectSet.Attach(entity);
            //_objectSet.DeleteObject(entity);
            _objectSet.Remove(entity);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            IEnumerable<TEntity> records = from x in _objectSet.Where(predicate) select x;

            foreach (TEntity record in records)
            {
                //_objectSet.DeleteObject(record);
                _objectSet.Remove(record);
            }
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            //_objectSet.AddObject(entity);
            _objectSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.Attach(entity);
            //_context.ObjectStateManager.ChangeObjectState(entity, System.Data.Entity.EntityState.Modified);
            var adapter = (IObjectContextAdapter) _context;
            adapter.ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            //_context
        }

        public void Attach(TEntity entity)
        {
            _objectSet.Attach(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SaveChanges(SaveOptions options)
        {
            //_context.SaveChanges(options);
            _context.SaveChanges();
        }

        private bool _disposedValue;

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state here if required
                }
                // dispose unmanaged objects and set large fields to null
            }
            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Cached ObjectSets so changes persist
        private readonly Dictionary<string, object> _cachedObjects = new Dictionary<string, object>();

        private ObjectSet<T> GetObjectSet<T>() where T : EntityObject
        {
            var fulltypename = typeof (T).AssemblyQualifiedName;
            if (fulltypename == null)
                throw new ArgumentException("Invalid Type passed to GetObjectSet!");
            if (!_cachedObjects.ContainsKey(fulltypename))
            {
                //var objectset = _context.CreateObjectSet<T>();
                var objectset = _context.Set<T>();
                _cachedObjects.Add(fulltypename, objectset);
            }
            return _cachedObjects[fulltypename] as ObjectSet<T>;
        }

        public IQueryable<T> Fetch<T>() where T : EntityObject
        {
            return GetObjectSet<T>();
        }
    }
}
