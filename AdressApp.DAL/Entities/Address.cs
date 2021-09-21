using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.DAL.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Sector { get; set; }
        public string Reference { get; set; }
        public int PostalCode { get; set; }
    }
}
