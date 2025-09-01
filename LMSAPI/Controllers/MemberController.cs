using LMS.Application.DTOs;
using LMS.Application.Handlers.Member.Command;
using LMS.Application.Handlers.Member.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(ISender _sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMembers() 
        {
            return Ok(await _sender.Send(new GetMembersDetailQuery()));
        }

        [HttpGet("{memberID:guid}")]
        public async Task<IActionResult> GetMemberById(Guid memberID)
        {
            return await _sender.Send(new GetMemberByIdQuery(memberID)) is MemberDetailsDTO member ? Ok(member) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddMemberDetails([FromBody] MemberDetailsDTO memberDetails)
        {
            await _sender.Send(new AddMemberCommand(memberDetails));
            return Ok(memberDetails);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMemberDetails([FromBody] MemberDetailsDTO memberDetails)
        {
            var result = await _sender.Send(new UpdateMemberCommand(memberDetails));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMemberDetails(Guid memberID)
        {
            var result = await _sender.Send(new DeleteMemberCommand(memberID));
            return Ok(result);
        }

    }
}
