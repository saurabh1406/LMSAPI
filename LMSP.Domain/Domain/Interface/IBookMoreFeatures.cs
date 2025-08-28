using LMSAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSP.Domain.Domain.Interface
{
    public interface IBookMoreFeatures
    {
        Task<IEnumerable<BookDetails>> SearchBooksAsync(string searchTerm);
        Task<IEnumerable<BookDetails>> GetBooksByAuthorAsync(string authorName);
        Task<IEnumerable<BookDetails>> GetBooksByGenreAsync(string genre);
        Task<IEnumerable<BookDetails>> GetBooksByLanguageAsync(string language);
        Task<IEnumerable<BookDetails>> GetAvailableBooksAsync();
        Task<IEnumerable<BookDetails>> GetCheckedOutBooksAsync();
    }
}
