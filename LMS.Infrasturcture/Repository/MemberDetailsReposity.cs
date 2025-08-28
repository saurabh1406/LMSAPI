using LMSAPI.Domain.Entities;
using LMSAPI.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrasturcture.Repository
{
    public class MemberDetailsReposity(LMSDbContext context) : IMemberDetails
    {
        public async Task<MemberDetails> AddMemberasync(MemberDetails memberDetails)
        {
            context.MemberDetails.Add(memberDetails);
             await context.SaveChangesAsync();
            return memberDetails;
        }

        public async Task<bool> DeleteMemberAsync(MemberDetails member)
        {
            context.Remove(member);
            return await context.SaveChangesAsync()>0;
        }

        public async Task<IEnumerable<MemberDetails>> GetAllMembersAsync()
        {
            return await context.MemberDetails.ToListAsync();
        }

        public async Task<MemberDetails?> GetMemberDetailsByIdAsync(Guid memberId)
        {
            return await context.MemberDetails.AsNoTracking().SingleOrDefaultAsync(mem => mem.Id == memberId);
        }

        public async Task<MemberDetails> UpdateMemberAsync(MemberDetails memberDetails)
        {
            context.MemberDetails.Update(memberDetails);
            await context.SaveChangesAsync();
            return memberDetails;
        }
    }
}
