using Microsoft.AspNetCore.Mvc;
using url_shortener.api.Models.Dto;
using url_shortener.api.Repositories;

namespace url_shortener.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShortLinkController(IUrlRepository urlRepository) : ControllerBase
{
    [HttpPost("post-url")]
    public async Task<IActionResult> Post(UrlDto url)
    {
        await urlRepository.SaveAsync(url);

        return Ok(url);
    }
}