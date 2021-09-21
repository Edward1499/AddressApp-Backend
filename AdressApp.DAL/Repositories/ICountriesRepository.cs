using AddressApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.DAL.Repositories
{
    public interface ICountriesRepository
    {
        List<Country> GetAll();
    }
}
