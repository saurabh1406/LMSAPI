using LMSAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LMS.Application.DTOs
{
    public class BookDetailsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string CoverImageUrl { get; set; }
        [Required]
        public string AvailabilityStatus { get; set; } // e.g., Available, Checked Out, Reserved
        public DateTime? LastCheckedOutDate { get; set; } // Nullable in case the book has never been checked outa
        public DateTime? DueDate { get; set; } // Nullable in case the book is not currently checked out
        public int? NumberOfCopies { get; set; } // Nullable in case the number of copies is not specified
        public string Rating { get; set; } // e.g., 4.5 stars
        public string Reviews { get; set; } // JSON or XML formatted reviews
        public string CreatedBy { get; set; } // User who created the book entry
        public DateTime CreatedDate { get; set; } // Date when the book entry was created
        public string ModifiedBy { get; set; } // User who last modified the book entry
        public DateTime? ModifiedDate { get; set; } // Nullable in case the book entry has never been modified

    }
}


