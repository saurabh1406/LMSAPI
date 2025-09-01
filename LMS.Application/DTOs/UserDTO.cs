using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.DTOs
{
    public class UserDetailsDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public Guid UserTypeID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
