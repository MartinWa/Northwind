using System;
using System.Collections;

namespace Northwind.Data.EntityFramework
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DataContext _context;
        private bool _disposed;
        private readonly Hashtable _repositories;

        public UnitOfWork()
        {
            _context = new DataContext();

            // Do NOT enable proxied entities, else serialization fails
            _context.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            _context.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            _context.Configuration.ValidateOnSaveEnabled = false;

            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
            //_context.Configuration.AutoDetectChangesEnabled = false;

            _repositories = new Hashtable();
        }
        //public IRepository<Node> Nodes { get { return Repository<Node>(); } }

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepository<T>)_repositories[type];
            }
            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context));
            return (IRepository<T>)_repositories[type];
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}