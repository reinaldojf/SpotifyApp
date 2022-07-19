﻿using MediatR;
using Spotify.Application.Album.Handler.Commands;
using Spotify.Application.Album.Handler.Query;
using Spotify.Application.Album.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler
{
    public class UserHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumCommandResponse>,
                                IRequestHandler<GetAllQueryCommand, GetAllQueryCommandResponse>
    {
        private IAlbumServices albumService;

        public UserHandler(IAlbumServices albumService)
        {
            this.albumService = albumService;
        }


        public async Task<CreateAlbumCommandResponse> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var dto = await this.albumService.Create(request.Album);

            return new CreateAlbumCommandResponse(dto);
        }

        public async Task<GetAllQueryCommandResponse> Handle(GetAllQueryCommand request, CancellationToken cancellationToken)
        {
            var dto = await this.albumService.GetAll();

            return new GetAllQueryCommandResponse(dto);
        }
    }
}
