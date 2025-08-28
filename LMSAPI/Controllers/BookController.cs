using LMS.Application.BookHandler.BookCommand;
using LMS.Application.BookHandler.BookQuery;
using LMS.Application.DTOs;
using LMSAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(ISender mediatR) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var result = await mediatR.Send(new GetAllBooksQuery());
           
            return Ok(result);
        }

        [HttpGet("{bookId:guid}")]
        public async Task<IActionResult> GetBookById(Guid bookId)
        {
            var result = await mediatR.Send(new GetBookByIdQuery(bookId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookDetailsDTO bookDetails)
        {
            var result = await mediatR.Send(new AddBookCommand(bookDetails));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] BookDetailsDTO details)
        {
            var result = await mediatR.Send(new UpdateBookCommand(details.Id, details));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            var result = await mediatR.Send(new DeleteBookCommand(bookId));
            return Ok(result);
        }
    }
}
