using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IAppSyncRepository : IDisposable
    {
        IEnumerable<AppSync> Get();
        void Insert(AppSync AppSync);
        AppSync GetByID(int AppSyncID);
        void Delete(int AppSyncID);
        void Update(AppSync AppSync);
        void Save();
    }
}
