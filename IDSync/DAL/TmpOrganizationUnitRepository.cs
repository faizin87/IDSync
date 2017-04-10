using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class TmpOrganizationUnitRepository : ITmpOrganizationUnitRepository, IDisposable
    {
        private Dal context;

        public TmpOrganizationUnitRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<TmpOrganizationUnit> Get()
        {
            return context.TmpOrganizationUnit.ToList();
        }

        public TmpOrganizationUnit GetByID(int TmpOrganizationUnitID)
        {
            return context.TmpOrganizationUnit.Find(TmpOrganizationUnitID);
        }

        public void Insert(TmpOrganizationUnit TmpOrganizationUnit)
        {
            context.TmpOrganizationUnit.Add(TmpOrganizationUnit);
        } 

        public void Update(TmpOrganizationUnit TmpOrganizationUnit)
        {
            context.Entry(TmpOrganizationUnit).State = EntityState.Modified;
        }

        public void Delete(int TmpOrganizationUnitID)
        {
            TmpOrganizationUnit TmpOrganizationUnit = context.TmpOrganizationUnit.Find(TmpOrganizationUnitID);
            context.TmpOrganizationUnit.Remove(TmpOrganizationUnit);
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