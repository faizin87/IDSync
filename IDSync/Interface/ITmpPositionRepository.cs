using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface ITmpPositionRepository : IDisposable
    {
        IEnumerable<TmpPosition> Get();
        void Insert(TmpPosition TmpPosition);
        TmpPosition GetByID(int TmpPositionID);
        void Delete(int TmpPositionID);
        void Update(TmpPosition TmpPosition);
        void Save();
    }
}
