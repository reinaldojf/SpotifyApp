﻿using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Spotify.Domain.User.Repository;
using System.Security.Claims;

namespace Spotify.Idp.ProfileService
{
    public class UserProfile : IProfileService
    {
        public UserProfile(IUserRepository repository)
        {
            Repository = repository;
        }

        public IUserRepository Repository { get; }


        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = context.Subject.GetSubjectId();

            var user = await this.Repository.GetById(new Guid(id));

            var claims = new List<Claim>()
            {
                new Claim("name", user.Name),
                new Claim("email", user.Email.Value),
                new Claim("role", "spotify-user"),
            };

            context.IssuedClaims = claims;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
