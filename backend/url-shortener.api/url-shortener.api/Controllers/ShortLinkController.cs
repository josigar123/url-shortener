using Microsoft.AspNetCore.Mvc;
using url_shortener.api.Models.Dto;
using url_shortener.api.Services;

namespace url_shortener.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShortLinkController(MongoDbService mongoDbService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        await Task.CompletedTask;
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ShortLinkDto shortLinkDto)
    {
        await mongoDbService.SaveAsync(shortLinkDto);
        return CreatedAtAction(nameof(Post), new { id = shortLinkDto.Id }, shortLinkDto);
    }
}