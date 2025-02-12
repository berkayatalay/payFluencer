using Application.Features.Influencers.Commands.Create;
using Application.Features.Influencers.Commands.Delete;
using Application.Features.Influencers.Commands.Update;
using Application.Features.Influencers.Queries.GetById;
using Application.Features.Influencers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InfluencersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedInfluencerResponse>> Add([FromBody] CreateInfluencerCommand command)
    {
        CreatedInfluencerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedInfluencerResponse>> Update([FromBody] UpdateInfluencerCommand command)
    {
        UpdatedInfluencerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedInfluencerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteInfluencerCommand command = new() { Id = id };

        DeletedInfluencerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdInfluencerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdInfluencerQuery query = new() { Id = id };

        GetByIdInfluencerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListInfluencerListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInfluencerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListInfluencerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}