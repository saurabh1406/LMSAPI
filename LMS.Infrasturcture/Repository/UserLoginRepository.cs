using LMSAPI.Domain.Interface;
using LMSP.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrasturcture.Repository
{
    public class UserLoginRepository(LMSDbContext _context) : IUsers
    {
        public async Task<Users> AddUserAsync(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<bool> DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Users?> GetUserByEmailIdAsync(string email)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email);
        }

        public Task<Users> UpdateUserAsync(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
