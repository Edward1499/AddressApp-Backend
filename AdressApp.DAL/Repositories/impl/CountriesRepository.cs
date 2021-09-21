using AddressApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressApp.DAL.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly AddressContext dbContext;
        public CountriesRepository(AddressContext context)
        {
            dbContext = context;
        }

        public List<Country> GetAll()
        {
            return dbContext.Countries.ToList();
        }
    }
}
