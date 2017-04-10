using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface ILogsRepository : IDisposable
    {
        IEnumerable<Logs> Get();
        void Insert(Logs Logs);
        Logs GetByID(int LogsID);
        void Delete(int LogsID);
        void Update(Logs Logs);
        void Save();
    }
}
