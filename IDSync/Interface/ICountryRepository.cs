using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface ICountryRepository : IDisposable
    {
        IEnumerable<Country> Get();
        void Insert(Country Country);
        Country GetByID(int CountryID);
        void Delete(int CountryID);
        void Update(Country Country);
        void Save();
    }
}
