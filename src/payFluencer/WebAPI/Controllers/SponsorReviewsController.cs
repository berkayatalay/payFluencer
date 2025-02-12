using Application.Features.SponsorReviews.Commands.Create;
using Application.Features.SponsorReviews.Commands.Delete;
using Application.Features.SponsorReviews.Commands.Update;
using Application.Features.SponsorReviews.Queries.GetById;
using Application.Features.SponsorReviews.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SponsorReviewsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSponsorReviewResponse>> Add([FromBody] CreateSponsorReviewCommand command)
    {
        CreatedSponsorReviewResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSponsorReviewResponse>> Update([FromBody] UpdateSponsorReviewCommand command)
    {
        UpdatedSponsorReviewResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSponsorReviewResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSponsorReviewCommand command = new() { Id = id };

        DeletedSponsorReviewResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSponsorReviewResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSponsorReviewQuery query = new() { Id = id };

        GetByIdSponsorReviewResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListSponsorReviewListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSponsorReviewQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSponsorReviewListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}