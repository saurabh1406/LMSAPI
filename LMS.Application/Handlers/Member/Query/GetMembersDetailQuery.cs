using AutoMapper;
using LMS.Application.DTOs;
using LMSAPI.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Handlers.Member.Query
{
    public record GetMembersDetailQuery : IRequest<List<MemberDetailsDTO>>;

    public class GetMembersDetailHandler(IMemberDetails _memberDetails, IMapper _mapper) : IRequestHandler<GetMembersDetailQuery, List<MemberDetailsDTO>>
    {
        public async Task<List<MemberDetailsDTO>> Handle(GetMembersDetailQuery request, CancellationToken cancellationToken)
        {
              return _mapper.Map<List<MemberDetailsDTO>>(await _memberDetails.GetAllMembersAsync());
        }
    }

    public record GetMemberByIdQuery(Guid Id) : IRequest<MemberDetailsDTO>;

    public class GetMemberByIdHandler(IMemberDetails _memberDetailsRepo, IMapper _mapper) : IRequestHandler<GetMemberByIdQuery, MemberDetailsDTO>
    {
        public async Task<MemberDetailsDTO> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _memberDetailsRepo.GetMemberDetailsByIdAsync(request.Id);
            if (member is null)
            {
                throw new KeyNotFoundException($"Member with ID {request.Id} not found");
            }
            return _mapper.Map<MemberDetailsDTO>(member);
        } 
    }


}
