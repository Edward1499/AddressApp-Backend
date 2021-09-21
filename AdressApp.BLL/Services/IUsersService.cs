using AddressApp.BLL.DTOs.Users;
using System.Collections.Generic;

namespace AddressApp.BLL.Services
{
    public interface IUsersService
    {
        List<GetAllUsersResponseDto> GetAllUsers();
        UserResponseDto CreateUser(UserRequestDto user);
        UserResponseDto Login(UserLoginDto user);
        void DisableUser(int userId);
        void EnableUser(int userId);
        // UserResponseDto GetById(int id);
    }
}
