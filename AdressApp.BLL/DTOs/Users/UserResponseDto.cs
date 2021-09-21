using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.BLL.DTOs.Users
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
        public string Token { get; set; }
        public string Image { get; set; }
    }
}
