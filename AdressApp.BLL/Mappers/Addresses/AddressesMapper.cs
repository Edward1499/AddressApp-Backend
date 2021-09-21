using AddressApp.BLL.DTOs;
using AddressApp.BLL.DTOs.Addresses;
using AddressApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.BLL.Mappers
{
    public static class AddressesMapper
    {
        public static Address Map(AddressRequestDto request)
        {
            return new Address
            {
                CountryId = request.CountryId,
                UserId = request.UserId,
                City = request.City,
                Street = request.Street,
                Sector = request.Sector,
                Reference = request.Reference,
                PostalCode = request.PostalCode
            };
        }

        public static List<AddressResponseDto> Map(List<AddressSp> addresses)
        {
            List<AddressResponseDto> addressesList = new List<AddressResponseDto>();

            foreach (var address in addresses)
                addressesList.Add(new AddressResponseDto
                {
                    Id = address.Id,
                    UserId = address.UserId,
                    CountryId = address.CountryId,
                    Country = address.Country,
                    City = address.City,
                    Street = address.Street,
                    Sector = address.Sector,
                    Reference = address.Reference,
                    PostalCode = address.PostalCode
                });

            return addressesList;
        }
    }
}
