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

namespace LMS.Application.BookHandler.BookQuery
{
    public record GetAllBooksQuery : IRequest<List<BookDetailsDTO>>;

    public class GetAllBooksHandler(IBookDetails bookDetailsRepo, IMapper _mapper) : IRequestHandler<GetAllBooksQuery, List<BookDetailsDTO>>
    {
        public async Task<List<BookDetailsDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
           return _mapper.Map<List<BookDetailsDTO>>(await bookDetailsRepo.GetAllBooksAsync());
        }
    }

    public record GetBookByIdQuery(Guid Id) : IRequest<BookDetailsDTO>;

    public class GetBookByIdHandler(IBookDetails bookDetailsRepo, IMapper _mapper) : IRequestHandler<GetBookByIdQuery, BookDetailsDTO>
    {
        public async Task<BookDetailsDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
           return _mapper.Map<BookDetailsDTO>(await bookDetailsRepo.GetBookDetailsByIdAsync(request.Id));
        }
    }

}
