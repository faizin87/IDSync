using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class ProvinceRepository : IProvinceRepository, IDisposable
    {
        private Dal context;

        public ProvinceRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<Province> Get()
        {
            return context.Province.ToList();
        }

        public Province GetByID(int ProvinceID)
        {
            return context.Province.Find(ProvinceID);
        }

        public void Insert(Province Province)
        {
            context.Province.Add(Province);
        } 

        public void Update(Province Province)
        {
            context.Entry(Province).State = EntityState.Modified;
        }

        public void Delete(int ProvinceID)
        {
            Province Province = context.Province.Find(ProvinceID);
            context.Province.Remove(Province);
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