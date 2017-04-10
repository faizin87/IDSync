using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class AuthGroupRepository : IAuthGroupRepository, IDisposable
    {
        private Dal context;

        public AuthGroupRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<AuthGroup> Get()
        {
            return context.AuthGroup.ToList();
        }

        public AuthGroup GetByID(int AuthGroupID)
        {
            return context.AuthGroup.Find(AuthGroupID);
        }

        public void Insert(AuthGroup AuthGroup)
        {
            context.AuthGroup.Add(AuthGroup);
        } 

        public void Update(AuthGroup AuthGroup)
        {
            context.Entry(AuthGroup).State = EntityState.Modified;
        }

        public void Delete(int AuthGroupID)
        {
            AuthGroup AuthGroup = context.AuthGroup.Find(AuthGroupID);
            context.AuthGroup.Remove(AuthGroup);
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