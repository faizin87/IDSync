using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class AppSyncOrderRepository : IAppSyncOrderRepository, IDisposable
    {
        private Dal context;

        public AppSyncOrderRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<AppSyncOrder> Get()
        {
            return context.AppSyncOrder.ToList();
        }

        public AppSyncOrder GetByID(int AppSyncOrderID)
        {
            return context.AppSyncOrder.Find(AppSyncOrderID);
        }

        public void Insert(AppSyncOrder AppSyncOrder)
        {
            context.AppSyncOrder.Add(AppSyncOrder);
        } 

        public void Update(AppSyncOrder AppSyncOrder)
        {
            context.Entry(AppSyncOrder).State = EntityState.Modified;
        }

        public void Delete(int AppSyncOrderID)
        {
            AppSyncOrder AppSyncOrder = context.AppSyncOrder.Find(AppSyncOrderID);
            context.AppSyncOrder.Remove(AppSyncOrder);
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