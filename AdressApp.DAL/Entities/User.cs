using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public int UserRoleId { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
