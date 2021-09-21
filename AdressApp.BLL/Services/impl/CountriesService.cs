using AddressApp.BLL.DTOs;
using AddressApp.BLL.Mappers;
using AddressApp.DAL.Entities;
using AddressApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.BLL.Services.impl
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepository countriesRepository;
        public CountriesService(ICountriesRepository countries)
        {
            countriesRepository = countries;
        }

        public List<GetlAllCountriesDto> GetlAll()
        {
            return CountriesMapper.Map(countriesRepository.GetAll());
        }
    }
}
