using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface IUsersRepository : IDisposable
    {
        IEnumerable<Users> Get();
        void Insert(Users Users);
        Users GetByID(int UsersID);
        void Delete(int UsersID);
        void Update(Users Users);
        void Save();
    }
}
