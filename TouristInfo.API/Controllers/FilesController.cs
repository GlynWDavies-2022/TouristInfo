using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace TouristInfo.API.Controllers;

[Route("api/files")]
[ApiController]
public class FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider) : ControllerBase
{
    [HttpGet("{fileId}")]
    public async Task<ActionResult> GetFile(string fileId)
    {
        // In Production you need to look up the actual file

        var pathToFile = "sample.pdf";

        // Check if the file exists

        if (!System.IO.File.Exists(pathToFile))
        {
            return NotFound();
        }

        if (!fileExtensionContentTypeProvider.TryGetContentType(pathToFile,
            out var contentType))
        {
            contentType = "application/octet-stream";
        }

        var bytes = await System.IO.File.ReadAllBytesAsync(pathToFile);

        return File(bytes, contentType, Path.GetFileName(pathToFile));
    }
}
