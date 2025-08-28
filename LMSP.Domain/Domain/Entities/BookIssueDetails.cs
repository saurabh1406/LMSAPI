using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSP.Domain.Domain.Entities
{
    [Table("TblBookIssueDetails")]
    public class BookIssueDetails
    {
        [Key]
        [Required]
        public Guid BookIssueID { get; set; } // Unique identifier for the book issue record

        [ForeignKey("BookDetails")]
        public Guid BookID { get; set; } // Foreign key to the book being issued
        [ForeignKey("MemberDetails")]
        public Guid MemberID { get; set; } // Foreign key to the member who is issuing the book
        public DateTime IssueDate { get; set; } // Date when the book was issued
        public DateTime DueDate { get; set; } // Date when the book is due to be returned
        public DateTime? ReturnDate { get; set; } // Nullable date when the book was returned, if applicable
        public string Status { get; set; } // Status of the book issue (e.g., Issued, Returned, Overdue)
        public string CreatedBy { get; set; } // User who created the book issue record
        public DateTime CreatedDate { get; set; } // Date when the book issue record was created
        public string ModifiedBy { get; set; } // User who last modified the book issue record
        public DateTime ModifiedDate { get; set; }

    }
}
