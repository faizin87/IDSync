using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IAppSchemaOutRepository : IDisposable
    {
        IEnumerable<AppSchemaOut> Get();
        void Insert(AppSchemaOut AppSchemaOut);
        AppSchemaOut GetByID(int AppSchemaOutID);
        void Delete(int AppSchemaOutID);
        void Update(AppSchemaOut AppSchemaOut);
        void Save();
    }
}
