using Application.Features.Disputes.Commands.Create;
using Application.Features.Disputes.Commands.Delete;
using Application.Features.Disputes.Commands.Update;
using Application.Features.Disputes.Queries.GetById;
using Application.Features.Disputes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DisputesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDisputeResponse>> Add([FromBody] CreateDisputeCommand command)
    {
        CreatedDisputeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDisputeResponse>> Update([FromBody] UpdateDisputeCommand command)
    {
        UpdatedDisputeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDisputeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDisputeCommand command = new() { Id = id };

        DeletedDisputeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDisputeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDisputeQuery query = new() { Id = id };

        GetByIdDisputeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDisputeListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDisputeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDisputeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}