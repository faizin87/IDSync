using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class CountryRepository : ICountryRepository, IDisposable
    {
        private Dal context;

        public CountryRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<Country> Get()
        {
            return context.Country.ToList();
        }

        public Country GetByID(int CountryID)
        {
            return context.Country.Find(CountryID);
        }

        public void Insert(Country Country)
        {
            context.Country.Add(Country);
        } 

        public void Update(Country Country)
        {
            context.Entry(Country).State = EntityState.Modified;
        }

        public void Delete(int CountryID)
        {
            Country Country = context.Country.Find(CountryID);
            context.Country.Remove(Country);
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