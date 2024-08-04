using System.Xml.Linq;
using url_shortener.api.Models.Dto;

namespace url_shortener.api.Repositories;

public interface IUrlRepository
{
    // Get
    
    // Get {id}
    
    // Save
    Task SaveAsync(UrlDto url);

    // Delete {id}
}