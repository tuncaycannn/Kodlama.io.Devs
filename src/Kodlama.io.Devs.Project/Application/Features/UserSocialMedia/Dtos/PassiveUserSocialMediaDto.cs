﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedia.Dtos
{
    public class PassiveUserSocialMediaDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
    }
}
