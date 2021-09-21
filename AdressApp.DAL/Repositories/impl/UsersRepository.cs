using AddressApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AddressApp.DAL.Repositories.impl
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AddressContext context;
        public UsersRepository(AddressContext context)
        {
            this.context = context;
        }
        public void Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }
        public User Get(Expression<Func<User, bool>> predicate)
        {
            return context.Users.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public bool Any(Expression<Func<User, bool>> predicate)
        {
            return context.Users.Any(predicate);
        }

        public void Update(User entity)
        {
            context.Users.Update(entity);
            context.SaveChanges();
        }

        public List<GetAllUsersSp> GetAllUsers()
        {
            return context.GetAllUsersSp
                     .FromSqlRaw(@"Execute dbo.GetAllUsers_sp")
                     .ToList();
        }
    }
}
