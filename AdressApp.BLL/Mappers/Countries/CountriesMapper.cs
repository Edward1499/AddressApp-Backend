using AddressApp.BLL.DTOs;
using AddressApp.DAL.Entities;
using System.Collections.Generic;

namespace AddressApp.BLL.Mappers
{
    public static class CountriesMapper
    {
        public static List<GetlAllCountriesDto> Map(List<Country> countries)
        {
            List<GetlAllCountriesDto> countriesList = new List<GetlAllCountriesDto>();

            foreach (Country country in countries)
                countriesList.Add(new GetlAllCountriesDto
                {
                    Id = country.Id,
                    Name = country.Name
                });

            return countriesList;
        }
    }
}
