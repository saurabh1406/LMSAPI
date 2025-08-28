using LMSAPI.Domain.Entities;

namespace LMSAPI.Domain.Interface
{
    public interface IMemberDetails
    {
        Task<MemberDetails> AddMemberasync(MemberDetails memberDetails);
        Task<bool> DeleteMemberAsync(MemberDetails member);
        Task<IEnumerable<MemberDetails>> GetAllMembersAsync();
        Task<MemberDetails> GetMemberDetailsByIdAsync(Guid memberId);
        Task<MemberDetails> UpdateMemberAsync(MemberDetails memberDetails);
    }
}
