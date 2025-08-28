using LMSAPI.Domain.Entities;
using LMSAPI.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrasturcture.Repository
{
    public class BookDetailsReposity(LMSDbContext context) : IBookDetails
    {
        public async Task<BookDetails> AddBookAsync(BookDetails bookDetails)
        {
            context.BookDetails.Add(bookDetails);
             await context.SaveChangesAsync();
            return bookDetails;
        }

        public async Task<bool> DeleteBookAsync(Guid bookId)
        {
            var book = context.BookDetails.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                return false; // Book not found
            }
            context.Remove(book);
            await context.SaveChangesAsync();
            return true; // Book deleted successfully
        }

        public async Task<IEnumerable<BookDetails>> GetAllBooksAsync()
        {
            return await context.BookDetails.ToListAsync();
        }

        public async Task<BookDetails> GetBookDetailsByIdAsync(Guid bookId)
        {
            return await context.BookDetails.FirstOrDefaultAsync(book => book.Id == bookId) ?? throw new KeyNotFoundException("Book not found");
        }

        public async Task<BookDetails> UpdateBookAsync(Guid BookId, BookDetails bookDetails)
        {
            var bookDetailsToUpdate = await context.BookDetails.FirstOrDefaultAsync(b => b.Id == BookId);
            if (bookDetailsToUpdate != null)
            {
                bookDetailsToUpdate.ModifiedDate = DateTime.UtcNow;
                bookDetailsToUpdate.Title = bookDetails.Title;
                bookDetailsToUpdate.Description = bookDetails.Description;
                bookDetailsToUpdate.Author = bookDetails.Author;
                bookDetailsToUpdate.Language = bookDetails.Language;
                bookDetailsToUpdate.Genre = bookDetails.Genre;
                bookDetailsToUpdate.CoverImageUrl = bookDetails.CoverImageUrl;
                bookDetailsToUpdate.AvailabilityStatus = bookDetails.AvailabilityStatus;
                bookDetailsToUpdate.LastCheckedOutDate = bookDetails.LastCheckedOutDate;
                bookDetailsToUpdate.DueDate = bookDetails.DueDate;
                bookDetailsToUpdate.NumberOfCopies = bookDetails.NumberOfCopies;
                bookDetailsToUpdate.Rating = bookDetails.Rating;
                bookDetailsToUpdate.Reviews = bookDetails.Reviews;
                bookDetailsToUpdate.ModifiedBy = bookDetails.ModifiedBy;
                await context.SaveChangesAsync();
            }
           
            return bookDetails;
        }
    }
}
