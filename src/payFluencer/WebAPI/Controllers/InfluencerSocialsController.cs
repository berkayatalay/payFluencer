using Application.Features.InfluencerSocials.Commands.Create;
using Application.Features.InfluencerSocials.Commands.Delete;
using Application.Features.InfluencerSocials.Commands.Update;
using Application.Features.InfluencerSocials.Queries.GetById;
using Application.Features.InfluencerSocials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InfluencerSocialsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedInfluencerSocialResponse>> Add([FromBody] CreateInfluencerSocialCommand command)
    {
        CreatedInfluencerSocialResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedInfluencerSocialResponse>> Update([FromBody] UpdateInfluencerSocialCommand command)
    {
        UpdatedInfluencerSocialResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedInfluencerSocialResponse>> Delete([FromRoute] Guid id)
    {
        DeleteInfluencerSocialCommand command = new() { Id = id };

        DeletedInfluencerSocialResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdInfluencerSocialResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdInfluencerSocialQuery query = new() { Id = id };

        GetByIdInfluencerSocialResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListInfluencerSocialListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInfluencerSocialQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListInfluencerSocialListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}