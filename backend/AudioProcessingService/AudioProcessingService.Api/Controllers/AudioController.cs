using Microsoft.AspNetCore.Mvc;

namespace AudioProcessingService.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AudioController : Controller
{
    // POST /api/v1/audio/sendAudio
    [HttpPost]
    public ActionResult SendAudio()
    {
        throw new NotImplementedException();
    }
}