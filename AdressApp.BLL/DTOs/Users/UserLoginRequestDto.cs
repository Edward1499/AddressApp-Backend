﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressApp.BLL.DTOs.Users
{
    public class UserLoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
