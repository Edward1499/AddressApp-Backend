using AddressApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq.Expressions;

namespace AddressApp.DAL.Repositories.impl
{
    public class AddressesRepository : IAddressesRepository
    {
        private readonly AddressContext context;
        public AddressesRepository(AddressContext context)
        {
            this.context = context;
        }

        public void Add(Address entity)
        {
            context.Addresses.Add(entity);
            context.SaveChanges();
        }

        public void Update(Address entity)
        {
            context.Addresses.Update(entity);
            context.SaveChanges();
        }

        public Address Get(Expression<Func<Address, bool>> predicate)
        {
            return context.Addresses.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public void Delete(Address entity)
        {
            context.Addresses.Remove(entity);
            context.SaveChanges();
        }

        public List<AddressSp> GetAllByUserId(int userId)
        {
            SqlParameter[] sqlparams = {
                                            new SqlParameter("@UserId", userId),
                                        };

            return context.AddressSp
                     .FromSqlRaw(@"Execute dbo.GetAddressesByUserId_sp @UserId", sqlparams)
                                                                        .ToList();
        }
    }
}
