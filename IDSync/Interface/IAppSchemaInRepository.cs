using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IAppSchemaInRepository : IDisposable
    {
        IEnumerable<AppSchemaIn> Get();
        void Insert(AppSchemaIn AppSchemaIn);
        AppSchemaIn GetByID(int AppSchemaInID);
        void Delete(int AppSchemaInID);
        void Update(AppSchemaIn AppSchemaIn);
        void Save();
    }
}
