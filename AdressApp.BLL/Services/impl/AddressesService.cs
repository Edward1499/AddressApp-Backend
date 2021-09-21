using AddressApp.BLL.DTOs;
using AddressApp.BLL.DTOs.Addresses;
using AddressApp.BLL.Exceptions;
using AddressApp.BLL.Mappers;
using AddressApp.DAL;
using AddressApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.BLL.Services.impl
{
    public class AddressesService : IAddressesService
    {
        private readonly IAddressesRepository addressesRepository;
        public AddressesService(IAddressesRepository addressesRepository)
        {
            this.addressesRepository = addressesRepository;
        }
        public void Create(AddressRequestDto request)
        {
            addressesRepository.Add(AddressesMapper.Map(request));
        }

        public void Update(UpdateAddressRequestDto request)
        {
            var address = addressesRepository.Get(x => x.Id == request.Id);

            if (address == null)
                throw new RecordNotExistingException("Registro no existente");

            address.CountryId = request.CountryId;
            address.City = request.City;
            address.Street = request.Street;
            address.Sector = request.Sector;
            address.Reference = request.Reference;
            address.PostalCode = request.PostalCode;

            addressesRepository.Update(address);
        }

        public void Delete(int id)
        {
            var address = addressesRepository.Get(x => x.Id == id);

            if (address == null)
                throw new RecordNotExistingException("Registro no existente");

            addressesRepository.Delete(address);
        }

        public List<AddressResponseDto> GetAllByUserId(int userId)
        {
            return AddressesMapper.Map(addressesRepository.GetAllByUserId(userId));
        }
    }
}
