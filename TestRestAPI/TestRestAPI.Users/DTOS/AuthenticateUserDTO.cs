using System;
using System.Collections.Generic;
using System.Text;

namespace TestRestAPI.Users.DTOS
{
    public class AuthenticateUserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
