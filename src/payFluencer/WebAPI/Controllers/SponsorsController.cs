using Application.Features.Sponsors.Commands.Create;
using Application.Features.Sponsors.Commands.Delete;
using Application.Features.Sponsors.Commands.Update;
using Application.Features.Sponsors.Queries.GetById;
using Application.Features.Sponsors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SponsorsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSponsorResponse>> Add([FromBody] CreateSponsorCommand command)
    {
        CreatedSponsorResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSponsorResponse>> Update([FromBody] UpdateSponsorCommand command)
    {
        UpdatedSponsorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSponsorResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSponsorCommand command = new() { Id = id };

        DeletedSponsorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSponsorResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSponsorQuery query = new() { Id = id };

        GetByIdSponsorResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListSponsorListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSponsorQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSponsorListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}