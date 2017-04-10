using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class AppRepository : IAppRepository, IDisposable
    {
        private Dal context;

        public AppRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<App> Get()
        {
            return context.App.ToList();
        }

        public App GetByID(int AppID)
        {
            return context.App.Find(AppID);
        }

        public void Insert(App App)
        {
            context.App.Add(App);
        } 

        public void Update(App App)
        {
            context.Entry(App).State = EntityState.Modified;
        }

        public void Delete(int AppID)
        {
            App App = context.App.Find(AppID);
            context.App.Remove(App);
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