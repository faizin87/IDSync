using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class AppSchemaOutRepository : IAppSchemaOutRepository, IDisposable
    {
        private Dal context;

        public AppSchemaOutRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<AppSchemaOut> Get()
        {
            return context.AppSchemaOut.ToList();
        }

        public AppSchemaOut GetByID(int AppSchemaOutID)
        {
            return context.AppSchemaOut.Find(AppSchemaOutID);
        }

        public void Insert(AppSchemaOut AppSchemaOut)
        {
            context.AppSchemaOut.Add(AppSchemaOut);
        } 

        public void Update(AppSchemaOut AppSchemaOut)
        {
            context.Entry(AppSchemaOut).State = EntityState.Modified;
        }

        public void Delete(int AppSchemaOutID)
        {
            AppSchemaOut AppSchemaOut = context.AppSchemaOut.Find(AppSchemaOutID);
            context.AppSchemaOut.Remove(AppSchemaOut);
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