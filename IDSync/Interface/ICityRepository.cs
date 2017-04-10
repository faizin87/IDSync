using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface ICityRepository : IDisposable
    {
        IEnumerable<City> Get();
        void Insert(City City);
        City GetByID(int CityID);
        void Delete(int CityID);
        void Update(City City);
        void Save();
    }
}
