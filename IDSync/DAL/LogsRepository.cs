using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class LogsRepository : ILogsRepository, IDisposable
    {
        private Dal context;

        public LogsRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<Logs> Get()
        {
            return context.Logs.ToList();
        }

        public Logs GetByID(int LogsID)
        {
            return context.Logs.Find(LogsID);
        }

        public void Insert(Logs Logs)
        {
            context.Logs.Add(Logs);
        } 

        public void Update(Logs Logs)
        {
            context.Entry(Logs).State = EntityState.Modified;
        }

        public void Delete(int LogsID)
        {
            Logs Logs = context.Logs.Find(LogsID);
            context.Logs.Remove(Logs);
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}