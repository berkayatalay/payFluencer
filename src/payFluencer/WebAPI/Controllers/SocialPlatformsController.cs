using Application.Features.SocialPlatforms.Commands.Create;
using Application.Features.SocialPlatforms.Commands.Delete;
using Application.Features.SocialPlatforms.Commands.Update;
using Application.Features.SocialPlatforms.Queries.GetById;
using Application.Features.SocialPlatforms.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialPlatformsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSocialPlatformResponse>> Add([FromBody] CreateSocialPlatformCommand command)
    {
        CreatedSocialPlatformResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSocialPlatformResponse>> Update([FromBody] UpdateSocialPlatformCommand command)
    {
        UpdatedSocialPlatformResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSocialPlatformResponse>> Delete([FromRoute] int id)
    {
        DeleteSocialPlatformCommand command = new() { Id = id };

        DeletedSocialPlatformResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSocialPlatformResponse>> GetById([FromRoute] int id)
    {
        GetByIdSocialPlatformQuery query = new() { Id = id };

        GetByIdSocialPlatformResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListSocialPlatformListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSocialPlatformQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSocialPlatformListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}