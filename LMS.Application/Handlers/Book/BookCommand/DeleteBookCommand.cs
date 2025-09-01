using LMSAPI.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Handlers.Book.BookCommand
{
    public record DeleteBookCommand(Guid BookId) : IRequest<bool>;
    public class DeleteBookHandler(IBookDetails bookDetailsRepo) : IRequestHandler<DeleteBookCommand, bool>
    {
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await bookDetailsRepo.DeleteBookAsync(request.BookId);
        }
    }
}
