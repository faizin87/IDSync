using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IAuthLinkRepository : IDisposable
    {
        IEnumerable<AuthLink> Get();
        void Insert(AuthLink AuthLink);
        AuthLink GetByID(int AuthLinkID);
        void Delete(int AuthLinkID);
        void Update(AuthLink AuthLink);
        void Save();
    }
}
