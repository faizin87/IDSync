using System;
using System.Collections.Generic;
using IDSync.Models;

namespace IDSync.Interface
{
    public interface ITmpOrganizationUnitRepository : IDisposable
    {
        IEnumerable<TmpOrganizationUnit> Get();
        void Insert(TmpOrganizationUnit TmpOrganizationUnit);
        TmpOrganizationUnit GetByID(int TmpOrganizationUnitID);
        void Delete(int TmpOrganizationUnitID);
        void Update(TmpOrganizationUnit TmpOrganizationUnit);
        void Save();
    }
}
