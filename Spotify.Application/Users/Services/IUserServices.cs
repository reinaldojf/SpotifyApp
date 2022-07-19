using Spotify.Application.Users.Dto;

namespace Spotify.Application.Users.Services
{
    public interface IUserServices
    {
        Task<UserOutputDto> Create(UserInputDto dto);
    }
}