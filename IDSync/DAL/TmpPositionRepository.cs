using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class TmpPositionRepository : ITmpPositionRepository, IDisposable
    {
        private Dal context;

        public TmpPositionRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<TmpPosition> Get()
        {
            return context.TmpPosition.ToList();
        }

        public TmpPosition GetByID(int TmpPositionID)
        {
            return context.TmpPosition.Find(TmpPositionID);
        }

        public void Insert(TmpPosition TmpPosition)
        {
            context.TmpPosition.Add(TmpPosition);
        } 

        public void Update(TmpPosition TmpPosition)
        {
            context.Entry(TmpPosition).State = EntityState.Modified;
        }

        public void Delete(int TmpPositionID)
        {
            TmpPosition TmpPosition = context.TmpPosition.Find(TmpPositionID);
            context.TmpPosition.Remove(TmpPosition);
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