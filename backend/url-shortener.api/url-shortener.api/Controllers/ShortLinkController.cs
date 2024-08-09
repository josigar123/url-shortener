using Microsoft.AspNetCore.Mvc;
using url_shortener.api.Interfaces;
using url_shortener.api.Models.Dto;
using url_shortener.api.Services;

namespace url_shortener.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShortLinkController(MongoDbService mongoDbService, IShortLinkGenerator shortLinkGenerator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mongoDbService.GetAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id){
        var result = await mongoDbService.GetAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string url)
    {
        var shortLinkDto = new ShortLinkDto(url, shortLinkGenerator.GenerateShortLink());
        
        await mongoDbService.SaveAsync(shortLinkDto);
        return CreatedAtAction(nameof(Post), new {id = shortLinkDto.Id}, shortLinkDto);
    }
}
