using System;
using System.Collections.Generic;
using System.Linq;
using IDSync.Models;
using IDSync.Interface; 
using System.Data.Entity;

namespace IDSync.DAL
{
    public class UsersRepository : IUsersRepository, IDisposable
    {
        private Dal context;

        public UsersRepository(Dal context) {
            this.context = context; 
        } 

        public IEnumerable<Users> Get()
        {
            return context.Users.ToList();
        }

        public Users GetByID(int UsersID)
        {
            return context.Users.Find(UsersID);
        }

        public void Insert(Users Users)
        {
            context.Users.Add(Users);
        } 

        public void Update(Users Users)
        {
            context.Entry(Users).State = EntityState.Modified;
        }

        public void Delete(int UsersID)
        {
            Users Users = context.Users.Find(UsersID);
            context.Users.Remove(Users);
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