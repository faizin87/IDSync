using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IProvinceRepository : IDisposable
    {
        IEnumerable<Province> Get();
        void Insert(Province Province);
        Province GetByID(int ProvinceID);
        void Delete(int ProvinceID);
        void Update(Province Province);
        void Save();
    }
}
