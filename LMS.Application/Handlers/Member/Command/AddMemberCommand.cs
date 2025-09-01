using AutoMapper;
using LMS.Application.Common.Wrapper;
using LMS.Application.DTOs;
using LMSAPI.Domain.Entities;
using LMSAPI.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LMS.Application.Handlers.Member.Command
{
    public record AddMemberCommand(MemberDetailsDTO member) : IRequest<MemberDetailsDTO>;

    public class AddMemberCommandHandler(IMemberDetails memberDetailsRepo, IMapper _mapper) : IRequestHandler<AddMemberCommand, MemberDetailsDTO>
    {
        public async Task<MemberDetailsDTO> Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            request.member.Id = Guid.NewGuid();
            var memberEntity = _mapper.Map<MemberDetails>(request.member);
            var result = await memberDetailsRepo.AddMemberasync(memberEntity);
            return _mapper.Map<MemberDetailsDTO>(result);
        }
    }


}
