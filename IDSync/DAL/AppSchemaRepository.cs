using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class AppSchemaRepository : IAppSchemaRepository, IDisposable
    {
        private Dal context;

        public AppSchemaRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<AppSchema> Get()
        {
            return context.AppSchema.ToList();
        }

        public AppSchema GetByID(int AppSchemaID)
        {
            return context.AppSchema.Find(AppSchemaID);
        }

        public void Insert(AppSchema AppSchema)
        {
            context.AppSchema.Add(AppSchema);
        } 

        public void Update(AppSchema AppSchema)
        {
            context.Entry(AppSchema).State = EntityState.Modified;
        }

        public void Delete(int AppSchemaID)
        {
            AppSchema AppSchema = context.AppSchema.Find(AppSchemaID);
            context.AppSchema.Remove(AppSchema);
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