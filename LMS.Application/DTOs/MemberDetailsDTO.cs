using System.ComponentModel.DataAnnotations;

namespace LMS.Application.DTOs
{
   public class MemberDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string MembershipType { get; set; } // e.g., Regular, Premium
        public DateTime MembershipStartDate { get; set; }
        public DateTime? MembershipEndDate { get; set; } // Nullable in case the membership is ongoing
        public bool IsActive { get; set; } // Indicates if the member is currently active
        public string ProfileImageUrl { get; set; } // URL to the member's profile image
        public string MembershipStatus { get; set; } // e.g., Active, Inactive, Suspended
        public DateTime? LastActivityDate { get; set; } // Nullable in case the member has never been active
        public string CreatedBy { get; set; } // User who created the member entry
        public DateTime CreatedDate { get; set; } // Date when the member entry was created
        public string ModifiedBy { get; set; } // User who last modified the member entry
        public DateTime? ModifiedDate { get; set; } // Nullable in case the member entry has never been modified
    }
}


