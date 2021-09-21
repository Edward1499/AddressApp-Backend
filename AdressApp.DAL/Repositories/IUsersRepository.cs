using AddressApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AddressApp.DAL.Repositories
{
    public interface IUsersRepository
    {
        User Get(Expression<Func<User, bool>> predicate);
        List<GetAllUsersSp> GetAllUsers();
        void Add(User entity);
        bool Any(Expression<Func<User, bool>> predicate);
        public void Update(User entity);
    }
}
