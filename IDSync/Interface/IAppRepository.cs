using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IAppRepository : IDisposable
    {
        IEnumerable<App> Get();
        void Insert(App App);
        App GetByID(int AppID);
        void Delete(int AppID);
        void Update(App App);
        void Save();
    }
}
