using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class CityRepository : ICityRepository, IDisposable
    {
        private Dal context;

        public CityRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<City> Get()
        {
            return context.City.ToList();
        }

        public City GetByID(int CityID)
        {
            return context.City.Find(CityID);
        }

        public void Insert(City City)
        {
            context.City.Add(City);
        } 

        public void Update(City City)
        {
            context.Entry(City).State = EntityState.Modified;
        }

        public void Delete(int CityID)
        {
            City City = context.City.Find(CityID);
            context.City.Remove(City);
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