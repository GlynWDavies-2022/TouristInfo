using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace TouristInfo.API.Controllers;

[Route("api/files")]
[ApiController]
public class FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
    : ControllerBase
{
    // async = modifier
    // await = operator

    [HttpGet("{fileId}")]
    public async Task<ActionResult> GetFile(string fileId)
    {
        // look up the actual file, depending on the fileId...
        // demo code
        var pathToFile = "sample-file.pdf";

        // check whether the file exists
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
        return File(bytes,
            contentType,
            Path.GetFileName(pathToFile));
    }
}

