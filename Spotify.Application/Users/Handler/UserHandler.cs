using MediatR;
using Spotify.Application.Users.Handler.Commands;
using Spotify.Application.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Users.Handler
{
    public class UserHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
                                
    {
        private IUserServices UserService;

        public UserHandler(IUserServices UserService)
        {
            this.UserService = UserService;
        }


        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var dto = await this.UserService.Create(request.User);

            return new CreateUserCommandResponse(dto);
        }
    }
}
