using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class AppSamAccountNameRepository : IAppSamAccountNameRepository, IDisposable
    {
        private Dal context;

        public AppSamAccountNameRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<AppSamAccountName> Get()
        {
            return context.AppSamAccountName.ToList();
        }

        public AppSamAccountName GetByID(int AppSamAccountNameID)
        {
            return context.AppSamAccountName.Find(AppSamAccountNameID);
        }

        public void Insert(AppSamAccountName AppSamAccountName)
        {
            context.AppSamAccountName.Add(AppSamAccountName);
        } 

        public void Update(AppSamAccountName AppSamAccountName)
        {
            context.Entry(AppSamAccountName).State = EntityState.Modified;
        }

        public void Delete(int AppSamAccountNameID)
        {
            AppSamAccountName AppSamAccountName = context.AppSamAccountName.Find(AppSamAccountNameID);
            context.AppSamAccountName.Remove(AppSamAccountName);
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