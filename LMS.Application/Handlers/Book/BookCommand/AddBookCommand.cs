using AutoMapper;
using LMS.Application.DTOs;
using LMS.Application.Common.Mappings;
using LMSAPI.Domain.Entities;
using LMSAPI.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Handlers.Book.BookCommand
{
    public record AddBookCommand(BookDetailsDTO BookDetailsdto) : IRequest<BookDetailsDTO>;

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDetailsDTO>
    {
        private readonly IBookDetails _bookDetails;
        private readonly IMapper _mapper;
        public AddBookCommandHandler(IBookDetails bookDetails, IMapper mapper)
        {
            _bookDetails = bookDetails;
            _mapper = mapper;
        }
        public async Task<BookDetailsDTO> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            request.BookDetailsdto.Id = Guid.NewGuid();
            var bookEntity = _mapper.Map<BookDetails>(request.BookDetailsdto);
            var result = await _bookDetails.AddBookAsync(bookEntity);

            return _mapper.Map<BookDetailsDTO>(result);
        }
    }

   
}
