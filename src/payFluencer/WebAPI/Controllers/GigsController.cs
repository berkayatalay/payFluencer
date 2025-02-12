using Application.Features.Gigs.Commands.Create;
using Application.Features.Gigs.Commands.Delete;
using Application.Features.Gigs.Commands.Update;
using Application.Features.Gigs.Queries.GetById;
using Application.Features.Gigs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GigsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedGigResponse>> Add([FromBody] CreateGigCommand command)
    {
        CreatedGigResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedGigResponse>> Update([FromBody] UpdateGigCommand command)
    {
        UpdatedGigResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedGigResponse>> Delete([FromRoute] Guid id)
    {
        DeleteGigCommand command = new() { Id = id };

        DeletedGigResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdGigResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdGigQuery query = new() { Id = id };

        GetByIdGigResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListGigListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGigQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListGigListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}