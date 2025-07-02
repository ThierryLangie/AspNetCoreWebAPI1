using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpGet("bonjour/{nom}")]
		public IActionResult Bonjour(string nom)
		{
			if (string.IsNullOrEmpty(nom))
			{
				return BadRequest();
			}
			return Ok($"Bonjour {nom} !");
		}
	}
}
