using System;
using hostingRatingWebApi.DTO;
using hostingRatingWebApi.Models;

namespace hostingRatingWebApi.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        JwtDTO CreateToken(Guid userId,string role);
    }
}