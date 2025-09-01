using LMSAPI.Domain.Entities;
using LMSP.Domain.Domain.Entities;

namespace LMSAPI.Domain.Interface
{
    public interface IUsers
    {
        Task<Users> GetUserByEmailIdAsync(string email);
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> AddUserAsync(Users user);
        Task<Users> UpdateUserAsync(Users user);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
