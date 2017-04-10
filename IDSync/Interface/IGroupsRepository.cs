using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IGroupsRepository : IDisposable
    {
        IEnumerable<Groups> Get();
        void Insert(Groups Groups);
        Groups GetByID(int GroupsID);
        void Delete(int GroupsID);
        void Update(Groups Groups);
        void Save();
    }
}
