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

namespace LMS.Application.Handlers.UserLogin
{
    public record UserCreationCommand(UserDetailsDTO userDetails) : IRequest<UserDetailsDTO>;

    public class UserCreationHandler(IUsers _users, IMapper _mapper) : IRequestHandler<UserCreationCommand, UserDetailsDTO>
    {
        public async Task<UserDetailsDTO> Handle(UserCreationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userEntity = _mapper.Map<Users>(request.userDetails);
                var isEmailExists = await _users.GetUserByEmailIdAsync(userEntity.Email) !=null;
                if (!isEmailExists)
                {
                    userEntity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.userDetails.PasswordHash);
                }

                 await _users.AddUserAsync(userEntity);
                return _mapper.Map<UserDetailsDTO>(userEntity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }

}
