﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRestAPI.Users.Entities
{
    public class Authenticate
    {
        public User user { get; set; }
        public string token { get; set; }
    }
}
