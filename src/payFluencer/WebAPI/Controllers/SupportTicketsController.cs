using Application.Features.SupportTickets.Commands.Create;
using Application.Features.SupportTickets.Commands.Delete;
using Application.Features.SupportTickets.Commands.Update;
using Application.Features.SupportTickets.Queries.GetById;
using Application.Features.SupportTickets.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupportTicketsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSupportTicketResponse>> Add([FromBody] CreateSupportTicketCommand command)
    {
        CreatedSupportTicketResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSupportTicketResponse>> Update([FromBody] UpdateSupportTicketCommand command)
    {
        UpdatedSupportTicketResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSupportTicketResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSupportTicketCommand command = new() { Id = id };

        DeletedSupportTicketResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSupportTicketResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSupportTicketQuery query = new() { Id = id };

        GetByIdSupportTicketResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListSupportTicketListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSupportTicketQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSupportTicketListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}