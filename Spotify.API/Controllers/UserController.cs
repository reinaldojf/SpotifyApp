using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Application.Album.Dto;
using Spotify.Application.Album.Handler.Commands;
using Spotify.Application.Album.Handler.Query;
using Spotify.Application.Users.Dto;
using Spotify.Application.Users.Handler.Commands;
using Spotify.Domain.Album;
using Spotify.Domain.Album.Repository;
using Spotify.Infrastructure.Database;


namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IMediator Handler { get; }

        public UserController(IMediator handler)
        {
            Handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserInputDto inputDto)
        {
            var result = await this.Handler.Send(new CreateUserCommand(inputDto));

            return Created($"/{result.User}", result.User);
        }
    }
}
