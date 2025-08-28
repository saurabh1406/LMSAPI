using AutoMapper;
using LMS.Application.DTOs;
using LMSAPI.Domain.Entities;
using LMSAPI.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.MemberHandler.Command
{
    public record DeleteMemberCommand(Guid Id) : IRequest<bool>;

    public class DeleteMemberCommandHandler(IMemberDetails memberDetailsRepo, IMapper _mapper) : IRequestHandler<DeleteMemberCommand, bool>
    {
        public async Task<bool> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var member = await memberDetailsRepo.GetMemberDetailsByIdAsync(request.Id);

                if (member == null) return false;

                var memberEntity = _mapper.Map<MemberDetails>(member);
                var result = await memberDetailsRepo.DeleteMemberAsync(memberEntity);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }


}
