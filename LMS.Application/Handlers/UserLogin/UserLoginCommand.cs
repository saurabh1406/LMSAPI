using AutoMapper;
using LMS.Application.DTOs;
using LMSAPI.Domain.Interface;
using LMSP.Domain.Domain.Entities;
using MediatR;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS.Application.Handlers.UserLogin
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }
    public record UserLoginCommand(string email, string password) : IRequest<LoginResponse>;

    public class UserLoginHandler(IUsers _usersRepo, IMapper _mapper, ITokens _genToken) : IRequestHandler<UserLoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userEntity = await _usersRepo.GetUserByEmailIdAsync(request.email);
                
                if (userEntity is not null)
                {
                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.password, userEntity.PasswordHash);
                    if (isPasswordValid)
                    {
                        var token = _genToken.GenerateToken(userEntity);
                        return new LoginResponse { Token = token };
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("Invalid password");
                    }
                }
                else 
                {
                    throw new KeyNotFoundException($"User with email {request.email} not found");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }

}
