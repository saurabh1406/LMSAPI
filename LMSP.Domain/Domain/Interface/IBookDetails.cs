using LMSAPI.Domain.Entities;

namespace LMSAPI.Domain.Interface
{
    public interface IBookDetails
    {
        Task<BookDetails> GetBookDetailsByIdAsync(Guid bookId);
        Task<IEnumerable<BookDetails>> GetAllBooksAsync();
        Task<BookDetails> AddBookAsync(BookDetails bookDetails);
        Task<BookDetails> UpdateBookAsync(Guid BookId, BookDetails bookDetails);
        Task<bool> DeleteBookAsync(Guid bookId);
    }
}
