using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSP.Domain.Domain.Entities
{
    [Table("TblUserRole")]
    public class UserType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
