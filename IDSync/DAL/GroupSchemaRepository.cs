using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class GroupSchemaRepository : IGroupSchemaRepository, IDisposable
    {
        private Dal context;

        public GroupSchemaRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<GroupSchema> Get()
        {
            return context.GroupSchema.ToList();
        }

        public GroupSchema GetByID(int GroupSchemaID)
        {
            return context.GroupSchema.Find(GroupSchemaID);
        }

        public void Insert(GroupSchema GroupSchema)
        {
            context.GroupSchema.Add(GroupSchema);
        } 

        public void Update(GroupSchema GroupSchema)
        {
            context.Entry(GroupSchema).State = EntityState.Modified;
        }

        public void Delete(int GroupSchemaID)
        {
            GroupSchema GroupSchema = context.GroupSchema.Find(GroupSchemaID);
            context.GroupSchema.Remove(GroupSchema);
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