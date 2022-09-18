﻿using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Dtos
{
    public class RegisteredDto
    {
        public AccessToken AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
