using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.DAL.Entities
{
    public class GetAllUsersSp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
