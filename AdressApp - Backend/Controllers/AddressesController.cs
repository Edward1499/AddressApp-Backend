using AddressApp.BLL.DTOs;
using AddressApp.BLL.DTOs.Addresses;
using AddressApp.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressApp___Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressesService addressesService;
        public AddressesController(IAddressesService addressesService)
        {
            this.addressesService = addressesService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }

        [HttpGet("GetAllByUserId/{id}")]
        public ActionResult<List<AddressResponseDto>> GetAllByUserId(int id)
        {
            return Ok(addressesService.GetAllByUserId(id));
        }

        [HttpPost]
        public ActionResult Create(AddressRequestDto request)
        {
            addressesService.Create(request);
            return StatusCode(201);
        }

        [HttpPut]
        public ActionResult Update(UpdateAddressRequestDto request)
        {
            addressesService.Update(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            addressesService.Delete(id);
            return Ok();
        }
    }
}
