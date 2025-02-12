using Application.Features.PostGigs.Commands.Create;
using Application.Features.PostGigs.Commands.Delete;
using Application.Features.PostGigs.Commands.Update;
using Application.Features.PostGigs.Queries.GetById;
using Application.Features.PostGigs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostGigsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPostGigResponse>> Add([FromBody] CreatePostGigCommand command)
    {
        CreatedPostGigResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPostGigResponse>> Update([FromBody] UpdatePostGigCommand command)
    {
        UpdatedPostGigResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPostGigResponse>> Delete([FromRoute] Guid id)
    {
        DeletePostGigCommand command = new() { Id = id };

        DeletedPostGigResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPostGigResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPostGigQuery query = new() { Id = id };

        GetByIdPostGigResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListPostGigListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPostGigQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPostGigListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}