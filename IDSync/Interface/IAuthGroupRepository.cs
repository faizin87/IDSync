using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IAuthGroupRepository : IDisposable
    {
        IEnumerable<AuthGroup> Get();
        void Insert(AuthGroup AuthGroup);
        AuthGroup GetByID(int AuthGroupID);
        void Delete(int AuthGroupID);
        void Update(AuthGroup AuthGroup);
        void Save();
    }
}
