using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IAppSyncOrderRepository : IDisposable
    {
        IEnumerable<AppSyncOrder> Get();
        void Insert(AppSyncOrder AppSyncOrder);
        AppSyncOrder GetByID(int AppSyncOrderID);
        void Delete(int AppSyncOrderID);
        void Update(AppSyncOrder AppSyncOrder);
        void Save();
    }
}
