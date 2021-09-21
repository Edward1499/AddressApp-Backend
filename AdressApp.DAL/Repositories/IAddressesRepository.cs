using AddressApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AddressApp.DAL.Repositories
{
    public interface IAddressesRepository
    {
        void Add(Address entity);
        void Update(Address entity);
        void Delete(Address entity);
        List<AddressSp> GetAllByUserId(int userId);
        Address Get(Expression<Func<Address, bool>> predicate);
    }
}
