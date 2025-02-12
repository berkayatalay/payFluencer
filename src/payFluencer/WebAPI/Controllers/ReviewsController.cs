using Application.Features.Reviews.Commands.Create;
using Application.Features.Reviews.Commands.Delete;
using Application.Features.Reviews.Commands.Update;
using Application.Features.Reviews.Queries.GetById;
using Application.Features.Reviews.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedReviewResponse>> Add([FromBody] CreateReviewCommand command)
    {
        CreatedReviewResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedReviewResponse>> Update([FromBody] UpdateReviewCommand command)
    {
        UpdatedReviewResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedReviewResponse>> Delete([FromRoute] Guid id)
    {
        DeleteReviewCommand command = new() { Id = id };

        DeletedReviewResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdReviewResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdReviewQuery query = new() { Id = id };

        GetByIdReviewResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListReviewListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListReviewQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListReviewListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}