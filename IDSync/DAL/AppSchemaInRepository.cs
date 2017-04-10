using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class AppSchemaInRepository : IAppSchemaInRepository, IDisposable
    {
        private Dal context;

        public AppSchemaInRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<AppSchemaIn> Get()
        {
            return context.AppSchemaIn.ToList();
        }

        public AppSchemaIn GetByID(int AppSchemaInID)
        {
            return context.AppSchemaIn.Find(AppSchemaInID);
        }

        public void Insert(AppSchemaIn AppSchemaIn)
        {
            context.AppSchemaIn.Add(AppSchemaIn);
        } 

        public void Update(AppSchemaIn AppSchemaIn)
        {
            context.Entry(AppSchemaIn).State = EntityState.Modified;
        }

        public void Delete(int AppSchemaInID)
        {
            AppSchemaIn AppSchemaIn = context.AppSchemaIn.Find(AppSchemaInID);
            context.AppSchemaIn.Remove(AppSchemaIn);
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