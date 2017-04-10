using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class GroupsRepository : IGroupsRepository, IDisposable
    {
        private Dal context;

        public GroupsRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<Groups> Get()
        {
            return context.Groups.ToList();
        }

        public Groups GetByID(int GroupsID)
        {
            return context.Groups.Find(GroupsID);
        }

        public void Insert(Groups Groups)
        {
            context.Groups.Add(Groups);
        } 

        public void Update(Groups Groups)
        {
            context.Entry(Groups).State = EntityState.Modified;
        }

        public void Delete(int GroupsID)
        {
            Groups Groups = context.Groups.Find(GroupsID);
            context.Groups.Remove(Groups);
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