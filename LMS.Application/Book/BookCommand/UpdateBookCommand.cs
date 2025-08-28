using AutoMapper;
using LMS.Application.DTOs;
using LMSAPI.Domain.Entities;
using LMSAPI.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.BookHandler.BookCommand
{
   public record UpdateBookCommand(Guid Id, BookDetailsDTO BookDetails) : IRequest<BookDetailsDTO>;
    public class UpdateBookHandler(IBookDetails bookDetailsRepo, IMapper _mapper) : IRequestHandler<UpdateBookCommand, BookDetailsDTO>
    {
         public async Task<BookDetailsDTO> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
         {
               var bookDetails = _mapper.Map<BookDetails>(request.BookDetails);
               var result = await bookDetailsRepo.UpdateBookAsync(request.Id, bookDetails);
               return _mapper.Map<BookDetailsDTO>(result);
        }
    }
}
