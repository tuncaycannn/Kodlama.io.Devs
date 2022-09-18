using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedia.Dtos
{
    public class UpdateUserSocialMediaDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool Status { get; set; }
    }
}
