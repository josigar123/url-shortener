
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using url_shortener.api.Services;

namespace url_shortener.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RedirectionController(MongoDbService mongoDbService) : ControllerBase
{

    [HttpGet]
    [EnableCors("AllowSpecificOrigin")]
    public async Task<IActionResult> RedirectToOriginalUrl([FromQuery] string short_link)
    {

        var full_link = await mongoDbService.GetFullLinkAsync(short_link);

        if (full_link == null)
        {
            return BadRequest("In RedirectToOrigianlUrl: original URL for shortlink " + short_link + " is null");
        }

        if (!full_link.StartsWith("http://") && !full_link.StartsWith("https://"))
        {
            full_link = "https://" + full_link;
        }

        return Redirect(full_link);
    }
}