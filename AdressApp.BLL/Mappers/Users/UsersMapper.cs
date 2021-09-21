using AddressApp.BLL.DTOs.Users;
using AddressApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.BLL.Mappers.Users
{
    public static class UsersMapper
    {
        public static User Map(UserRequestDto user)
        {
            return new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Password = user.Password,
                UserRoleId = user.UserRoleId
            };
        }

        public static UserResponseDto Map(User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserRoleId = user.UserRoleId,
            };
        }

        public static UserRequestDto Map(UserCreateRequestDto request)
        {
            return new UserRequestDto
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = request.Password,
                Photo = request.Photo,
            };
        }

        public static UserLoginDto Map(UserLoginRequestDto user)
        {
            return new UserLoginDto
            {
                Email = user.Email,
                Password = user.Password
            };
        }

        public static List<GetAllUsersResponseDto> Map(List<GetAllUsersSp> users)
        {
            List<GetAllUsersResponseDto> userList = new List<GetAllUsersResponseDto>();

            foreach (var user in users)
                userList.Add(new GetAllUsersResponseDto 
                { 
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Status = user.Status
                });

            return userList;
        }
    }
}
