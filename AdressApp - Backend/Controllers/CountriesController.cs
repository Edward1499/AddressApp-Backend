using AddressApp.BLL.DTOs;
using AddressApp.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressApp___Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService countriesService;
        public CountriesController(ICountriesService countryService)
        {
            countriesService = countryService;
        }
        public ActionResult<List<GetlAllCountriesDto>> Index()
        {
            return Ok(countriesService.GetlAll());
        }
    }
}
