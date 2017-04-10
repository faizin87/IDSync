using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class AppSyncRepository : IAppSyncRepository, IDisposable
    {
        private Dal context;

        public AppSyncRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<AppSync> Get()
        {
            return context.AppSync.ToList();
        }

        public AppSync GetByID(int AppSyncID)
        {
            return context.AppSync.Find(AppSyncID);
        }

        public void Insert(AppSync AppSync)
        {
            context.AppSync.Add(AppSync);
        } 

        public void Update(AppSync AppSync)
        {
            context.Entry(AppSync).State = EntityState.Modified;
        }

        public void Delete(int AppSyncID)
        {
            AppSync AppSync = context.AppSync.Find(AppSyncID);
            context.AppSync.Remove(AppSync);
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}