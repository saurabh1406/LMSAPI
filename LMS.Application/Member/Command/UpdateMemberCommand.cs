using AutoMapper;
using AutoMapper.Execution;
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
    public record UpdateMemberCommand(MemberDetailsDTO member) : IRequest<MemberDetailsDTO>;

    public class UpdateMemberCommandHandler(IMemberDetails _memberDetailsRepo, IMapper _mapper) : IRequestHandler<UpdateMemberCommand, MemberDetailsDTO>
    {
        public async Task<MemberDetailsDTO> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var memberEntity = _mapper.Map<MemberDetails>(request);

                var memberDetailsToUpdate = await _memberDetailsRepo.GetMemberDetailsByIdAsync(memberEntity.Id);

                if (memberDetailsToUpdate == null) return null;

                dynamic mDetails = null;

                if (memberDetailsToUpdate != null)
                {
                    memberDetailsToUpdate.ModifiedDate = DateTime.UtcNow;
                    memberDetailsToUpdate.Name = request.member.Name;
                    memberDetailsToUpdate.Email = request.member.Email;
                    memberDetailsToUpdate.PhoneNumber = request.member.PhoneNumber;
                    memberDetailsToUpdate.Address = request.member.Address;
                    memberDetailsToUpdate.MembershipType = request.member.MembershipType;
                    memberDetailsToUpdate.MembershipStartDate = request.member.MembershipStartDate;
                    memberDetailsToUpdate.MembershipEndDate = request.member.MembershipEndDate;
                    memberDetailsToUpdate.IsActive = request.member.IsActive;
                    memberDetailsToUpdate.ProfileImageUrl = request.member.ProfileImageUrl;
                    memberDetailsToUpdate.MembershipStatus = request.member.MembershipStatus;
                    memberDetailsToUpdate.LastActivityDate = request.member.LastActivityDate;
                    memberDetailsToUpdate.ModifiedBy = request.member.ModifiedBy;

                    mDetails = _memberDetailsRepo.UpdateMemberAsync(memberDetailsToUpdate);
                }

                return _mapper.Map<MemberDetailsDTO>(mDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

    }
}