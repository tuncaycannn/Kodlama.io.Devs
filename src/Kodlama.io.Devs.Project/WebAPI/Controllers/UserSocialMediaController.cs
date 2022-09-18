using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.PassiveTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using Application.Features.Technologies.Queries.GetListTechnology;
using Application.Features.UserSocialMedia.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedia.Commands.PassiveUserSocialMedia;
using Application.Features.UserSocialMedia.Commands.UpdateUserSocialMedia;
using Application.Features.UserSocialMedia.Dtos;
using Application.Features.UserSocialMedia.Models;
using Application.Features.UserSocialMedia.Queries.GetByIdUserSocialMedia;
using Application.Features.UserSocialMedia.Queries.GetListUserSocialMedia;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialMediaController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserSocialMediaCommand createUserSocialMediaCommand)
        {
            CreateUserSocialMediaDto result = await Mediator.Send(createUserSocialMediaCommand);
            return Created("", result);
        }

        [HttpPost]
        public async Task<IActionResult> Passive([FromBody] PassiveUserSocialMediaCommand passiveUserSocialMediaCommand)
        {
            PassiveUserSocialMediaDto result = await Mediator.Send(passiveUserSocialMediaCommand);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateUserSocialMediaCommand updateUserSocialMediaCommand)
        {
            UpdateUserSocialMediaDto result = await Mediator.Send(updateUserSocialMediaCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserSocialMediaQuery getListUserSocialMediaQuery = new() { PageRequest = pageRequest };
            UserSocialMediaListModel result = await Mediator.Send(getListUserSocialMediaQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserSocialMediaQuery getByIdUserSocialMediaQuery)
        {
            UserSocialMediaGetByIdDto result = await Mediator.Send(getByIdUserSocialMediaQuery);
            return Ok(result);
        }
    }
}
