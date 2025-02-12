using Application.Features.InfluencerReviews.Commands.Create;
using Application.Features.InfluencerReviews.Commands.Delete;
using Application.Features.InfluencerReviews.Commands.Update;
using Application.Features.InfluencerReviews.Queries.GetById;
using Application.Features.InfluencerReviews.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InfluencerReviewsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedInfluencerReviewResponse>> Add([FromBody] CreateInfluencerReviewCommand command)
    {
        CreatedInfluencerReviewResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedInfluencerReviewResponse>> Update([FromBody] UpdateInfluencerReviewCommand command)
    {
        UpdatedInfluencerReviewResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedInfluencerReviewResponse>> Delete([FromRoute] Guid id)
    {
        DeleteInfluencerReviewCommand command = new() { Id = id };

        DeletedInfluencerReviewResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdInfluencerReviewResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdInfluencerReviewQuery query = new() { Id = id };

        GetByIdInfluencerReviewResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListInfluencerReviewListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInfluencerReviewQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListInfluencerReviewListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}