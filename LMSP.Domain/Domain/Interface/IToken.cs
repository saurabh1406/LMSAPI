using LMSAPI.Domain.Entities;
using LMSP.Domain.Domain.Entities;

namespace LMSAPI.Domain.Interface
{
    public interface ITokens
    {
        string GenerateToken(Users user);
    }
}
