using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.UserSocialMedia.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedia.Models
{
    public class UserSocialMediaListModel : BasePageableModel
    {
        public IList<UserSocialMediaListDto> Items { get; set; }
    }
}
