using AddressApp.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.BLL.Services
{
    public interface ICountriesService
    {
        List<GetlAllCountriesDto> GetlAll();
    }
}
