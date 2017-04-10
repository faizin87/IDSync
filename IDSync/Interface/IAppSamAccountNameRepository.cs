using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IAppSamAccountNameRepository : IDisposable
    {
        IEnumerable<AppSamAccountName> Get();
        void Insert(AppSamAccountName AppSamAccountName);
        AppSamAccountName GetByID(int AppSamAccountNameID);
        void Delete(int AppSamAccountNameID);
        void Update(AppSamAccountName AppSamAccountName);
        void Save();
    }
}
