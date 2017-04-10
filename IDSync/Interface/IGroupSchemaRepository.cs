using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IGroupSchemaRepository : IDisposable
    {
        IEnumerable<GroupSchema> Get();
        void Insert(GroupSchema GroupSchema);
        GroupSchema GetByID(int GroupSchemaID);
        void Delete(int GroupSchemaID);
        void Update(GroupSchema GroupSchema);
        void Save();
    }
}
