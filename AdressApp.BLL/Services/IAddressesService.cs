using AddressApp.BLL.DTOs;
using AddressApp.BLL.DTOs.Addresses;
using System.Collections.Generic;

namespace AddressApp.BLL.Services
{
    public interface IAddressesService
    {
        void Create(AddressRequestDto request);
        void Update(UpdateAddressRequestDto request);
        void Delete(int id);
        List<AddressResponseDto> GetAllByUserId(int userId);
    }
}
