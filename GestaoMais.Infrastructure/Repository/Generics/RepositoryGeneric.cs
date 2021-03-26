using GestaoMais.Domain.Interfaces.Generics;
using GestaoMais.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace GestaoMais.Infrastructure.Repository.Generics
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryGeneric()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        private bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                handle.Dispose();

            disposed = true;
        }

        public async Task Add(T obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<T>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task Update(T obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<T>().Update(obj);
                await data.SaveChangesAsync();
            }
        }
    }
}
