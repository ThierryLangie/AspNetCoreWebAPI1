using AspNetCoreWebAPI1.Models;
using AspNetCoreWebAPI1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAPI1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly RepositoryService _repositoryService;

		public TestController(RepositoryService repositoryService) => _repositoryService = repositoryService;


		[HttpGet("bonjour/{nom}")]
		public IActionResult Bonjour(string nom)
		{
			if (string.IsNullOrEmpty(nom))
			{
				return BadRequest();
			}
			return Ok($"Bonjour {nom} !");
		}

		[HttpGet("users")]
		public async Task<List<User>> Users()
		{
			return await _repositoryService.GetAllUsersAsync();
		}
	}
}
