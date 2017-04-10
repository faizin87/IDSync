using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class AuthLinkRepository : IAuthLinkRepository, IDisposable
    {
        private Dal context;

        public AuthLinkRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<AuthLink> Get()
        {
            return context.AuthLink.ToList();
        }

        public AuthLink GetByID(int AuthLinkID)
        {
            return context.AuthLink.Find(AuthLinkID);
        }

        public void Insert(AuthLink AuthLink)
        {
            context.AuthLink.Add(AuthLink);
        } 

        public void Update(AuthLink AuthLink)
        {
            context.Entry(AuthLink).State = EntityState.Modified;
        }

        public void Delete(int AuthLinkID)
        {
            AuthLink AuthLink = context.AuthLink.Find(AuthLinkID);
            context.AuthLink.Remove(AuthLink);
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