using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IAppSchemaRepository : IDisposable
    {
        IEnumerable<AppSchema> Get();
        void Insert(AppSchema AppSchema);
        AppSchema GetByID(int AppSchemaID);
        void Delete(int AppSchemaID);
        void Update(AppSchema AppSchema);
        void Save();
    }
}
